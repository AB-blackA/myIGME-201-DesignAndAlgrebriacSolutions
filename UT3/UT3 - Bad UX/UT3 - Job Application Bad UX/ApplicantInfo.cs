using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Author: Andrew Black since 12/2/23
 * Purpose: Applicant info form of a Mock Job Application Form with a purposefully bad UX for IGME-201 Unit Test 3
 * Limitations: none
 */

/* Form Controls
 * Form to hold controls
 * RichTextField to display information about form
 * ContinueButton for submission of this form
 * Five TextBoxes for User Application Information (First + Last Name, Street Address,
 * State, Zip Code)
 * Five Labels for said TextBoxes
 * GroupBox to hold prior TextBoxes and Labels
 * ResetFieldsLocation button for resetting the location of the TextBoxes in the GroupBox
 */

namespace UT3___Job_Application_Bad_UX
{
    /* Class: ApplicationInfo
     * Purpose: Hold information and apply methods to User entered information 
     * relating to the User
     * Limitations: none
     */
    public partial class ApplicantInfo : Form
    {
        //keep track of amount of times the user has attempted to submit this form
        private byte attemptedContinues = 0;

        //keep track if the TextBoxs have been reset at all (set to blank)
        private bool boxesReset = false;

        //array for holding all form's TextBox's
        private TextBox[] textBoxs = new TextBox[5];

        //array for holding possible locations of resetFieldLocationButton, and their row indexes
        private int[,] resetFieldLocations = new int[4, 2];
        private byte rflXIndex = 0;
        private byte rflYIndex = 1;

        //start X/Y position of resetFieldLocationButton
        private int resetButtonStartingX;
        private int resetButtonStartingY;

        //Thread object and related information
        private Thread updateThread = null;
        private bool startThread = false;
        private bool stopThread = false;

        //string holding submitted information
        private string firstName;
        private string lastName;
        private string zipCode;
        private string streetAddress;
        private string state;

        //ApplicantQualities object that will be opened upon a succesfull submit
        private ApplicantQualities applicantQualitiesForm;


        /* Constructor Method: ApplicantInfo
         * Purpose: Construct the Form by setting necessary EventHandler's, calling necessary methods, and generally fiddle with 
         * necessary starting variables
         * Limitations: none
         */
        public ApplicantInfo()
        {
            InitializeComponent();

            //set all TextBox's to use same Method
            this.firstNameTextBox.TextChanged += new EventHandler(TextBoxChanged__TextChanged);
            this.lastNameTextBox.TextChanged += new EventHandler(TextBoxChanged__TextChanged);
            this.zipCodeTextBox.TextChanged += new EventHandler(TextBoxChanged__TextChanged);
            this.streetAddressTextBox.TextChanged += new EventHandler(TextBoxChanged__TextChanged);
            this.stateTextBox.TextChanged += new EventHandler(TextBoxChanged__TextChanged);

            //create other necessary EventHandlers
            this.continueButton.Click += new EventHandler(AttemptContinue__Click);

            this.resetTBLocationsButton.Click += new EventHandler(ResetTextBoxLocations__Click);

            this.FormClosing += new FormClosingEventHandler(Form__FormClosing);

            //fill resetButtonStartingX/Y 
            this.resetButtonStartingX = this.resetTBLocationsButton.Location.X;
            this.resetButtonStartingY = this.resetTBLocationsButton.Location.Y;

            //set some form control properties
            this.zipCodeTextBox.Visible = false;
            this.zipCodeLabel.Visible = false; 
            this.resetTBLocationsButton.Visible = false;
            this.richTextBox1.ReadOnly = true;

            //fill the resetFieldLocations array with locations (X and Y points)
            FillResetFieldLocationsArray();

            //fill the textBoxsArray with all TextBoxs
            FillTextBoxsArray();

            //tag every textBox with its location in its tag (if it needs to be reset, we'll use it)
            SetTextBoxLocationsInTags();
        }

        /* Method: TextBoxChanged__TextChanged
         * Purpose: Depending on number of attempted Application submissions from user, mess with the TextBoxs locations
         * Limitations: none
         */
        private void TextBoxChanged__TextChanged(object sender, EventArgs e)
        {
            //do nothing if the user hasn't attempted to hit the continueButton yet
            if(attemptedContinues == 0)
            {
                return;
            }
            //boxes reset will be called only a result of attempting to hit the ContinueButton once, and then only if all TextBox's have Text.
            //essentially, they must fill the Text of every TextBox before this variable is set to true
            else if(attemptedContinues > 0 && !boxesReset)
            {
                //textBoxs is instantiated with all TextBoxes in this form's constructor
                foreach (TextBox tb in textBoxs)
                {
                    //move boxes off screen, and start our thread. streetAddressTextBox is left untouched to annoy the user further
                    if (tb != this.streetAddressTextBox)
                    {
                        //these magic numbers are simply numbers so absurd the TextBox's will be guaranteed to be offscreen
                        tb.Location = new Point(tb.Location.X - 300, tb.Location.Y - 300);

                        //start the thread if it isn't started yet
                        if (tb.Location.X < 0 && startThread == false)
                        {

                            StartThread();

                        }
                    }
                }
            }
        }

