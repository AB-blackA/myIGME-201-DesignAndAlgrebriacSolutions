using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Author: Andrew Black since 12/2/23
 * Purpose: Qualifications form of a Mock Job Application Form with a purposefully bad UX for IGME-201 Unit Test 3
 * Limitations: none
 */

/* Form Controls:
 * Form to hold controls
 * RichTextField to display info to user
 * ContinueButton to "allow" user to continue
 * Six CheckBoxes representing Programming Fields
 * Six RadioButtons representing Experience in Software Engineer in years
 * CheckBoxesGroupBox to hold CheckBoxes
 * Label for CheckBoxesGroupBox 
 * Five group boxes to hold one RadioButton each (yes, for real). More below
 * RadioButtonGroupBox to hold said groupboxes
 * Label for RadioButtonGroupBox
 * 
 * To enhance the awfulness of this UX, the RadioButton's are in individual GroupBoxes to act similar to CheckBoxs
 * and the CheckBoxs.Checked EventHandler behaves in such a way that all CheckBoxs essentially acted as RadioButtons.
 */

namespace UT3___Job_Application_Bad_UX
{

    /* Class: ApplicantQualities
     * Purpose: Hold relevant information regarding applicant qualities, form controls, and processes for making the applicant's submitting experience
     * miserable
     * Limitations: none
     */
    public partial class ApplicantQualities : Form
    {
        //arrays for all CheckBox's and RadioButton's
        private CheckBox[] checkBoxs = new CheckBox[6];
        private RadioButton[] radioButtons = new RadioButton[6];

        //bool for if application is acceptible
        private bool applicationAcceptible = false;

        //strings for unnacceptable first names, unless they have the lastName that overrides that exception
        private const string UnacceptableFirstName = "Dave";
        private const string LastNameOverrideFirstNameException = "Schuh";

        //bools for checking if the user checked off qualifications later form will care about (all others are irrelevant)
        private bool uxDesignerChecked = false;
        private bool tenPlusChecked = false;

        //scaleFactor by why Font will be scaled
        private const byte FontSizeFactor = 4;

        //reference to the form that opened this form
        private ApplicantInfo applicantInfoRef;

        //ApplicantResume object that will be opened upon a succesful submission
        private ApplicantResume applicantResumeForm;

        //random object
        private Random random = new Random();


        /* Constructor Method: ApplicantQualities
         * Purpose: Create's this form, fiddles with any necessary starting data, and creates EventHandlers for controls
         * Limitations: none
         */
        public ApplicantQualities(ApplicantInfo applicantInfo)
        {
            InitializeComponent();

            //reference to the form that created this one
            this.applicantInfoRef = applicantInfo;

            //create EventHandler for all CheckBox's CheckedChanged event, which all use the same method
            this.oopCheckBox.CheckedChanged += new EventHandler(CheckBox__CheckedChanged);
            this.dataStructuresCheckBox.CheckedChanged += new EventHandler(CheckBox__CheckedChanged);
            this.uiCheckBox.CheckedChanged += new EventHandler(CheckBox__CheckedChanged);
            this.uxCheckBox.CheckedChanged += new EventHandler(CheckBox__CheckedChanged);
            this.backendCheckBox.CheckedChanged += new EventHandler(CheckBox__CheckedChanged);
            this.fullStackCheckBox.CheckedChanged += new EventHandler(CheckBox__CheckedChanged);

            //create EventHandler for all RadioButton's CheckedChanged event, which all use the same method
            this.zeroRadioButton.CheckedChanged += new EventHandler(RadioButton__CheckedChanged);
            this.oneTwoRadioButton.CheckedChanged += new EventHandler(RadioButton__CheckedChanged);
            this.threeFourRadioButton.CheckedChanged += new EventHandler(RadioButton__CheckedChanged);
            this.fiveSevenRadioButton.CheckedChanged += new EventHandler(RadioButton__CheckedChanged);
            this.eightNineRadioButton.CheckedChanged += new EventHandler(RadioButton__CheckedChanged);
            this.tenPlusRadioButton.CheckedChanged += new EventHandler(RadioButton__CheckedChanged);

            //continueButton.Click EventHandler 
            this.continueButton.Click += new EventHandler(ContinueButton__Click);

            //set default text for richTextBox and set it to read only
            this.richTextBox1.Text = "When ready, hit Continue";
            this.richTextBox1.ReadOnly = true;

            //fill array objects
            FillArrays();
        }

