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
 * Purpose: Resume form of a Mock Job Application Form with a purposefully bad UX for IGME-201 Unit Test 3
 * Limitations: none
 */

/* Form Controls:
 * RichTextBox for user to enter Resume
 * SubmitButton for submitting finalized application
 */

namespace UT3___Job_Application_Bad_UX
{

    /* Class: ApplicantResume
     * Purpose: Hold relevant information regarding applicant qualities, form controls, and processes for making the applicant's submitting experience
     * miserable
     * Limitations: none
     */
    public partial class ApplicantResume : Form
    {
        //reference to form that opened this one
        private ApplicantQualities applicantQualitiesRef;

        //some default text and text for when criteria is met that the user will see upon form open and meeting said criteria
        private const string DefaultText = "Please manually type in your resume here. Anything less than 2000 words will be rejected.";
        private const string MinLengthNotMetText = "Your Resume was less than 2000 words. Can't you read? Exit the application if you can't meet that criteria.";

        //int for keeping track of the RichTextField.Text.Length
        private int lastKnownResumeTextCount = DefaultText.Length;

        //current minimum resume length (characters)
        private const short MinResumeLength = 2000;

        /* Constructor Method: ApplicantResume
         * Purpose: Create's this form, including creating EventHandlers and fiddling with any controls
         * Limitations: none
         */
        public ApplicantResume(ApplicantQualities applicantQualities)
        {
            //reference from previous form
            this.applicantQualitiesRef = applicantQualities;

            InitializeComponent();

            //create EventHandler for submitButton.Click
            this.submitButton.Click += new EventHandler(SubmitButton__Click);
            
            //create eventHandler for when the richTextBox1 is changed. Also, set its starting text
            this.richTextBox1.TextChanged += new EventHandler(ResumeText__TextChanged);
            this.richTextBox1.Text = DefaultText;
        }

        /* Method: ResumeText__Changed
         * Purpose: Check if the user has tried to copy/paste their resume in. If so, inform them that they have to manually
         * type it in and reset the Text to the DefaultText. If not, update lastKnownResumeTextCount to reflect either a new Char entry
         * or a backspace
         * Limitations: none
         */
        private void ResumeText__TextChanged(object sender, EventArgs e)
        {
            //check if the current Length is less than the last known. If so, that means the user hit backspace, so update the
            //lastKnownResumeTextCount variable to the current Text.Length
            if(this.richTextBox1.Text.Length < this.lastKnownResumeTextCount)
            {
                lastKnownResumeTextCount = this.richTextBox1.Text.Length;
            }
            //check if the current Text.Length is greater than 1 + the lastKnownResumeTextCount variable. Since you should only be able to 
            //enter one digit at a time, if it breaks this that the user must have copy/pasted something in. If it's smaller it's not worth catching,
            //but if it's bigger inform them that they can't copy/paste via a message box and wipe thier entry to the DefaultText (and reset the 
            //lastKnownResumeTextCount again
            else if (this.richTextBox1.Text.Length > this.lastKnownResumeTextCount + 1)
            {
                MessageBox.Show("Error, can't accept Copy/Pasted Resumes. Please enter MANUALLY");
                this.lastKnownResumeTextCount = DefaultText.Length;
                this.richTextBox1.Text = DefaultText;
            }
            //if they didn't backspace and didn't cheat, increase lastKnownResumeTextCount
            else
            {
                lastKnownResumeTextCount++;
            }
        }

        /* Method: SubmitButton__Click
         * Purpose: If the Resume is of acceptable length, display the result of their application depending on their
         * qualifications. Then, close the application so they don't get a chance to try to resubmit without doing 
         * all other forms all over again
         * Limitations: none
         */
        private void SubmitButton__Click(object sender, EventArgs e) 
        {
            //check if Resume is of acceptable length
            if (ResumeAcceptable())
            {
                //check qualifications. They are that the User has 10+ years experience and has experience in UX design. If not,
                //reject them for not meeting qualifications (And close application)
                if (!MeetsQualifications())
                {

                    MessageBox.Show("We have receieved your application. Unfortunately, you didn't meet our criteria of having " +
                        "UX Design Experience and Ten Years Experience in Software Engineering. We encourage you to apply for other " +
                        "Internships in the future");
                    Application.Exit();

                }
                //if they meet the qualifications, reject them for having the position already being filled.
                //And close the application.
                //And, no, there is no way to not be rejected. It was all for nothing.
                else
                {
                    MessageBox.Show("We have received your application. Unfortunately, the position has been filled as of six weeks " +
                        "ago. Please for free to apply for sUX Design Inc. roles in the future (we won't save your resume), and " +
                        "we hope your day is as pleasant as our User Interfaces!");
                    Application.Exit();
                }

            }
            
        }

        /* Method: ResumeAcceptable
         * Purpose: Checks to see if the Resume hits the accepted minimum length requirements and returns a bool
         * depending on the result
         * Limitations: none
         */
        private bool ResumeAcceptable()
        {
            //if resume doesn't hit the length requirement, wipe their current entry and display the MinLengthNotMetText
            //also updates lastKnownResumeTextCount to not break the form
            if (this.richTextBox1.Text.Length < MinResumeLength)
            {

                this.lastKnownResumeTextCount = MinLengthNotMetText.Length;
                this.richTextBox1.Text = MinLengthNotMetText;
                return false;
            }

            //otherwise, its a go!
            return true;
        }

        /* Method: MeetsQualifications
         * Purpose: Checks Qualifications form to check for certain qualifications to determine if applicant is a fit, and returns a bool
         * depending on the results
         * Requirements are that they hit the UX Designer CheckBox in the Experience group and that they hit the 10+ years experience
         * Radio Button in the years experience group
         * Limitations: none
         */
        private bool MeetsQualifications()
        {
            
            if(applicantQualitiesRef.TenPlusExperience() && applicantQualitiesRef.UXDesignerExperience())
            {
                return true;
            }

            return false;

        }


    }
}