        /* Method: AttemptContinue__Click
         * Purpose: "Allow" the user to submit their info to continue their information, but depending on how many times they've tried
         * do various mean things to them instead
         * Limitations: none
         */
        private void AttemptContinue__Click(object sender, EventArgs e)
        {

            switch (attemptedContinues)
            {

                //if this is the first attempt, whipe all TextBox's and increase the counter for attemptedContinues
                //inform user
                case 0:

                    this.richTextBox1.Text = "Sorry, we lost all your data. Please try again.";

                    EmptyTextBoxes();

                    attemptedContinues += 1;

                    break;

                //second attempt
                case 1:

                    //reject the click if any TextBox's are empty, and inform user
                    if (!CheckFieldsFull())
                    {
                        this.richTextBox1.Text = "All fields must be filled!";

                    }

                    //else, add the "missing" textbox, inform user, and wipe everything again. increase attemptedContinues
                    attemptedContinues += 1;

                    this.richTextBox1.Text = "Sorry, we forgot a field. Please try again.";

                    this.zipCodeLabel.Visible = true;
                    this.zipCodeTextBox.Visible = true;

                    EmptyTextBoxes();

                    break;

                //default only if attemptedContinues is >= 2
                default:

                    //return if any TextBox is empty
                    if (!CheckFieldsFull())
                    {
                        this.richTextBox1.Text = "All fields must be filled!";
                        return;
                    }

                    //create the next form object and show it
                    if (this.applicantQualitiesForm == null)
                    {
                        this.applicantQualitiesForm = new ApplicantQualities(this);
                        applicantQualitiesForm.Show();
                    }
                    
                    //save the useful information 
                    SaveInformation();

                    break;
            }
        }

        /* Method: ResetTextBoxLocations__Click
         * Purpose: Resets the locations of the TextBox's to their default
         * Limitations: none
         */
        private void ResetTextBoxLocations__Click(object sender, EventArgs e)
        {
            foreach(TextBox tb in textBoxs)
            {
                tb.Location = (Point)tb.Tag;
            }

            //set bool of boxesReset = true
            boxesReset = true;

            //we can only get this far due to a thread, and its usefulness ends here. So, stop it
            stopThread = true;


        }

        /* Method: StartThread
         * Purpose: Starts our updateThread, which causes the resetTBLocationsButton to move around the screen
         * also updates User of what's going on
         * Limitations: none
         */
        private void StartThread()
        {
            startThread = true;

            //button is set invisible in constructor; reverse it
            resetTBLocationsButton.Visible = true;

            updateThread = new Thread(StartUpdateThread);
            updateThread.Start();
            this.richTextBox1.Text = "If your fields have gone offscreen, hit the Reset button. Please try and be more" +
                "careful next time.";

        }

        
        /* Method: CheckFieldsFull
         * Purpose: Returns a bool checking if all Field's are full prior to showing the zipCodeTextBox
         * Limitations: none
         */
        private bool CheckFieldsFull() 
        {
            foreach (TextBox tb in textBoxs)
            {
                if ((tb.Text == "" || tb.Text == null) && tb != this.zipCodeTextBox)
                {
                    
                    return false ;
                }
            }

            return true;
        }

        /* Method: FillTextBoxsArray
         * Purpose: Helper method that fills the textBoxs array, for decluttering
         * order arbitrary 
         * Limitations: none
         */
        private void FillTextBoxsArray()
        {

            textBoxs[0] = firstNameTextBox;
            textBoxs[1] = lastNameTextBox;
            textBoxs[2] = streetAddressTextBox;
            textBoxs[3] = stateTextBox;
            textBoxs[4] = zipCodeTextBox;
        }

        /* Method: SetTextBoxLocationsInTag
         * Purpose: Helper method that sets the Tag of each TextBox to it's default Location value, for decluttering
         * Limitations: none
         */
        private void SetTextBoxLocationsInTags()
        {
            foreach(TextBox tb in textBoxs)
            {
                tb.Tag = tb.Location;
            }
        }

        /* Method: StartUpdateThread
         * Purpose: Method called by updateThread, calls the MoveResetFieldsButton method every .1 seconds
         * Limitations: none
         */
        private void StartUpdateThread()
        {
            //ensure not called if the thread is stopped
            while (!stopThread)
            {
                MoveResetFieldsButton();
                Thread.Sleep(100);
            }
        }

