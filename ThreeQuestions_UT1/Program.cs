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


        static int userPick = 0;

        /* Class: Main
         * Purpose: Asks User Questions
         * Limitations: none
         */
        static void Main(string[] args)
        {
            string userAnswer;
            bool keepPlaying = true;

            do
            {

                do
                {
                    Console.Write("Choose your questions (1-3) ");

                    try
                    {
                        userPick = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        continue;
                    }
                } while (userPick < 1 || userPick > 3);

                Console.WriteLine("You have 5 seconds to answer the following question");

                timeOut = false;
                timer = new System.Timers.Timer(5000);
                timer.Elapsed += new System.Timers.ElapsedEventHandler(TimesUp);
                timer.Start();

                switch(userPick)
                {
                    case 1:
                        Console.WriteLine("What is your favorite color?");
                        userAnswer = Console.ReadLine();

                        if(userAnswer == "black" && !timeOut)
                        {
                            Console.WriteLine("Well done!");
                            timer.Stop();

                        }else if(userAnswer != "black" && !timeOut)
                        {
                            Console.WriteLine("WRONG!  The answer is: black");
                        }
                        
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
                        }
                        break;

                }


                do
                {
                    Console.Write("Play again? ");

                    userAnswer = Console.ReadLine().ToLower();

                    if (userAnswer.Length > 0)
                    {
                        if (userAnswer[0] == 'y')
                        {
                            keepPlaying = true;
                        }
                        else if (userAnswer[0] == 'n')
                        {
                            keepPlaying = false;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }

                } while (userAnswer == "12"); 

                

            } while (keepPlaying);

            

        }

        /* Method: TimesUp
        * Purpose: Keep Track Of User Timing Out
        * Restrictions: None
        */
        private static void TimesUp(object sender, EventArgs e)
        {
            Console.Write("\nTime's Up!\n");
            timeOut = true;
            timer.Stop();
            TimesUpPrintAnswer();
        }

        private static void TimesUpPrintAnswer()
        {
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
        }
    }
}
