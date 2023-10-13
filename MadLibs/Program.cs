using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*@author: Andrew Black @since 9/14/23
 *@purpose: this program acts as a virtua madlibs generator. It accepts a text file full of madlibs stories and by looking through the strings in that file can determine
 *what parts are of the story and what parts are madlibs the user needs to fill out.
 *@limitations: requires user for inputs. In addition, has a single file full of six madlibs with no way to update, meaning it's not built for long term support. 
 */
namespace MadLibs
{
    internal class Program
    {
        /*@purpose: main method does everything in this program per assignment instructions. makes streamreader, asks for input, prints story, etc.
         *@limitations: same as namespace header limitations
         */
        static void Main(string[] args)
        {
            //filepath used per assignment instructions
            const string filepath = "c:\\templates\\MadLibsTemplate.txt";

            //will hold every line of the text file
            string[] fileLines;

            //the min story choice the user is allowed to enter
            const int storyMin = 1;

            //max story choice user can enter, based on filepath's amount of lines
            int storyMax;

            //the users story option. starts at an unusable value to be checked against later for a valid one (to ensure a loop runs correctly)
            int storyOption = -1;

            //what the final story will be held in
            string finalStory = "";

            //streamreader to read from file
            StreamReader input = null;

            //ensure we can read from file with try/catch/finally
            try {
                input = new StreamReader(filepath);

                //nextline is null to begin with to start, then we instantiate a linecount to determine how many lines
                string nextLine = null;
                int lineCount = 0;

                //run until end of file
                while ((nextLine = input.ReadLine()) != null)
                {
                    //count lines
                    lineCount++;
                }

                //set story max to max array index an array could hold from linecount
                storyMax = lineCount - 1;

                //set filelines to be of size linecount
                fileLines = new string[lineCount];

                //set index counter for another while statement
                int indexCounter = 0;

                //close first streamreader
                input.Close();

                //open another streamreader
                input = new StreamReader(filepath);

                //use a while loop in conjunction with index counter to add all text lines from fil to fileLines array
                while ((nextLine = input.ReadLine()) != null && indexCounter < fileLines.Length)
                {
                    fileLines[indexCounter] = nextLine;
                    indexCounter++;
                }

                //close second streamreader
                input.Close();


                //introduce user to program
                Console.WriteLine("Welcome to Madlibs! Here we have a handful of stories that you get to help write.\nIt's easy, just write in a word for the appropriate prompt" +
                    " when asked and we'll give you the story at the end.\n");

                Console.WriteLine("Would you like to proceed with the program? Yes or no?\n");

                //bool for upcoming while loop 
                bool proceed = false;

                //fun ints that keep track of incorrect user inputs to output snarky responses
                int annoyanceCounter = 0;
                const int getAggressiveLimit = 3;

                //while loop. proceed = true when user says yes
                while (!proceed)
                {
                    //users choice is read
                    string choice = Console.ReadLine();


                    if (choice.ToLower() == "yes")
                    {
                        proceed = true;

                        //exits program
                    } else if (choice.ToLower() == "no")
                    {
                        Environment.Exit(0);

                        //if we get too annoyed, annoy the user back
                    } else if (annoyanceCounter >= getAggressiveLimit)
                    {
                        Console.WriteLine("Since you're insisted on playing games, I just deleted a random file on your computer. I'll keep doing this until you enter 'yes' or 'no.'\n");
                    }
                    //count annoyances and let user know we need an acceptable answer
                    else
                    {
                        Console.WriteLine("That's not an acceptable input, please try again.\n");
                        annoyanceCounter++;
                    }
                }


                //prompt user for a number within our array values. numbers edited later to match array value so we start at 1 and end at storyMax+1 (one past max index of storyLines[])
                Console.WriteLine("Okay, before we start, pick a integer number between " + storyMin + " and " + (storyMax + 1) + ". We'll pick a story from your choice.\n");

                bool rejectUserChoice = true;

                //reject userchoice if it's out of bounds
                while (rejectUserChoice)
                {
                    try
                    {
                        //storyOption is -1 so it fits in array bounds
                        storyOption = int.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine();
                    }
                    catch
                    {
                        //if we don't get an int from the user, catch and set story option to 1. we do this so we don't trigger the oncoming if/else statement
                        Console.WriteLine("Error, that is not an option! Please pick a integer number between " + storyMin + " and " + (storyMax + 1) + ". We'll pick a story from your choice.\n");
                        storyOption = 1;
                    }

                    //if the user choice is out of bounds, let them know.
                    if (storyOption > storyMax || storyOption < (storyMin - 1))
                    {
                        Console.WriteLine("Error, that is not an option! Please pick a integer number between " + storyMin + " and " + (storyMax + 1) + ". We'll pick a story from your choice.\n");
                    }
                    else
                    {
                        //if everything checks out, let the user out of the while loop
                        rejectUserChoice = false;
                    }
                }

                //split each line in storyLines[] into a string array containing each individual string
                string[] storySplit = fileLines[storyOption].Split();

                //go through whole array
                for (int i = 0; i < storySplit.Length; i++)
                {

                    //look for \ at start of string. all \ indiciate new line statements, so if we find one add a newline to the story
                    if (storySplit[i].Substring(0, 1) == "\\")
                    {
                        finalStory += "\n";

                        //look for { at start of string. all { indicate that there's a madlib that the user needs to fill out. 
                    } else if (storySplit[i].Substring(0, 1) == "{")
                    {
                        //check for comma so we can add one at the end
                        bool addComma = false;

                        if (storySplit[i].Contains(','))
                        {
                            addComma = true;
                            //remove comma for now
                            storySplit[i] = storySplit[i].TrimEnd(',');
                        }

                        //existance of { implies existence of }. remove both
                        storySplit[i] = storySplit[i].TrimEnd('}');
                        storySplit[i] = storySplit[i].TrimStart('{');

                        //madlibs use _ isntead of spaces. replace.
                        storySplit[i] = storySplit[i].Replace('_', ' ');

                        //get user response. any input is a string so no need for a try catch
                        Console.Write("Please enter a(n): " + storySplit[i] + "\n");
                        storySplit[i] = Console.ReadLine();

                        //add to final story
                        finalStory += storySplit[i] + " ";

                        //add comma if there is one
                        if (addComma)
                        {
                            finalStory += ",";
                        }
                    }
                    //if nothing of interest ,just add the string to finalstory
                    else
                    {
                        finalStory += storySplit[i] + " ";
                    }
                }

                //print story to user
                Console.Write(finalStory);

            //inform user if file not found
            }catch (FileNotFoundException e)
            {

                Console.WriteLine("Error, file not found. Please ensure 'MadLibsTemplate.txt' is in your 'c:\\\\templates' folder.");
            }

            //close reader no matter what
            finally
            {
                input.Close();
            }
        }

    }
}

