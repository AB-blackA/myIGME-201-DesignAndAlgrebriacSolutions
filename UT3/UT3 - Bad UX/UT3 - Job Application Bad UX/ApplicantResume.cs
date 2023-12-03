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
    public partial class ApplicantResume : Form
    {

        private ApplicantQualities applicantQualities;

        private const string DefaultText = "Please manually type in your resume here. Anything less than 2000 words will be rejected.";
        private const string MinLengthNotMetText = "Your Resume was less than 2000 words. Can't you read? Exit the application if you can't meet that criteria.";
        private int lastKnownResumeTextCount = DefaultText.Length;
        private const short MinResumeLength = 2000;

        public ApplicantResume(ApplicantQualities applicantQualities)
        {
            this.applicantQualities = applicantQualities;

            InitializeComponent();

            this.button1.Click += new EventHandler(SubmitButton__Click);
            
            this.richTextBox1.TextChanged += new EventHandler(ResumeText__TextChanged);
            this.richTextBox1.Text = DefaultText;
        }

        private void ResumeText__TextChanged(object sender, EventArgs e)
        {
            if(this.richTextBox1.Text.Length > this.lastKnownResumeTextCount + 1)
            {
                MessageBox.Show("Error, can't accept Copy/Pasted Resumes. Please enter MANUALLY");
                this.lastKnownResumeTextCount = DefaultText.Length;
                this.richTextBox1.Text = DefaultText;
            }
            else if(this.richTextBox1.Text.Length < this.lastKnownResumeTextCount)
            {
                lastKnownResumeTextCount = this.richTextBox1.Text.Length;
            }
            else
            {
                lastKnownResumeTextCount++;
            }
        }

        private void SubmitButton__Click(object sender, EventArgs e) 
        {

            if (ResumeAcceptable())
            {

                if (!MeetsQualifications())
                {

                    MessageBox.Show("We have receieved your application. Unfortunately, you didn't meet our criteria of having " +
                        "UX Design Experience and Ten Years Experience in Software Engineering. We encourage you to apply for other " +
                        "Internships in the future");
                    Application.Exit();

                }
                else
                {
                    MessageBox.Show("We have received your application. Unfortunately, the position has been filled as of six weeks " +
                        "ago. Please for free to apply for sUX Design Inc. roles in the future (we won't save your resume), and " +
                        "we hope your day is as pleasant as our User Interfaces!");
                    Application.Exit();
                }

            }
            
        }

        private void ResetLastKnownTextLength()
        {
            this.lastKnownResumeTextCount = this.richTextBox1.Text.Length;
        }

        private bool ResumeAcceptable()
        {
            if (this.richTextBox1.Text.Length < MinResumeLength)
            {

                this.lastKnownResumeTextCount = MinLengthNotMetText.Length;
                this.richTextBox1.Text = MinLengthNotMetText;
                return false;
            }
            return true;
        }

        private bool MeetsQualifications()
        {

            if(applicantQualities.TenPlusExperience() && applicantQualities.UXDesignerExperience())
            {
                return true;
            }

            return false;

        }


    }
}
