using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Class: Form1
 * Author: Andrew Black, w/ starter code from Professor Schuh
 * Purpose: Form1 Creates a Windows Form that prompts the user for two numbers in order to play a guessing game
 * Limitations: none
 */
namespace PE17___Guessing_Game
{
    /* 1. Create TWO textboxes for low number and high number
     * 2. Create two labels to inform user of those boxes, one for each
     * 3. Create start button to start the program
     */
    public partial class IntroForm : Form
    {
        public IntroForm()
        {
            InitializeComponent();
            startButton.Click += new EventHandler(StartButton_Click);
        }

        /* Method: StartButton_Click
         * Purpose: EventHandler for Form1's startButton, clicking it checks to ensure 
         * numbers in textBoxes are in bounds for a guessing game and then opens the GameForm
         * to play that game
         * Limitations: none
         */
        private void StartButton_Click(object sender, EventArgs e)
        {
            //i couldn't find a use for this bool :c
            //bool bConv;
            int lowNumber = 0;
            int highNumber = 0;

            // try to convert the strings entered in lowTextBox and highTextBox
            // to lowNumber and highNumber Int32.Parse
            try
            {
                lowNumber = Int32.Parse(lowTextBox.Text);
                highNumber = Int32.Parse(highTextBox.Text);

                // if not a valid range
                // note that this if works great for our default values of 0
                if (highNumber <= lowNumber || lowNumber < 0)
                {
                    // show a dialog that the numbers are not valid
                    MessageBox.Show("The numbers are invalid.");
                }
                else
                {
                    // otherwise we're good
                    // create a form object of the second form 
                    // passing in the number range
                    GameForm gameForm = new GameForm(lowNumber, highNumber);

                    // display the form as a modal dialog, 
                    // which makes the first form inactive
                    gameForm.ShowDialog();
                }
            }
            //if none ints are entered, show user rejection message
            catch
            {
                MessageBox.Show("Integers Only!");
                
            }

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