        /* Method: Fill Arrays
         * Purpose: Fills the checkBoxs and radioButtons arrays with all the form's CheckBoxs and RadioButtons
         * order arbitrary 
         * Limitations: none
         */

        private void FillArrays()
        {
           
            checkBoxs[0] = this.oopCheckBox;
            checkBoxs[1] = this.dataStructuresCheckBox;
            checkBoxs[2] = this.uiCheckBox;
            checkBoxs[3] = this.uxCheckBox;
            checkBoxs[4] = this.backendCheckBox;
            checkBoxs[5] = this.fullStackCheckBox;

            radioButtons[0] = this.zeroRadioButton;
            radioButtons[1] = this.oneTwoRadioButton;
            radioButtons[2] = this.threeFourRadioButton;
            radioButtons[3] = this.fiveSevenRadioButton;
            radioButtons[4] = this.eightNineRadioButton;
            radioButtons[5] = this.tenPlusRadioButton;
        }

        /* Method: RadioButton__CheckedChanged
         * Purpose: Upon being called, randomizes the Text.Font.Color of all RadioButtons and TextBoxs
         * Limitations: none
         */
        private void RadioButton__CheckedChanged(object sender, EventArgs e)
        {

            //start randomizing using GetRandomColor()
            foreach(RadioButton rb in radioButtons)
            {
                rb.ForeColor = GetRandomColor();
            }

            foreach(CheckBox cb in checkBoxs)
            {
                cb.ForeColor = GetRandomColor();
            }

            
        }

        /* Method: CheckBox__CheckedChanged
         * Purpose: Messes with the font size of the CheckBoxs to be virtually unreadable. Additionally, completely
         * ruins the points of CheckBoxs by making it so they act like RadioButtons
         * Limitations: none
         */
        private void CheckBox__CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            //do nothing if caller was Unchecked
            if (cb.Checked)
            {
                //provided the sender wasn't somehow called while already checked, find the last/any checked CheckBoxs and uncheck them
                //making them act similar to RadioButtons. If they don't get unchecked, mess with their font
                foreach (CheckBox checkBox in checkBoxs)
                {
                    
                    if (checkBox != cb && checkBox.Checked)
                    {
                        checkBox.Checked = false;
                    }

                    //using our FontSizeFactor, shrink the font of the CheckBox to be illegible unless it would cause the font size to be less than zero.
                    //if so, increase it instead (it won't be much better, I promise)
                    else
                    {
                        if(checkBox.Font.Size - FontSizeFactor > 0)
                        {
                            checkBox.Font = new Font(checkBox.Font.FontFamily, checkBox.Font.Size - FontSizeFactor, checkBox.Font.Style);
                        }
                        else
                        {
                            checkBox.Font = new Font(checkBox.Font.FontFamily, checkBox.Font.Size + FontSizeFactor, checkBox.Font.Style);
                        }
                    }
                }
            }

        }

        /* Method: GetRandomColor
         * Purpose: Based off Random.Next, generated RGB values and return as a Color
         * Limitations: none
         */
        private Color GetRandomColor()
        {
            int redValue = random.Next(0, 256);
            int greenValue = random.Next(0, 256);
            int blueValue = random.Next(0, 256);

            return Color.FromArgb(redValue, greenValue, blueValue);
        }

