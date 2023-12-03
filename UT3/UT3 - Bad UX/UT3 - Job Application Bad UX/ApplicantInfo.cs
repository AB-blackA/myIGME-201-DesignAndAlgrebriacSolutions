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

namespace UT3___Job_Application_Bad_UX
{
    public partial class ApplicantInfo : Form
    {

        private byte attemptedContinues = 0;
        private bool boxesReset = false;

        private TextBox[] textBoxs = new TextBox[5];
        private int[,] resetFieldLocations = new int[4, 2];
        private byte rflXIndex = 0;
        private byte rflYIndex = 1;

        private int resetButtonStartingX;
        private int resetButtonStartingY;

        private Thread updateThread = null;
        private bool startThread = false;
        private bool stopThread = false;

        private string firstName;
        private string lastName;
        private string zipCode;
        private string streetAddress;
        private string state;

        private ApplicantQualities applicantQualitiesForm;


        public ApplicantInfo()
        {
            InitializeComponent();

            this.richTextBox1.ReadOnly = true;

            this.firstNameTextBox.TextChanged += new EventHandler(TextBoxChanged__TextChanged);
            this.lastNameTextBox.TextChanged += new EventHandler(TextBoxChanged__TextChanged);
            this.zipCodeTextBox.TextChanged += new EventHandler(TextBoxChanged__TextChanged);
            this.streetAddressTextBox.TextChanged += new EventHandler(TextBoxChanged__TextChanged);
            this.stateTextBox.TextChanged += new EventHandler(TextBoxChanged__TextChanged);

            this.continueButton.Click += new EventHandler(AttemptContinue__Click);

            this.resetTBLocationsButton.Click += new EventHandler(ResetTextBoxLocations__Click);

            this.FormClosing += new FormClosingEventHandler(Form__FormClosing);

            this.resetButtonStartingX = this.resetTBLocationsButton.Location.X;
            this.resetButtonStartingY = this.resetTBLocationsButton.Location.Y;

            this.zipCodeTextBox.Visible = false;
            this.zipCodeLabel.Visible = false; 
            this.resetTBLocationsButton.Visible = false;

            FillResetFieldLocationsArray();
            FillTextBoxsArray();
            SetTextBoxLocationsInTags();
        }

        private void TextBoxChanged__TextChanged(object sender, EventArgs e)
        {
            if(attemptedContinues == 0)
            {
                return;
            }
            else if(attemptedContinues > 0 && !boxesReset)
            {
                foreach (TextBox tb in textBoxs)
                {
                    if (tb != this.streetAddressTextBox)
                    {
                        tb.Location = new Point(tb.Location.X - 300, tb.Location.Y - 300);

                        if (tb.Location.X < 0 && startThread == false)
                        {

                            StartThread();

                        }
                    }
                }
            }
        }

        private void AttemptContinue__Click(object sender, EventArgs e)
        {
            switch (attemptedContinues)
            {

                case 0:

                    attemptedContinues += 1;
                    this.richTextBox1.Text = "Sorry, we lost all your data. Please try again.";

                    EmptyTextBoxes();

                    break;

                case 1:

                    if (!CheckFieldsFull())
                    {
                        this.richTextBox1.Text = "All fields must be filled!";
                        return;
                    }

                    attemptedContinues += 1;

                    this.richTextBox1.Text = "Sorry, we forgot a field. Please try again.";

                    this.zipCodeLabel.Visible = true;
                    this.zipCodeTextBox.Visible = true;

                    EmptyTextBoxes();

                    break;

                default:

                    if (!CheckFieldsFull())
                    {
                        this.richTextBox1.Text = "All fields must be filled!";
                        return;
                    }

                    if (this.applicantQualitiesForm == null)
                    {
                        this.applicantQualitiesForm = new ApplicantQualities(this);
                        applicantQualitiesForm.Show();
                    }
                    
                    SaveInformation();

                    break;
            }
        }

        private void ResetTextBoxLocations__Click(object sender, EventArgs e)
        {
            foreach(TextBox tb in textBoxs)
            {
                tb.Location = (Point)tb.Tag;
            }



            boxesReset = true;
            stopThread = true;


        }

        private void StartThread()
        {
            startThread = true;
            resetTBLocationsButton.Visible = true;
            updateThread = new Thread(StartUpdateThread);
            updateThread.Start();
            this.richTextBox1.Text = "If your fields have gone offscreen, hit the Reset button. Please try and be more" +
                "careful next time.";

        }

        

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

        private void FillTextBoxsArray()
        {

            textBoxs[0] = firstNameTextBox;
            textBoxs[1] = lastNameTextBox;
            textBoxs[2] = streetAddressTextBox;
            textBoxs[3] = stateTextBox;
            textBoxs[4] = zipCodeTextBox;
        }

        private void SetTextBoxLocationsInTags()
        {
            foreach(TextBox tb in textBoxs)
            {
                tb.Tag = tb.Location;
            }
        }

        private void StartUpdateThread()
        {
            while (!stopThread)
            {
                MoveResetFieldsButton();
                Thread.Sleep(100);
            }
        }

        private void MoveResetFieldsButton()
        {

            if (this.InvokeRequired)
            {
                for (int r = 0; r < resetFieldLocations.GetLength(0); r++)
                {

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

                       
                        this.Invoke(new Action(() =>
                        {
                            resetTBLocationsButton.Location = new Point(resetFieldLocations[r, 0], resetFieldLocations[r, 1]);
                        }));
                        

                        return;
                    }

                }
            }
        }

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

        private void Form__FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updateThread != null)
            {
                stopThread = true;
                updateThread.Abort();
            }
        }

        private void EmptyTextBoxes()
        {
            foreach (TextBox tb in textBoxs)
            {
                tb.Text = "";

                if(attemptedContinues == 1)
                {
                    tb.Location = (Point)tb.Tag;
                }
            }
        }

        private void SaveInformation()
        {
            this.firstName = this.firstNameTextBox.Text;
            this.lastName = this.lastNameTextBox.Text;
            this.zipCode = this.zipCodeTextBox.Text;
            this.streetAddress = this.streetAddressTextBox.Text;
            this.state = this.stateTextBox.Text;
        }

        public string GetFirstName()
        {
            return this.firstName;
        }

        public string GetLastName()
        {
            return this.lastName;
        }

        public string GetZipCode()
        {
            return this.zipCode;
        }

        public string GetStreetAddress()
        {
            return this.streetAddress;
        }

        public string GetState()
        {
            return this.state;
        }

        /*protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                // Check if the currently focused control is a button
                if (ActiveControl is Button)
                {
                    // Handle the Enter key press for the button
                    return true; // Suppress the Enter key press
                }
            }

            // Call the base class implementation for other keys
            return base.ProcessCmdKey(ref msg, keyData);
        }*/
    }
}
