using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

/* Author: Andrew Black
 * Class: Form1
 * Purpose: Creation of a game where the user has to guess certain US President's Order (in way of election history)
 * Limitations: Requires User to have an Internet connection to properly visit certain webpages
 */

/* Form Controls:
1. Form that holds components and is the “game” window
2. Group Box that holds all President-related Information (Radio Buttons, Text Fields, Picture Box)
3. Group Box that holds Filter information (filter Presidents by Party)
4. Group Box that holds all WebBrowser related Information
5-20: Radio Buttons for each President included in the game
21-36: Text Fields for each president
37-52: Radio Buttons for Each Filter Option in Filter Group Box
53. PictureBox that changes to show the selected President (based on President Radio Button’s)
54: Error Provider for when a Player inserts a wrong value into a text field
55. Exit Button (close application)
56: Timer for the game
57: Status Strip to hold a toolStripProgressBar (to work with timer)
58: Aforementioned toolStripProgressBar
59: WebBrowserControl that allows Users to see the Wikipedia Page of the President’s they’ve selected
60. ToolTip when the User hovers over TextBox’s to prompt them to answer “Which # President?”
*/

namespace UT3___President_s
{
    /* Class: Form1
     * Purpose: Form that holds all useful controls and data types for the exe
     * Limitations: none
     */
public partial class Form1 : Form
    {

        //arrays for holding information related to president's (including name, order, jpg location, web page, and party affiliation)
        //as well as for radioButtons and textBoxes
        private string[,] presidentInformation = new string[16, 5];
        private RadioButton[] presidentRadioButtons = new RadioButton[16];
        private TextBox[] presidentTextBoxes = new TextBox[16];

        //Timer and bool for it
        private Timer timer;
        private bool timerStarted;

        //factor by which President picture will be scaled when scaled
        private float pictureBoxScaleFactor = 2.5f;

        //progressBar values
        private const int ProgressBarMax = 120;
        private int progressBarValue = ProgressBarMax;

        //indexes for each president in presidentInformation
        public const byte BenHarrisonRowIndex = 0;
        public const byte FdrRowIndex = 1;
        public const byte BillClintonRowIndex = 2;
        public const byte JamesBuchananRowIndex = 3;
        public const byte FrankPierceRowIndex = 4;
        public const byte GeorgeWBushRowIndex = 5;
        public const byte ObamaRowIndex = 6;
        public const byte JfkRowIndex = 7;
        public const byte WillMcKinleyRowIndex = 8;
        public const byte ReaganRowIndex = 9;
        public const byte EisenhowerRowIndex = 10;
        public const byte VanBurenRowIndex = 11;
        public const byte GeorgeWashingtonRowIndex = 12;
        public const byte JohnAdamsRowIndex = 13;
        public const byte TeddyRooseveltRowIndex = 14;
        public const byte JeffersonRowIndex = 15;

        //indexes for each column in presidentInformation
        public const byte NameColumnIndex = 0;
        public const byte ImageColumnIndex = 1;
        public const byte OrderColumnIndex = 2;
        public const byte WebPageColumnIndex = 3;
        public const byte PartyColumnIndex = 4;

        //RadioButtons/TextBox for active of each group
        private RadioButton activePresRB;
        private RadioButton activeFilterRB;
        private TextBox activeTB;

        //variables for controlling functions of game depending on the state. Both need to be false to start.
        //notably, gameStart needs to be false to start so certain starting methods run properly
        private bool lockUser = false;
        private bool gameStart = false;

        //string of the winning url
        private string winningUrl = "https://media.giphy.com/media/TmT51OyQLFD7a/giphy.gif";

