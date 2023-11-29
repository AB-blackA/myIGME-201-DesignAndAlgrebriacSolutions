using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Class: GameForm
 * Author: Andrew Black
 * Purpose: Windows Form that allows a User to play a simple Guessing Game
 * Limitations: none
 */
namespace PE17___Guessing_Game
{
    /* 1. TextField for user to enter numbers to guess
     * 2. Display label to hint user on if their guess was too high or low
     * 3. Another display label to show the range of the guessing game
     * 4. Third display label to inform user where they should insert their guess
     * 5. Button for user to hit when they want to insert a guess
     * 6. Progress bar that works with timer to display how much time user has left
     */

    public partial class GameForm : Form
    {
        private Random rnd = new Random();

        private int lowNumber;
        private int highNumber;

        //random number is the "correct" number needed to be guesses in order to win
        private int randomNumber;

        private Timer timer;
        private bool timerStarted = false;
        private int gameTime = 45; //45 seconds

        public GameForm(int lowNumber, int highNumber)
        {
            InitializeComponent();

            //set our low and high numbers to the ones passed in, and update range label
            this.lowNumber = lowNumber;
            this.highNumber = highNumber;
            this.rangeLabel.Text = String.Format("Range of Game is {0} to {1}", lowNumber, highNumber);

            //pick out "correct" number
            this.randomNumber = rnd.Next(lowNumber, highNumber + 1);

            guessButton.Click += new EventHandler(GuessButton__Click);
        }

        /* Method: GuessButton__Click
         * Purpose: EventHandler for guessButton that takes users gusses's from guessTextBox
         * and uses that information to display to user how close they are to the correct number
         * Limitations: none
         */
        private void GuessButton__Click(object sender, EventArgs e)
        {
            //bool for checking if the entered value is acceptable
            bool guessAcceptable = true;

            //check each character in guess to ensure they're digits and not chars
            foreach (char c in this.guessTextBox.Text)
            {
                if (!Char.IsDigit(c) && this.guessTextBox.Text.Length > 0)
                {
                    guessAcceptable = false;
                }
            }

            //try to convert the user's guess to an int 
            if (guessAcceptable) 
            {

                //on first loop only, startTimer
                //StartTimer function will change the value of timerStarted to false
                if (!timerStarted)
                {
                    StartTimer();
                }

                //parse guess to int
                int guess = Int32.Parse(this.guessTextBox.Text);

                //then check if guess is lower, higher, or IS the correct number. in the former cases, output how their guess aligns 
                //with the actual number
                //in the latter, we call out CongratulateUser function
                if (guess < this.randomNumber) 
                {
                    this.hintLabel.Text = String.Format("{0} was too LOW!", guess);
                }
                else if (guess > this.randomNumber)
                {
                    this.hintLabel.Text = String.Format("{0} was too HIGH!", guess);
                }
                else //user wins
                {
                    CongratulateUser(guess);
                }
            }
        }

        /* Method: Congratulate User
         * Purpose: Inform User they Won the Game. Stops the timer and closes the window.
         * Limitations: none
         */
        private void CongratulateUser(int winningNum)
        {
            //stop timer
            this.timer.Stop();

            //show user they have won, then close the window
            MessageBox.Show(String.Format("Congratulations! {0} Was the Correct Number!", winningNum));
            this.Close();
        }

        /* Method: StartTimer
         * Purpose: starts the timer which runs the pace of the game
         * Limitations: must set timerStarted to true to ensure GuessButton__Click method doesn't break
         */
        private void StartTimer()
        {
            //make a new timer
            this.timer = new Timer();

            //set interval and event handler
            this.timer.Interval = 500;
            this.timer.Tick += new EventHandler(Timer__Tick);
            this.timer.Start();

            this.timerStarted = true;

        }

        /* Method: Timer__Tick
         * Purpose: Update the toolStripProgressBar1 for each timer tick. As well, checks if toolStripProgressBar1
         * reaches value of 0. If so, call TimeOut function
         * Limitations: none
         */
        private void Timer__Tick(object sender, EventArgs e)
        {
            //countdown the toolStripProgressBar
            //NOTE that the timer ticks every .5 seconds, and by instructions game length is 45 seconds.
            //therefor initial value of toolStripProgressBar must be 90 for this to work correctly
            this.toolStripProgressBar1.Value -= 1;

            //if timer reaches zero, call TimeOut function to end game
            if(this.toolStripProgressBar1.Value <= 0)
            {
                TimeOut();
            }
        }

        /* Method: TimeOut
         * Purpose: Ends the game via a time out, informing user of this while also informing them of the correct number
         * and stopping the timer
         * Limitations: none
         */
        private void TimeOut()
        {
            //stop timer
            this.timer.Stop();

            //inform user of timeout and correct number
            MessageBox.Show(String.Format("Sorry! You ran out of time. The correct number was: {0}", this.randomNumber));

            //close this window
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