        /* Method: MoveResetFieldsButton
         * Purpose: Shuffles the location of the resetTBLocationsButton. Called via Thread
         * Limitations: none
         */
        private void MoveResetFieldsButton()
        {
            //we need to use Invoke to change the button's location in the UI thread, so ensure we have the requirements to do so
            if (this.InvokeRequired)
            {
                //loop through the resetFieldLocations array to get set location possibilities, going in order
                for (int r = 0; r < resetFieldLocations.GetLength(0); r++)
                {

                    //when the array ligns up with current location, set current location to next in line in array
                    if (resetTBLocationsButton.Location == new Point(resetFieldLocations[r, 0], resetFieldLocations[r, 1]))
                    {
                        if (r == resetFieldLocations.GetLength(0) - 1)
                        {
                            r = 0;
                        }
                        else
                        {
                            r += 1;
                        }

                        //add to UI thread this Action
                        this.Invoke(new Action(() =>
                        {
                            resetTBLocationsButton.Location = new Point(resetFieldLocations[r, 0], resetFieldLocations[r, 1]);
                        }));
                        

                        return;
                    }

                }
            }
        }

        /* Method: FillResetFieldLocationsArray
         * Purpose: Sets the resetFieldLocationsArray's values to represent X/Y points
         * order arbitrary 
         * Limitations: none
         */
        private void FillResetFieldLocationsArray()
        {
            this.resetFieldLocations[0, rflXIndex] = this.resetButtonStartingX;
            this.resetFieldLocations[0, rflYIndex] = this.resetButtonStartingY;
            this.resetFieldLocations[1, rflXIndex] = 12;
            this.resetFieldLocations[1, rflYIndex] = 114;
            this.resetFieldLocations[2, rflXIndex] = 12;
            this.resetFieldLocations[2, rflYIndex] = 309;
            this.resetFieldLocations[3, rflXIndex] = 231;
            this.resetFieldLocations[3, rflYIndex] = 309;

        }

        /* Method: Form__FormClosing
         * Purpose: abort the updateThread on this form closing
         * Limitations: none
         */
        private void Form__FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updateThread != null)
            {
                stopThread = true;
                updateThread.Abort();
            }
        }

        /* Method: EmptyTextBoxes
         * Purpose: Set the Text of all TextBoxs to "". In addition, if the attemptContinues = 1, call ResetTextBoxLocation 
         * Limitations: none
         */
        private void EmptyTextBoxes()
        {
            foreach (TextBox tb in textBoxs)
            {
                tb.Text = "";

                if (attemptedContinues == 1)
                {
                    ResetTextBoxLocation(tb);
                }
            }
        }

        /* Method: ResetTextBoxLocation
         * Purpose: Accepts a TextBox, and sets its location equal to the Location stored in its Tag (done in constructor
         * Limitations: none
         */
        private void ResetTextBoxLocation(TextBox textBox)
        {
            
            {
                textBox.Location = (Point)textBox.Tag;
            }
        }

        /* Method: SaveInformation
         * Purpose: Save the information of the TextBox's Text in a string
         * Limitations: none
         */
        private void SaveInformation()
        {
            this.firstName = this.firstNameTextBox.Text;
            this.lastName = this.lastNameTextBox.Text;
            this.zipCode = this.zipCodeTextBox.Text;
            this.streetAddress = this.streetAddressTextBox.Text;
            this.state = this.stateTextBox.Text;
        }

        /* Method: GetFirstName
         * Purpose: returns this.firstName
         * Limitations: none
         */
        public string GetFirstName()
        {
            return this.firstName;
        }


        /* Method: GetLastName
         * Purpose: returns this.lastName
         * Limitations: none
         */
        public string GetLastName()
        {
            return this.lastName;
        }

        /* Method: GetZipCode
         * Purpose: returns this.zipCode
         * Limitations: none
         */
        public string GetZipCode()
        {
            return this.zipCode;
        }

        /* Method: GetStreetAddress
         * Purpose: returns this.streetAddress
         * Limitations: none
         */
        public string GetStreetAddress()
        {
            return this.streetAddress;
        }

        /* Method: GetState
         * Purpose: returns this.state
         * Limitations: none
         */
        public string GetState()
        {
            return this.state;
        }

        /* Method: ProcessCmdKey
         * Purpose: Reject any attempts to user the Enter button to hit a Button (perhaps, say, any button that's changing its location every .1 seconds?
         * Limitations: none
         */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                //check if the currently focused control is a button and suppress it if so
                if (ActiveControl is Button)
                {
                    
                    return true; 
                }
            }

            //otherwise, act as normal
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
