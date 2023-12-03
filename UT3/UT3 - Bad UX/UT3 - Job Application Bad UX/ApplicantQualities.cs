using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UT3___Job_Application_Bad_UX
{

    public partial class ApplicantQualities : Form
    {
        private CheckBox[] checkBoxs = new CheckBox[6];
        private RadioButton[] radioButtons = new RadioButton[6];

        private bool applicationAcceptible = false;

        private const string UnacceptableFirstName = "Dave";
        private const string LastNameOverrideFirstNameException = "Schuh";

        private bool uxDesignerChecked = false;
        private bool tenPlusChecked = false;

        private const byte FontSizeFactor = 4;

        private ApplicantInfo applicantInfoRef;

        private ApplicantResume applicantResumeForm;

        private Random random = new Random();


        public ApplicantQualities(ApplicantInfo applicantInfo)
        {
            InitializeComponent();

            this.applicantInfoRef = applicantInfo;

            this.oopCheckBox.CheckedChanged += new EventHandler(CheckBox__CheckedChanged);
            this.dataStructuresCheckBox.CheckedChanged += new EventHandler(CheckBox__CheckedChanged);
            this.uiCheckBox.CheckedChanged += new EventHandler(CheckBox__CheckedChanged);
            this.uxCheckBox.CheckedChanged += new EventHandler(CheckBox__CheckedChanged);
            this.backendCheckBox.CheckedChanged += new EventHandler(CheckBox__CheckedChanged);
            this.fullStackCheckBox.CheckedChanged += new EventHandler(CheckBox__CheckedChanged);

            this.zeroRadioButton.CheckedChanged += new EventHandler(RadioButton__CheckedChanged);
            this.oneTwoRadioButton.CheckedChanged += new EventHandler(RadioButton__CheckedChanged);
            this.threeFourRadioButton.CheckedChanged += new EventHandler(RadioButton__CheckedChanged);
            this.fiveSevenRadioButton.CheckedChanged += new EventHandler(RadioButton__CheckedChanged);
            this.eightNineRadioButton.CheckedChanged += new EventHandler(RadioButton__CheckedChanged);
            this.tenPlusRadioButton.CheckedChanged += new EventHandler(RadioButton__CheckedChanged);

            this.continueButton.Click += new EventHandler(ContinueButton__Click);

            this.richTextBox1.Text = "When ready, hit Continue";
            this.richTextBox1.ReadOnly = true;

            FillArrays();
        }

        private void UxCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

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

        private void RadioButton__CheckedChanged(object sender, EventArgs e)
        {

            int redValue = random.Next(0, 256);
            int greenValue = random.Next(0, 256);
            int blueValue = random.Next(0, 256);

            foreach(RadioButton rb in radioButtons)
            {
                rb.ForeColor = GetRandomColor();
            }

            foreach(CheckBox cb in checkBoxs)
            {
                cb.ForeColor = GetRandomColor();
            }

            
        }

        private void CheckBox__CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            if (cb.Checked)
            {

                foreach (CheckBox checkBox in checkBoxs)
                {
                    if (checkBox != cb && checkBox.Checked)
                    {
                        checkBox.Checked = false;
                    }
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

        private Color GetRandomColor()
        {
            int redValue = random.Next(0, 256);
            int greenValue = random.Next(0, 256);
            int blueValue = random.Next(0, 256);

            return Color.FromArgb(redValue, greenValue, blueValue);
        }

        private void ContinueButton__Click(object sender, EventArgs e)
        {
            this.applicationAcceptible = EnsureAcceptability();

            if (applicationAcceptible)
            {

                if(this.applicantResumeForm == null)
                {
                    applicantResumeForm = new ApplicantResume(this);
                    applicantResumeForm.Show();
                }

                SaveInformation();

            }
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

        private bool EnsureAcceptability()
        {

            byte onlyOneRadioButtonChecked = 0;
            byte atLeastOneCheckBoxChecked = 0;

            foreach (RadioButton rb in radioButtons)
            {
                if(rb.Checked)
                {
                    onlyOneRadioButtonChecked++;
                }

            }

            foreach (CheckBox cb in checkBoxs)
            {
                if (cb.Checked)
                {
                    atLeastOneCheckBoxChecked++;
                }
            }

            if (onlyOneRadioButtonChecked != 1 && atLeastOneCheckBoxChecked < 1)
            {
                MessageBox.Show("failed rb or cb");
                return false;
            }

            if (applicantInfoRef.GetFirstName() == UnacceptableFirstName)
            {
                if (applicantInfoRef.GetLastName() != LastNameOverrideFirstNameException)
                {
                    MessageBox.Show("failed name");
                    return false;
                }
            }

            string applicantZip = applicantInfoRef.GetZipCode();

            if (!applicantZip.All(char.IsDigit) && (applicantZip.Length != 9 || applicantZip.Length != 5)) 
            {
                MessageBox.Show("failed zip");
                return false;
            }

            return true;
        }

        private void SaveInformation()
        {

            this.tenPlusChecked = this.tenPlusRadioButton.Checked;
            this.uxDesignerChecked = this.uxCheckBox.Checked;
        }

        public bool TenPlusExperience()
        {
            return this.tenPlusChecked;
        }

        public bool UXDesignerExperience()
        {
            return this.uxDesignerChecked;
        }

        private void ApplicantQualities_Load(object sender, EventArgs e)
        {

        }
    }

    
}
