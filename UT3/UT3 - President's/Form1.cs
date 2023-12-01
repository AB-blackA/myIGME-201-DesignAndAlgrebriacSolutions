using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace UT3___President_s
{
    public partial class Form1 : Form
    {

        string[,] presidentInformation = new string[16, 5];
        RadioButton[] presidentRadioButtons = new RadioButton[16];
        TextBox[] presidentTextBoxes = new TextBox[16];
        Timer timer;
        bool timerStarted;
        float pictureBoxScaleFactor = 1.5f;

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

        public const byte NameColumnIndex = 0;
        public const byte ImageColumnIndex = 1;
        public const byte OrderColumnIndex = 2;
        public const byte WebPageColumnIndex = 3;
        public const byte PartyColumnIndex = 4;


        public Form1()
        {
            InitializeComponent();

            this.benHarrisonRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton_CheckedChanged);
            this.fdrRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton_CheckedChanged);
            this.billClintonRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton_CheckedChanged);
            this.jamesBuchananRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton_CheckedChanged);
            this.frankPierceRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton_CheckedChanged);
            this.georeWBushRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton_CheckedChanged);
            this.obamaRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton_CheckedChanged);
            this.jfkRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton_CheckedChanged);
            this.willMcKinleyRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton_CheckedChanged);
            this.reaganRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton_CheckedChanged);
            this.eisenhowerRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton_CheckedChanged);
            this.vanBurenRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton_CheckedChanged);
            this.georgeWashingtonRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton_CheckedChanged);
            this.johnAdamsRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton_CheckedChanged);
            this.teddyRooseveltRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton_CheckedChanged);
            this.jeffersonRadioButton.CheckedChanged += new EventHandler(PresidentRadioButton_CheckedChanged);

            this.benHarrisTextBox.TextChanged += new EventHandler(PresidentTextBox_TextChanged);
            this.fdrTextBox.TextChanged += new EventHandler(PresidentTextBox_TextChanged);
            this.billClintonTextBox.TextChanged += new EventHandler(PresidentTextBox_TextChanged);
            this.jamesBuchananRadioButton.TextChanged += new EventHandler(PresidentTextBox_TextChanged);
            this.frankPierceTextBox.TextChanged += new EventHandler(PresidentTextBox_TextChanged);
            this.georgeWBushTextBox.TextChanged += new EventHandler(PresidentTextBox_TextChanged);
            this.obamaTextBox.TextChanged += new EventHandler(PresidentTextBox_TextChanged);
            this.jfkTextBox.TextChanged += new EventHandler(PresidentTextBox_TextChanged);
            this.willMcKinleyTextBox.TextChanged += new EventHandler(PresidentTextBox_TextChanged);
            this.reaganTextBox.TextChanged += new EventHandler(PresidentTextBox_TextChanged);
            this.eisenhowerTextBox.TextChanged += new EventHandler(PresidentTextBox_TextChanged);
            this.vanBurenTextBox.TextChanged += new EventHandler(PresidentTextBox_TextChanged);
            this.georgeWashingtonTextBox.TextChanged += new EventHandler(PresidentTextBox_TextChanged);
            this.johnAdamsTextBox.TextChanged += new EventHandler(PresidentTextBox_TextChanged);
            this.teddyRooseveltTextBox.TextChanged += new EventHandler(PresidentTextBox_TextChanged);
            this.jeffersonTextBox.TextChanged += new EventHandler(PresidentTextBox_TextChanged);

            this.presidentPictureBox.MouseHover += new EventHandler(PresidentPictureBox_MouseHover);
            this.presidentPictureBox.MouseLeave += new EventHandler(PresidentPictureBox_MouseLeave);

            FillArrays();
            TagPresidentsInTextBoxes();


        }

        private void PresidentRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            if(sender.GetType() == typeof(RadioButton))
            {
                for(int r = 0; r < presidentInformation.GetLength(0); r++)
                {
    
                    if(((RadioButton)sender).Text == presidentInformation[r, nameColumnIndex])
                    {
                    
                        this.pictureBox1.Image = Image.FromFile(presidentInformation[r, ImageColumnIndex]);
                        this.webBrowser1.Navigate(presidentInformation[r, WebPageColumnIndex]);
                        
                    }
                }
            }
          
            
        }

        private void FilterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(sender.GetType() == typeOf(RadioButton))
            {
            
                string party = ((RadioButton)sender).Text;
        
                foreach (RadioButton rb in presidentRadioButtons)
                {
                    rb.Enabled = true;
                }
        
                foreach (TextBox tb in presidentTextBoxes)
                {
                    tb.Enabled = true;
                }
        
                for (int r = 0; r < presidentInformation.GetLength(0); r++)
                {
                
                    if(presidentInformation[r, partyColumnIndex] != party)
                    {
                        presidentRadioButtons[r].Enabled = false;
                        presidentTextBoxes[r].Enabled = false;
                    }
                }
            }
                
        }

        private void PresidentPictureBox_MouseHover(object sender, EventArgs e)
        {
            // Store the original size in the Tag property
            if (pictureBox1.Tag == null)
            {
                pictureBox1.Tag = pictureBox1.Size;
            }

            // Increase the size on hover
            pictureBox1.Size = new Size(pictureBox1.Width * pictureBoxScaleFactor, pictureBox1.Height pictureBoxScaleFactor);
        }

        private void PresidentPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (pictureBox1.Tag != null)
            {
                pictureBox1.Size = pictureBox1.Size;
            }
        }

        private void PresidentTextBox_TextChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Tag != null)
            {
                pictureBox1.Size = (Size)pictureBox1.Tag;
            }
        }

        private void FillArrays()
        {
            FillPresidentInformation();
            FillPresidentRadioButtons();
            FillPresidentTextBoxes();
            TagPresidentsInTextBoxes();
        }

        private void FillPresidentInformation()
        {
            for(int r = 0; r < presidentInformation.GetLength(0); r++)
            {
                for(int c = 0; c < presidentInformation.GetLength(1); c++)
                {

                    if (r == BenHarrisonRowIndex)
                    {
                        switch (c)
                        {
                            case NameColumnIndex:
                                presidentInformation[r, c] = benHarrisonRadioButton.Text;
                                break;

                            case ImageColumnIndex:
                                // Code for handling the Image column
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "23";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.wikipedia.org/wiki/George_Washington";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Republican";
                                break;

                            default:
                                // Code for handling cases where c doesn't match any constant
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
                                // Code for handling the Image column
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "32";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.wikipedia.org/wiki/Franklin_D._Roosevelt";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Democrat";
                                break;

                            default:
                                // Code for handling cases where c doesn't match any constant
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
                                // Code for handling the Image column
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "42";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.wikipedia.org/wiki/Bill_Clinton";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Democrat";
                                break;

                            default:
                                // Code for handling cases where c doesn't match any constant
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
                                // Code for handling the Image column
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "15";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.wikipedia.org/wiki/James_Buchanan";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Democrat";
                                break;

                            default:
                                // Code for handling cases where c doesn't match any constant
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
                                // Code for handling the Image column
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "14";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.wikipedia.org/wiki/Franklin_Pierce";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Democrat";
                                break;

                            default:
                                // Code for handling cases where c doesn't match any constant
                                break;
                        }
                    }
                    else if (r == GeorgeWBushRowIndex)
                    {
                        switch (c)
                        {
                            case NameColumnIndex:
                                presidentInformation[r, c] = georeWBushRadioButton.Text;
                                break;

                            case ImageColumnIndex:
                                // Code for handling the Image column
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "43";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.wikipedia.org/wiki/George_W._Bush";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Republican";
                                break;

                            default:
                                // Code for handling cases where c doesn't match any constant
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
                                // Code for handling the Image column
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "44";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.wikipedia.org/wiki/Barack_Obama";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Democrat";
                                break;

                            default:
                                // Code for handling cases where c doesn't match any constant
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
                                // Code for handling the Image column
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "35";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.wikipedia.org/wiki/John_F._Kennedy";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Democrat";
                                break;

                            default:
                                // Code for handling cases where c doesn't match any constant
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
                                // Code for handling the Image column
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "25";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.wikipedia.org/wiki/William_McKinley";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Republican";
                                break;

                            default:
                                // Code for handling cases where c doesn't match any constant
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
                                // Code for handling the Image column
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "40";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.wikipedia.org/wiki/Ronald_Reagan";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Republican";
                                break;

                            default:
                                // Code for handling cases where c doesn't match any constant
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
                                // Code for handling the Image column
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "34";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.wikipedia.org/wiki/Dwight_D._Eisenhower";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Republican";
                                break;

                            default:
                                // Code for handling cases where c doesn't match any constant
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
                                // Code for handling the Image column
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "8";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.wikipedia.org/wiki/Martin_Van_Buren";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Democrat";
                                break;

                            default:
                                // Code for handling cases where c doesn't match any constant
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
                                // Code for handling the Image column
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "1";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.wikipedia.org/wiki/George_Washington";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Federalist";
                                break;

                            default:
                                // Code for handling cases where c doesn't match any constant
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
                                // Code for handling the Image column
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "2";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.wikipedia.org/wiki/John_Adams";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Federalist";
                                break;

                            default:
                                // Code for handling cases where c doesn't match any constant
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
                                // Code for handling the Image column
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "26";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.wikipedia.org/wiki/Theodore_Roosevelt";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Republican";
                                break;

                            default:
                                // Code for handling cases where c doesn't match any constant
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
                                // Code for handling the Image column
                                break;

                            case OrderColumnIndex:
                                presidentInformation[r, c] = "3";
                                break;

                            case WebPageColumnIndex:
                                presidentInformation[r, c] = "https://en.wikipedia.org/wiki/Thomas_Jefferson";
                                break;

                            case PartyColumnIndex:
                                presidentInformation[r, c] = "Democratic-Republican";
                                break;

                            default:
                                // Code for handling cases where c doesn't match any constant
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show(r + " isn't a valid index");
                    }




                }
            }
        }

        private void FillPresidentRadioButtons()
        {
            presidentRadioButtons[0] = this.benHarrisonRadioButton;
            presidentRadioButtons[1] = this.fdrRadioButton;
            presidentRadioButtons[2] = this.billClintonRadioButton;
            presidentRadioButtons[3] = this.jamesBuchananRadioButton;
            presidentRadioButtons[4] = this.frankPierceRadioButton;
            presidentRadioButtons[5] = this.georeWBushRadioButton;
            presidentRadioButtons[6] = this.obamaRadioButton;
            presidentRadioButtons[7] = this.jfkRadioButton;
            presidentRadioButtons[8] = this.willMcKinleyRadioButton;
            presidentRadioButtons[9] = this.reaganRadioButton;
            presidentRadioButtons[10] = this.eisenhowerRadioButton;
            presidentRadioButtons[11] = this.vanBurenRadioButton;
            presidentRadioButtons[12] = this.georgeWashingtonRadioButton;
            presidentRadioButtons[13] = this.johnAdamsRadioButton;
            presidentRadioButtons[14] = this.teddyRooseveltRadioButton;
            presidentRadioButtons[15] = this.jeffersonRadioButton;
        }

        private void FillPresidentTextBoxes()
        {
            presidentTextBoxes[0] = this.benHarrisTextBox;
            presidentTextBoxes[1] = this.fdrTextBox;
            presidentTextBoxes[2] = this.billClintonTextBox;
            presidentTextBoxes[3] = this.jamesBuchanaTextBox;
            presidentTextBoxes[4] = this.frankPierceTextBox;
            presidentTextBoxes[5] = this.georgeWBushTextBox;
            presidentTextBoxes[6] = this.obamaTextBox;
            presidentTextBoxes[7] = this.jfkTextBox;
            presidentTextBoxes[8] = this.willMcKinleyTextBox;
            presidentTextBoxes[9] = this.reaganTextBox;
            presidentTextBoxes[10] = this.eisenhowerTextBox;
            presidentTextBoxes[11] = this.vanBurenTextBox;
            presidentTextBoxes[12] = this.georgeWashingtonTextBox;
            presidentTextBoxes[13] = this.johnAdamsTextBox;
            presidentTextBoxes[14] = this.teddyRooseveltTextBox;
            presidentTextBoxes[15] = this.jeffersonTextBox;
        }

        private void TagPresidentsInTextBoxes()
        {
            benHarrisTextBox.Tag = benHarrisonRadioButton;
            fdrTextBox.Tag = fdrRadioButton;
            billClintonTextBox.Tag = billClintonRadioButton;
            jamesBuchanaTextBox.Tag = jamesBuchananRadioButton;
            frankPierceTextBox.Tag = frankPierceRadioButton;
            georgeWBushTextBox.Tag = georeWBushRadioButton;
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

        private void StartTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            timerStarted = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Code to handle each tick of the timer
            // Update progressBar1 and check for timeout
        }

        private void TimeOut()
        {
            // Code to reset the game upon timeout
            // Reset progressBar1, set timerStarted to false, and reset PresidentTextBox values
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
