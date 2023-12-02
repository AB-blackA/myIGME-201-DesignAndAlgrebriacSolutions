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
    public partial class Form1 : Form
    {

        private byte attemptedContinues = 0;
        private bool boxesReset = false;

        private TextBox[] textBoxs = new TextBox[5];
        private int[,] resetFieldLocations = new int[4, 2];
        private byte rflXIndex = 0;
        private byte rflYIndex = 1;

        private Thread updateThread = null;
        private bool stopThread = false;

        public Form1()
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


            resetTBLocationsButton.Enabled = false;

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
            else if(attemptedContinues == 1 && !boxesReset)
            {
                foreach (TextBox tb in textBoxs)
                {
                    if (tb != this.streetAddressTextBox)
                    {
                        tb.Location = new Point(tb.Location.X - 100, tb.Location.Y - 1);

                        if (tb.Location.X < 0 && updateThread == null)
                        {
                            resetTBLocationsButton.Enabled = true;
                            updateThread = new Thread(StartUpdateThread);
                            updateThread.Start();
                            this.richTextBox1.Text = "If your fields have gone offscreen, hit the Reset button. Please try and be more" +
                                "careful next time.";
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

                    foreach(TextBox tb in textBoxs)
                    {
                        tb.Text = "";
                    }

                    break;

                case 1:

                    foreach(TextBox tb in textBoxs)
                    {
                        if(tb.Text == "" || tb.Text == null)
                        {
                            this.richTextBox1.Text = "All fields must be filled!";
                            break;
                        }
                    }

                    attemptedContinues += 1;

                    this.richTextBox1.Text = "Sorry, we forgot a field. Please try again.";

                    foreach (TextBox tb in textBoxs)
                    {
                        tb.Text = "";
                    }

                    break;

                default:



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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FillTextBoxsArray()
        {

            textBoxs[0] = firstNameTextBox;
            textBoxs[1] = lastNameTextBox;
            textBoxs[2] = zipCodeTextBox;
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

                        try
                        {
                            this.Invoke(new Action(() =>
                            {
                                resetTBLocationsButton.Location = new Point(resetFieldLocations[r, 0], resetFieldLocations[r, 1]);
                            }));
                        }
                        catch
                        {
                            Application.Exit();
                        }

                        return;
                    }

                }
            }
        }

        private void FillResetFieldLocationsArray()
        {
            this.resetFieldLocations[0, 0] = 231;
            this.resetFieldLocations[0, 1] = 114;
            this.resetFieldLocations[1, 0] = 12;
            this.resetFieldLocations[1, 1] = 114;
            this.resetFieldLocations[2, 0] = 12;
            this.resetFieldLocations[2, 1] = 309;
            this.resetFieldLocations[3, 0] = 231;
            this.resetFieldLocations[3, 1] = 309;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopThread = true;
            updateThread.Abort();
        }
    }
}
