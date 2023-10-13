using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeQuestions_UT1
{
    /* Author: Andrew Black
     * Purpose: Class asks User up to 3 different questions. Class written as part of Unit Test 1.
     * Limitations: none
     */
    internal class Program
    {
        //create timer for answers
        static System.Timers.Timer timer;

        //timer state
        static bool timeOut = false;

        //int val for question user chose
        static int userPick = 0;

        /* Class: Main
         * Purpose: Asks User Questions
         * Limitations: none
         */
        static void Main(string[] args)
        {
            //declare string to hold user answer
            string userAnswer;

            //declare start to goto later
            Start:  

            //do/while to get question choice from user
            do
            {
                //declare purpose to user
                Console.Write("Choose your questions (1-3) ");

                //try to get an int, continue otherwise
                try
                {
                    userPick = int.Parse(Console.ReadLine());
                }
                catch
                {
                    continue;
                }
            
                //repeast if userpick is out of bounds
            } while (userPick < 1 || userPick > 3);

            //alert user of timer and start timer
            Console.WriteLine("You have 5 seconds to answer the following question");

            timeOut = false;
            timer = new System.Timers.Timer(5000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(TimesUp);
            timer.Start();

            //output to console different strings depending on the question pick
            switch(userPick)
            {
                //each case has the same process so i'll just write for this one

                //output question to user then get their answer
                case 1:
                    Console.WriteLine("What is your favorite color?");
                    userAnswer = Console.ReadLine();
                    
                    //if correct stop timer and let them know they did well
                    //as long as timer hasn't timed out. 
                    if(userAnswer == "black" && !timeOut)
                    {
                        Console.WriteLine("Well done!");
                        timer.Stop();

                    //else if wrong stop timer and let them know the correct answer
                    }else if(userAnswer != "black" && !timeOut)
                    {
                        Console.WriteLine("WRONG!  The answer is: black");
                        timer.Stop();
                    }
                        
                    //notably if the user timed out nothing is output in any switch case.
                    //that is done in its own method, TimesUp()

                    break;

                case 2:
                    Console.WriteLine("What is the answer to life, the universe and everything?");
                    userAnswer = Console.ReadLine();

                    if (userAnswer == "42" && !timeOut)
                    {
                        Console.WriteLine("Well done!");
                        timer.Stop();
                    }
                    else if (userAnswer != "42" && !timeOut)
                    {
                        Console.WriteLine("WRONG!  The answer is: 42");
                        timer.Stop();
                    }

                    break;

                case 3:
                    Console.WriteLine("What is the airspeed velocity of an unladen swallow?");
                    userAnswer = Console.ReadLine();

                    if (userAnswer == "What do you mean? African or European swallow?" && !timeOut)
                    {
                        Console.WriteLine("Well done!");
                        timer.Stop();
                    }
                    else if (userAnswer != "What do you mean? African or European swallow?" && !timeOut)
                    {
                        Console.WriteLine("WRONG!  The answer is: What do you mean? African or European swallow?");
                        timer.Stop();
                    }
                    break;

            }

            //declare PlayAgain to goto later
            PlayAgain:

            //ask user if they want to keep playing
            Console.Write("Play again? ");

            //get response
            userAnswer = Console.ReadLine().ToLower();

            //check if they didn't just hit 'Enter,' if so we goto PlayAgain and ask again
            if (userAnswer.Length > 0)
            {
                //if user wants to play again goto Start
                if (userAnswer[0] == 'y')
                {
                    goto Start;
                }
                //if they don't exit program
                else if (userAnswer[0] == 'n')
                {
                    Environment.Exit(0);
                }
                //if they didn't answer y/n ask them again until they do
                else
                {
                    goto PlayAgain;
                }
            }
            else
            {
                goto PlayAgain;
            }


        }

        /* Method: TimesUp
        * Purpose: Keep Track Of User Timing Out
        * Restrictions: none
        */
        private static void TimesUp(object sender, EventArgs e)
        {
            //inform user their time is up and stop timer, then call helper function
            Console.Write("\nTime's Up!\n");
            timeOut = true;
            timer.Stop();
            TimesUpPrintAnswer();
        }

        /* Method: TimesUpPrintAnswers
        * Purpose: Print the Answers to Question When Time Is Up. Advantage as opposed to waiting in main code is 
        * answer is printed immediately upon timer being up.
        * Restrictions: None
        */
        private static void TimesUpPrintAnswer()
        {
            //based on which question user asked, write the answer
            switch (userPick) { 
                case 1:
                    Console.WriteLine("The answer is: black");
                    break;
                case 2:
                    Console.WriteLine("The answer is: 42");
                    break;
                case 3:
                    Console.WriteLine("The answer is: What do you mean? African or European swallow?");
                    break;

            }

            //ask user to press enter to proceed in 'answering' question in main method to move program along
            Console.Write("Please press Enter");
        }
    }
}