        /* Method: Form1
         * Purpose: Construct the form, including EventHandler, starting states of certain controls, 
         * and calling necessary methods for the game to run
         * Limiations: none
         */
        public Form1()
        {
            InitializeComponent();

            //all president radio button CheckedChanged EventHandlers use the same method
            this.benHarrisonRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton__CheckedChanged);
            this.fdrRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton__CheckedChanged);
            this.billClintonRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton__CheckedChanged);
            this.jamesBuchananRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton__CheckedChanged);
            this.frankPierceRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton__CheckedChanged);
            this.georgeWBushRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton__CheckedChanged);
            this.obamaRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton__CheckedChanged);
            this.jfkRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton__CheckedChanged);
            this.willMcKinleyRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton__CheckedChanged);
            this.reaganRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton__CheckedChanged);
            this.eisenhowerRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton__CheckedChanged);
            this.vanBurenRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton__CheckedChanged);
            this.georgeWashingtonRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton__CheckedChanged);
            this.johnAdamsRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton__CheckedChanged);
            this.teddyRooseveltRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton__CheckedChanged);
            this.jeffersonRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton__CheckedChanged);

            //all president TextBox TextChanged EventHandlers use the same method
            this.benHarrisTextBox.TextChanged += new EventHandler(PresidentTextBox__TextChanged);
            this.fdrTextBox.TextChanged += new EventHandler(PresidentTextBox__TextChanged);
            this.billClintonTextBox.TextChanged += new EventHandler(PresidentTextBox__TextChanged);
            this.jamesBuchananRadioButton.CheckedChanged += new EventHandler(PresidentTextBox__TextChanged);
            this.frankPierceTextBox.TextChanged += new EventHandler(PresidentTextBox__TextChanged);
            this.georgeWBushTextBox.TextChanged += new EventHandler(PresidentTextBox__TextChanged);
            this.obamaTextBox.TextChanged += new EventHandler(PresidentTextBox__TextChanged);
            this.jfkTextBox.TextChanged += new EventHandler(PresidentTextBox__TextChanged);
            this.willMcKinleyTextBox.TextChanged += new EventHandler(PresidentTextBox__TextChanged);
            this.reaganTextBox.TextChanged += new EventHandler(PresidentTextBox__TextChanged);
            this.eisenhowerTextBox.TextChanged += new EventHandler(PresidentTextBox__TextChanged);
            this.vanBurenTextBox.TextChanged += new EventHandler(PresidentTextBox__TextChanged);
            this.georgeWashingtonTextBox.TextChanged += new EventHandler(PresidentTextBox__TextChanged);
            this.johnAdamsTextBox.TextChanged += new EventHandler(PresidentTextBox__TextChanged);
            this.teddyRooseveltTextBox.TextChanged += new EventHandler(PresidentTextBox__TextChanged);
            this.jeffersonTextBox.TextChanged += new EventHandler(PresidentTextBox__TextChanged);

            //both presidentPictureBox MouseHover and MouseLeave use the same method for their EventHandler
            this.presidentPictureBox.MouseHover += new EventHandler(PresidentPictureBox__MouseHover);
            this.presidentPictureBox.MouseLeave += new EventHandler(PresidentPictureBox_MouseLeave);

            //all filter RadioButtons CheckedChanged EventHandler use the same method
            this.filterDemRadioButton.CheckedChanged += new EventHandler(FilterRadioButton__CheckedChanged);
            this.filterRepublicanRadioButton.CheckedChanged += new EventHandler(FilterRadioButton__CheckedChanged);
            this.filterFederalistRadioButton.CheckedChanged += new EventHandler(FilterRadioButton__CheckedChanged);
            this.filterDemRepublicanRadioButton.CheckedChanged += new EventHandler(FilterRadioButton__CheckedChanged);
            this.filterAllRadioButton.CheckedChanged += new EventHandler(FilterRadioButton__CheckedChanged);

            //exitbutton EventHandler for leaving the game
            this.exitButton.Click += new EventHandler(ExitButton__Click);

            //initialize some aspects of some of the controls
            this.presidentPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.exitButton.Enabled = false;
            this.toolTip1.IsBalloon = true;

            //call methods to start game
            FillArrays();
            TagPresidentsInTextBoxes();
            ZeroPresidentTextBoxes();
            SetPresidentTextBoxesHoverText();
            ResetProgressBar();

            SetActiveFilterRadioButton(this.filterAllRadioButton);
            SetActivePresidentRadioButton(this.benHarrisonRadioButton);

            //start game
            gameStart = true;


        }

        /* Method: ExitButton__Click
         * Purpose: Exit the Application
         * Limiations: none
         */
        private void ExitButton__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /* Method: PresidentRadioButton__CheckedChange
         * Purpose: Accept a President RadioButton EventHandler and change aspects of the form based on it
         * Limitations: none
         */
        private void PresidentRadioButton__CheckedChanged(object sender, EventArgs e)
        {
            //do nothing if game hasn't started yet
            if (!gameStart)
            {
                return;
            }

            //ensure proper object type
            if(sender.GetType() == typeof(RadioButton))
            {

                RadioButton radioButton = (RadioButton)sender;

                //if the user is locked and this radioButton isn't the active one, uncheck this RadioButton and Check the Active
                if (lockUser && radioButton != activePresRB)
                {
                    radioButton.Checked = false;
                    activePresRB.Checked = true;
                    return;
                }
                //otherwise, if locked and this is the active, return to prevent webpage from reloading 
                else if (lockUser)
                {
                    return;
                }

                //if not locked, set this radiobutton as the activePresRB
                SetActivePresidentRadioButton(radioButton);

                //find where this president's column is in presidentInformation based on this RadioButton's text
                //when found, change the picture, webpage, and webBrowserGroupBox to reflect aspects of President
                for (int r = 0; r < presidentInformation.GetLength(0); r++)
                {
    
                    if(radioButton.Text == presidentInformation[r, NameColumnIndex])
                    {
                        
                        this.presidentPictureBox.Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, presidentInformation[r, ImageColumnIndex]));
                        this.webBrowser1.Navigate(presidentInformation[r, WebPageColumnIndex]);
                        this.webBrowserGroupBox.Text = presidentInformation[r, WebPageColumnIndex];
                        
                    }
                }
            }
          
            
        }

        /* Method: FilterRadioButton__CheckedChanged
         * Purpose: Accept a Filter RadioButton's CheckedChanged EventHandler and change aspects of the form based on it
         * Limitations: none
         */
        private void FilterRadioButton__CheckedChanged(object sender, EventArgs e)
        {
            //do nothing if game hasn't started
            if (!gameStart)
            {
                return;
            }

            //ensure sender is of proper type
            if (sender.GetType() == typeof(RadioButton))
            {


                RadioButton radioButton = (RadioButton)sender;

                //if the user is locked and this RadioButton isn't the activeFilterRB, uncheck this RadioButton and check
                //the active one to prevent the active one from being hidden
                if (lockUser && radioButton != activeFilterRB)
                {
                    radioButton.Checked = false;
                    activeFilterRB.Checked = true;
                    return;
                }

                //set active this RadioButton as the activeFilterRB
                SetActiveFilterRadioButton(radioButton);

                //get the party from the RadioButton via its Text
                string party = radioButton.Text;

                
                //if party isn't All, set visible only the ones with party affiliation matching string party
                if (party != "All")
                {
                    //loop through the presidentInformation partyColumn for each president
                    for (int r = 0; r < presidentInformation.GetLength(0); r++)
                    {

                        //if party isn't a match, find that president's RadioButton and TextBox in their respective
                        //arrays and set visibility to false.
                        if (presidentInformation[r, PartyColumnIndex] != party)
                        {
                            
                            presidentRadioButtons[r].Visible = false;
                            presidentTextBoxes[r].Visible = false;

                        }
                        //else, set visibility to true
                        else
                        {
                            presidentRadioButtons[r].Visible = true;
                            presidentTextBoxes[r].Visible = true;
                        }
                    }
                }
                //if string party is "All", set visible all RadioButton's and TextBoxes
                else
                {
                    foreach (RadioButton rb in presidentRadioButtons)
                    {
                        rb.Visible = true;
                    }

                    foreach (TextBox tb in presidentTextBoxes)
                    {
                        tb.Visible = true;
                    }
                }
            }
                
        }

        /* Method: PresidentPictureBox__MouseHover
         * Purpose: Accepts PresidentPictureBox's MouseHover EventHandler and enlarges the current president's image
         * Limiations: none
         */
        private void PresidentPictureBox__MouseHover(object sender, EventArgs e)
        {
            //store original size of presidentPictureBox in its Tag property if it's not null
            if (presidentPictureBox.Tag == null)
            {
                presidentPictureBox.Tag = presidentPictureBox.Size;
            }

            //Increase it's size
            presidentPictureBox.Size = new Size((int)(presidentPictureBox.Width * pictureBoxScaleFactor), (int)(presidentPictureBox.Height * pictureBoxScaleFactor));
        }

        /* Method: PresidentPictureBox_MouseLeave
         * Purpose: Accepts PresidentPictureBox's MouseLeave EventHandler and resets the current president's image size
         * Limiations: none
         */
        private void PresidentPictureBox_MouseLeave(object sender, EventArgs e)
        {
            //check if the tag of the presidentPictureBox isn't empty. If so, that means it was once enlarged and has a Size property
            //containing information for its original size in it. Then, set the picturebox's size to that
            if (presidentPictureBox.Tag != null)
            {
                presidentPictureBox.Size = (Size)presidentPictureBox.Tag;
                presidentPictureBox.Tag = null;
            }
        }

        /* Method: PresidentTextBox__TextChanged
         * Purpose: Accept's President TextBox's TextChanged EventHandler and uses that information to determine if the user
         * has entered a value correct to that President's correct order in Presidency. Depending on result, affect the game
         * Limitations: none
         */
        private void PresidentTextBox__TextChanged(object sender, EventArgs e)
        {

            //do nothing if game hasn't started yet
            if (!gameStart)
            {
                return;
            }

            //ensure proper sender
            if (sender.GetType() == typeof(TextBox))
            {

                //start the timer if it's not started yet. StartTimer() will set timerStarted = true
                if (!timerStarted)
                {
                    StartTimer();
                }

                //cast sender as textbox
                TextBox tb = (TextBox)sender;

                //if the user isn't locked, set this textbox as the active one
                if (!lockUser)
                {
                    SetActiveTextBox(tb);
                }

                //if the user is locked and this textbox isn't the active one, do nothing and return
                if (lockUser && tb != activeTB)
                {
                    return;
                }


                //find the index of this textbox's President 
                int presidentIndex = 0;

                for (int i = 0; i < presidentInformation.GetLength(0); i++)
                {
                    //recall we set each TextBox to hold the RadioButton of its related president in its Tag
                    if (presidentInformation[i, 0] == ((RadioButton)tb.Tag).Text)
                    {
                        presidentIndex = i;
                    }
                }

                //try catch to ensure tb.Text is only digits. If not, remove none-digits
                try
                {
                    tb.Text = (Int32.Parse(tb.Text)).ToString();
                }
                catch
                {

                    string digitsOnly = "";

                    foreach(Char c in tb.Text)
                    {
                        if (Char.IsDigit(c))
                        {
                            digitsOnly += "" + c;
                        }
                    }

                    tb.Text = digitsOnly;
                }

                

                //if the user entered in the wrong answer, disable other TextBoxs, set out errorProvider on tb and inform of wrong answer,
                //and lock user
                if (tb.Text != presidentInformation[presidentIndex, OrderColumnIndex])
                {
                    this.errorProvider1.SetError(tb, "That is the wrong answer");
                    lockUser = true;
                    DisableNonActiveTextBoxs();
                }
                //otherwise, do the opposite and check for a win
                else
                {
                    this.errorProvider1.Clear();
                    lockUser = false;
                    EnableTextBoxs();
                    CheckForWin();
                }
            }
        }

        /* Help Method: FillArrays
         * Purpose: Call all Methods that FillArrays (for decluttering)
         * Limitations: none
         */
        private void FillArrays()
        {
            FillPresidentInformation();
            FillPresidentRadioButtons();
            FillPresidentTextBoxes();
            TagPresidentsInTextBoxes();
        }

        /* Method: FillPresidentRadioButtons
         * Purpose: Fill presidentRadioButtons array manually for all RadioButton's related to presidents
         * 
         * Limitations: none
         */
        private void FillPresidentRadioButtons()
        {
            presidentRadioButtons[BenHarrisonRowIndex] = this.benHarrisonRadioButton;
            presidentRadioButtons[FdrRowIndex] = this.fdrRadioButton;
            presidentRadioButtons[BillClintonRowIndex] = this.billClintonRadioButton;
            presidentRadioButtons[JamesBuchananRowIndex] = this.jamesBuchananRadioButton;
            presidentRadioButtons[FrankPierceRowIndex] = this.frankPierceRadioButton;
            presidentRadioButtons[GeorgeWBushRowIndex] = this.georgeWBushRadioButton;
            presidentRadioButtons[ObamaRowIndex] = this.obamaRadioButton;
            presidentRadioButtons[JfkRowIndex] = this.jfkRadioButton;
            presidentRadioButtons[WillMcKinleyRowIndex] = this.willMcKinleyRadioButton;
            presidentRadioButtons[ReaganRowIndex] = this.reaganRadioButton;
            presidentRadioButtons[EisenhowerRowIndex] = this.eisenhowerRadioButton;
            presidentRadioButtons[VanBurenRowIndex] = this.vanBurenRadioButton;
            presidentRadioButtons[GeorgeWBushRowIndex] = this.georgeWashingtonRadioButton;
            presidentRadioButtons[JohnAdamsRowIndex] = this.johnAdamsRadioButton;
            presidentRadioButtons[TeddyRooseveltRowIndex] = this.teddyRooseveltRadioButton;
            presidentRadioButtons[JeffersonRowIndex] = this.jeffersonRadioButton;
        }

        /* Method: FillPresidentTextButtons
         * Purpose: Fill presidentTextButtons array manually for all TextBox's related to presidents
         * Limitations: none
         */
        private void FillPresidentTextBoxes()
        {
            presidentTextBoxes[BenHarrisonRowIndex] = this.benHarrisTextBox;
            presidentTextBoxes[FdrRowIndex] = this.fdrTextBox;
            presidentTextBoxes[BillClintonRowIndex] = this.billClintonTextBox;
            presidentTextBoxes[JamesBuchananRowIndex] = this.jamesBuchanaTextBox;
            presidentTextBoxes[FrankPierceRowIndex] = this.frankPierceTextBox;
            presidentTextBoxes[GeorgeWBushRowIndex] = this.georgeWBushTextBox;
            presidentTextBoxes[ObamaRowIndex] = this.obamaTextBox;
            presidentTextBoxes[JfkRowIndex] = this.jfkTextBox;
            presidentTextBoxes[WillMcKinleyRowIndex] = this.willMcKinleyTextBox;
            presidentTextBoxes[ReaganRowIndex] = this.reaganTextBox;
            presidentTextBoxes[EisenhowerRowIndex] = this.eisenhowerTextBox;
            presidentTextBoxes[VanBurenRowIndex] = this.vanBurenTextBox;
            presidentTextBoxes[GeorgeWashingtonRowIndex] = this.georgeWashingtonTextBox;
            presidentTextBoxes[JohnAdamsRowIndex] = this.johnAdamsTextBox;
            presidentTextBoxes[TeddyRooseveltRowIndex] = this.teddyRooseveltTextBox;
            presidentTextBoxes[JeffersonRowIndex] = this.jeffersonTextBox;

        }

        /* Method: TagPresidentsInTextButtons
         * Purpose: Set the Tag of each PresidentTextBox to hold its pairing PresidentRadioButton
         * Limitations: none
         */
        private void TagPresidentsInTextBoxes()
        {
            benHarrisTextBox.Tag = benHarrisonRadioButton;
            fdrTextBox.Tag = fdrRadioButton;
            billClintonTextBox.Tag = billClintonRadioButton;
            jamesBuchanaTextBox.Tag = jamesBuchananRadioButton;
            frankPierceTextBox.Tag = frankPierceRadioButton;
            georgeWBushTextBox.Tag = georgeWBushRadioButton;
            obamaTextBox.Tag = obamaRadioButton;
            jfkTextBox.Tag = jfkRadioButton;
            willMcKinleyTextBox.Tag = willMcKinleyRadioButton;
            reaganTextBox.Tag = reaganRadioButton;
            eisenhowerTextBox.Tag = eisenhowerRadioButton;
            vanBurenTextBox.Tag = vanBurenRadioButton;
            georgeWashingtonTextBox.Tag = georgeWashingtonRadioButton;
            johnAdamsTextBox.Tag = johnAdamsRadioButton;
            teddyRooseveltTextBox.Tag = teddyRooseveltRadioButton;
            jeffersonTextBox.Tag = jeffersonRadioButton;
        }

        /* Method: ZeroPresidentTextBoxes
         * Purpose: Set the intial Text of all President TextBox's to zero
         * Limitations: none
         */
        private void ZeroPresidentTextBoxes()
        {
            //loop through presidentTextBoxes and zero each one's Text
            try
            {
                foreach(TextBox tb in presidentTextBoxes)
                {
                    tb.Text = "0";
                }
            }
            catch
            {
                MessageBox.Show("Error. Can't ZeroPresidentTextBoxes");
            }
        }

        /* Method: StartTimer
         * Purpose: Starts the timer and changes any other relevant information related to it
         * Limitations: none
         */
        private void StartTimer()
        {

            //create new timer, set interval to one second, create Timer_Tick  handler, Start timer, and change
            //value of timerStarted = true
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            timerStarted = true;
        }

        /* Delagte Method: Timer_Tick
         * Purpose: Handle's the Tick event of Timer (every one second is called)
         * Limitations: none
         */
        private void Timer_Tick(object sender, EventArgs e)
        {

            //set the progressBar1.Value -= 1, then if it's zero call TimeOut
            this.progressBar1.Value -= 1;
            if(this.progressBar1.Value <= 0)
            {
                TimeOut();
            }
        }

        /* Method: TimeOut
         * Purpose: Reset the Game in the event the user ran out of time
         * Limitations: none
         */
        private void TimeOut()
        {
            //unlock user and "unstart" the game
            gameStart = false;
            lockUser = false;

            //call some methods that need resetting
            ResetProgressBar();
            ZeroPresidentTextBoxes();

            //stop the timer and set bool to false
            timer.Stop();
            timerStarted = false;

            //clear any errors
            this.errorProvider1.Clear();

            //enable all textboxs then start the game
            EnableTextBoxs();
            gameStart = true;
        }

        /* Method: ResetProgressBar
         * Purpose: Reset's the Value of the progressBar to the maximum when called
         * Limitations: none
         */
        private void ResetProgressBar()
        {

            this.progressBar1.Maximum = ProgressBarMax;
            this.progressBar1.Value = progressBarValue;
        }

        /* Method: SetActiveTextBox
         * Purpose: Accept a TextBox and set it to the activeTB
         * Limitations: none
         */
        private void SetActiveTextBox(TextBox textBox)
        {
            this.activeTB = textBox;
        }

        /* Method: SetActivePresidentRadioButton
         * Purpose: Accept a RadioButton and set it to the activePresRB
         * Limitations: none
         */
        private void SetActivePresidentRadioButton(RadioButton radioButton)
        {
            this.activePresRB = radioButton;
        }

        /* Method: SetActiveFilterRadioButton
         * Purpose: Accept a RadioButton and set it to the activeFilterRB
         * Limitations: none
         */
        private void SetActiveFilterRadioButton(RadioButton radioButton)
        {
            this.activeFilterRB = radioButton;
        }

        private void SetPresidentTextBoxesHoverText()
        {
            foreach(TextBox tb in presidentTextBoxes)
            {
                this.toolTip1.SetToolTip(tb, "Which # President?");
                
            }
        }

        /* Method: DisableNonActiveTextBoxs
         * Purpose: Disables non-active TextBox's to ReadOnly
         * Limitations: none
         */
        private void DisableNonActiveTextBoxs()
        {
            foreach (TextBox tb in presidentTextBoxes)
            {
                if(tb != activeTB)
                {
                    tb.ReadOnly = true;
                }
            }
        }

        /* Method: EnableTextBoxs
         * Purpose: Enables TextBox's  by setting all TextBox's to ReadOnly = false
         * Limitations: none
         */
        private void EnableTextBoxs()
        {
            foreach (TextBox tb in presidentTextBoxes)
            {
                tb.ReadOnly = false;
            }
        }

        /* Method: CheckForWin
         * Purpose: Checks if the User has Won. If so, congratulate them and stop the game!
         * Limitations: none
         */
        private void CheckForWin()
        {

            //loop through each presidentTextBoxes and check if each president's TextBox ISN'T the same as the value in presidentInformation
            //if any of them are off, do nothing and return
            for (int i = 0; i < presidentTextBoxes.Length; i++)
            {
                if (!(presidentTextBoxes[i].Text == presidentInformation[i, OrderColumnIndex]))
                {
                    return;
                }
            }

            //if we don't return, the user has won! "unstart" the game, enable the exitButton, display the winningURL, and stop the timer!
            gameStart = false;
            this.exitButton.Enabled = true;
            this.webBrowser1.Navigate(winningUrl);
            timer1.Stop();
        }

        /* Method: FillPresidentInformation
          * Purpose: Fills the array presidentInformation
          * Limitations: none
          */
        private void FillPresidentInformation()
        {
            //fill each row, column by column
            for (int r = 0; r < presidentInformation.GetLength(0); r++)
            {
                for (int c = 0; c < presidentInformation.GetLength(1); c++)
                {

                    //based on value of r and c, fill in array corresponding to president's Name, Image, Order, WebPage, and Party
                    if (r == BenHarrisonRowIndex)
                    {
                        switch (c)
                        {
                            case NameColumnIndex:
                                presidentInformation[r, c] = benHarrisonRadioButton.Text;
                                break;

                            case ImageColumnIndex:
                                presidentInformation[r, c] = "BenjaminHarrison.jpeg";
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "23";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.m.wikipedia.org/wiki/Benjamin_Harrison";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Republican";
                                break;

                            default:

                                break;
                        }
                    }
                    else if (r == FdrRowIndex)
                    {
                        switch (c)
                        {
                            case NameColumnIndex:
                                presidentInformation[r, c] = fdrRadioButton.Text;
                                break;

                            case ImageColumnIndex:
                                presidentInformation[r, c] = "FranklinDRoosevelt.jpeg";
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "32";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.m.wikipedia.org/wiki/Franklin_D._Roosevelt";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Democrat";
                                break;

                            default:

                                break;
                        }
                    }
                    else if (r == BillClintonRowIndex)
                    {
                        switch (c)
                        {
                            case NameColumnIndex:
                                presidentInformation[r, c] = billClintonRadioButton.Text;
                                break;

                            case ImageColumnIndex:
                                presidentInformation[r, c] = "WilliamJClinton.jpeg";
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "42";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.m.wikipedia.org/wiki/Bill_Clinton";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Democrat";
                                break;

                            default:

                                break;
                        }
                    }
                    else if (r == JamesBuchananRowIndex)
                    {
                        switch (c)
                        {
                            case NameColumnIndex:
                                presidentInformation[r, c] = jamesBuchananRadioButton.Text;
                                break;

                            case ImageColumnIndex:
                                presidentInformation[r, c] = "JamesBuchanan.jpeg";
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "15";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.m.wikipedia.org/wiki/James_Buchanan";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Democrat";
                                break;

                            default:

                                break;
                        }
                    }
                    else if (r == FrankPierceRowIndex)
                    {
                        switch (c)
                        {
                            case NameColumnIndex:
                                presidentInformation[r, c] = frankPierceRadioButton.Text;
                                break;

                            case ImageColumnIndex:
                                presidentInformation[r, c] = "FranklinPierce.jpeg";
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "14";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.m.wikipedia.org/wiki/Franklin_Pierce";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Democrat";
                                break;

                            default:

                                break;
                        }
                    }
                    else if (r == GeorgeWBushRowIndex)
                    {
                        switch (c)
                        {
                            case NameColumnIndex:
                                presidentInformation[r, c] = georgeWBushRadioButton.Text;
                                break;

                            case ImageColumnIndex:
                                presidentInformation[r, c] = "GeorgeWBush.jpeg";
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "43";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.m.wikipedia.org/wiki/George_W._Bush";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Republican";
                                break;

                            default:

                                break;
                        }
                    }
                    else if (r == ObamaRowIndex)
                    {
                        switch (c)
                        {
                            case NameColumnIndex:
                                presidentInformation[r, c] = obamaRadioButton.Text;
                                break;

                            case ImageColumnIndex:
                                presidentInformation[r, c] = "BarackObama.png";
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "44";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.m.wikipedia.org/wiki/Barack_Obama";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Democrat";
                                break;

                            default:

                                break;
                        }
                    }
                    else if (r == JfkRowIndex)
                    {
                        switch (c)
                        {
                            case NameColumnIndex:
                                presidentInformation[r, c] = jfkRadioButton.Text;
                                break;

                            case ImageColumnIndex:
                                presidentInformation[r, c] = "JohnFKennedy.jpeg";
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "35";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.m.wikipedia.org/wiki/John_F._Kennedy";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Democrat";
                                break;

                            default:

                                break;
                        }
                    }
                    else if (r == WillMcKinleyRowIndex)
                    {
                        switch (c)
                        {
                            case NameColumnIndex:
                                presidentInformation[r, c] = willMcKinleyRadioButton.Text;
                                break;

                            case ImageColumnIndex:
                                presidentInformation[r, c] = "WilliamMcKinley.jpeg";
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "25";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.m.wikipedia.org/wiki/William_McKinley";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Republican";
                                break;

                            default:

                                break;
                        }
                    }
                    else if (r == ReaganRowIndex)
                    {
                        switch (c)
                        {
                            case NameColumnIndex:
                                presidentInformation[r, c] = reaganRadioButton.Text;
                                break;

                            case ImageColumnIndex:
                                presidentInformation[r, c] = "RonaldReagan.jpeg";
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "40";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.m.wikipedia.org/wiki/Ronald_Reagan";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Republican";
                                break;

                            default:

                                break;
                        }
                    }
                    else if (r == EisenhowerRowIndex)
                    {
                        switch (c)
                        {
                            case NameColumnIndex:
                                presidentInformation[r, c] = eisenhowerRadioButton.Text;
                                break;

                            case ImageColumnIndex:
                                presidentInformation[r, c] = "DwightDEisenhower.jpeg";
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "34";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.m.wikipedia.org/wiki/Dwight_D._Eisenhower";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Republican";
                                break;

                            default:

                                break;
                        }
                    }
                    else if (r == VanBurenRowIndex)
                    {
                        switch (c)
                        {
                            case NameColumnIndex:
                                presidentInformation[r, c] = vanBurenRadioButton.Text;
                                break;

                            case ImageColumnIndex:
                                presidentInformation[r, c] = "MartinVanBuren.jpeg";
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "8";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.m.wikipedia.org/wiki/Martin_Van_Buren";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Democrat";
                                break;

                            default:

                                break;
                        }
                    }
                    else if (r == GeorgeWashingtonRowIndex)
                    {
                        switch (c)
                        {
                            case NameColumnIndex:
                                presidentInformation[r, c] = georgeWashingtonRadioButton.Text;
                                break;

                            case ImageColumnIndex:
                                presidentInformation[r, c] = "GeorgeWashington.jpeg";
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "1";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.m.wikipedia.org/wiki/George_Washington";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Federalist";
                                break;

                            default:

                                break;
                        }
                    }
                    else if (r == JohnAdamsRowIndex)
                    {
                        switch (c)
                        {
                            case NameColumnIndex:
                                presidentInformation[r, c] = johnAdamsRadioButton.Text;
                                break;

                            case ImageColumnIndex:
                                presidentInformation[r, c] = "JohnAdams.jpeg";
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "2";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.m.wikipedia.org/wiki/John_Adams";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Federalist";
                                break;

                            default:

                                break;
                        }
                    }
                    else if (r == TeddyRooseveltRowIndex)
                    {
                        switch (c)
                        {
                            case NameColumnIndex:
                                presidentInformation[r, c] = teddyRooseveltRadioButton.Text;
                                break;

                            case ImageColumnIndex:
                                presidentInformation[r, c] = "TheodoreRoosevelt.jpeg";
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "26";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.m.wikipedia.org/wiki/Theodore_Roosevelt";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Republican";
                                break;

                            default:

                                break;
                        }
                    }
                    else if (r == JeffersonRowIndex)
                    {
                        switch (c)
                        {
                            case NameColumnIndex:
                                presidentInformation[r, c] = jeffersonRadioButton.Text;
                                break;

                            case ImageColumnIndex:
                                presidentInformation[r, c] = "ThomasJefferson.jpeg";
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "3";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.m.wikipedia.org/wiki/Thomas_Jefferson";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Democratic-Republican";
                                break;

                            default:

                                break;
                        }
                    }

                    //if somehow we go outside of bounds, inform (testing purposes)
                    else
                    {
                        MessageBox.Show(r + " isn't a valid index");
                    }




                }
            }
        }


    }
}