        /* Method: ContinueButton__Click
         * Purpose: Provided criteria is met, allow the User to continue to the next form. If critier isn't met, Uncheck their Checked RadioButtons and CheckBoxs
         * to cause suffering
         * Limitations: none
         */
        private void ContinueButton__Click(object sender, EventArgs e)
        {
            //ensure we can accept application!
            this.applicationAcceptible = EnsureAcceptability();

            if (applicationAcceptible)
            {

                //if so, create the next form and pass this form in as constructor
                if(this.applicantResumeForm == null)
                {
                    applicantResumeForm = new ApplicantResume(this);
                    applicantResumeForm.Show();
                }

                //save relevant information
                SaveInformation();

            }

            //if unacceptable, uncheck all their buttons and display the criteria to continue
            else
            {
                UncheckAll();
                this.richTextBox1.Text = "Sorry, but something was wrong with your application. Check to ensure that:\n" +
                    "1. Only one Button for Years of Experience is Checked\n" +
                    "2. At least one button for Role Experience is Checked (we encourage checking as many as possible)\n" +
                    "3. Your ZipCode field in the prior form is valid\n " +
                    "4. Your name isn't Dave. The last Dave we had didn't work out (unless your last name is also Schuh, we heard he's pretty cool)\n" +
                    "\nYou can update your last form by hitting its \"Continue\" Button";
            }
        }

        /* Method: UncheckAll
         * Purpose: Sets the Checked property of all CheckBoxs and RadioButtons to false
         * Limitations: none
         */
        private void UncheckAll()
        {
            foreach(RadioButton radioButton in radioButtons)
            {
                radioButton.Checked = false;
            }

            foreach(CheckBox checkBox in checkBoxs)
            {
                checkBox.Checked = false;
            }
        }

        /* Method: EnsureAcceptability
         * Purpose: Checks certain criteria and returns a bool depending on results. We can't have poor applicants, after all!
         * Limitations: none
         */
        private bool EnsureAcceptability()
        {
            //bytes to hold how many of each Check-able object is checked
            byte onlyOneRadioButtonChecked = 0;
            byte atLeastOneCheckBoxChecked = 0;

            //count how many RadioButtons are checked
            foreach (RadioButton rb in radioButtons)
            {
                if(rb.Checked)
                {
                    onlyOneRadioButtonChecked++;
                }

            }

            //count how many CheckBoxs are checked
            foreach (CheckBox cb in checkBoxs)
            {
                if (cb.Checked)
                {
                    atLeastOneCheckBoxChecked++;
                }
            }

            //criteria is such that only one RadioButton can be checked, and a CheckBox must be checked. If not, reject!
            if (onlyOneRadioButtonChecked != 1 && atLeastOneCheckBoxChecked < 1)
            {
                return false;
            }

            //check previous Form info for their first name. If it's the UnnacceptableFirstName without the LastNameOverride, reject!
            if (applicantInfoRef.GetFirstName() == UnacceptableFirstName)
            {
                if (applicantInfoRef.GetLastName() != LastNameOverrideFirstNameException)
                {
                    return false;
                }
            }

            //get the applicants zipCode from prior form
            string applicantZip = applicantInfoRef.GetZipCode();

            //if not a proper US zip code, reject!
            if (!applicantZip.All(char.IsDigit) && (applicantZip.Length != 9 || applicantZip.Length != 5)) 
            {
                return false;
            }

            //if they pass, accept!
            return true;
        }

        /* Method: SaveInformation
         * Purpose: Sets the bools that care about a specific CheckBox and RadioButton being checked to true or false depending on state
         * Limitations: none
         */
        private void SaveInformation()
        {

            this.tenPlusChecked = this.tenPlusRadioButton.Checked;
            this.uxDesignerChecked = this.uxCheckBox.Checked;
        }

        /* Method: TenPlusExperience
         * Purpose: Returns this.tenPlusChecked
         * Limitations: none
         */
        public bool TenPlusExperience()
        {
            return this.tenPlusChecked;
        }

        /* Method: UXDesignerExperience
         * Purpose: Returns this.uxDesignerChecked
         * Limitations: none
         */
        public bool UXDesignerExperience()
        {
            return this.uxDesignerChecked;
        }

        
    }

    
}
