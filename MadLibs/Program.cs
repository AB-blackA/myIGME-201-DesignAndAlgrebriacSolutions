using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MadLibs
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const string filepath = "c:\\templates\\MadLibsTemplate.txt";

            string[] fileLines;
            const int storyMin = 1;
            int storyMax;
            int storyOption = -1;

            string finalStory = "";

            StreamReader input = null;
            
            input = new StreamReader(filepath);


            string nextLine = null;
            int lineCount = 0;
            while ((nextLine = input.ReadLine()) != null)
            {
                lineCount++;
            }

            storyMax = lineCount - 1;
            fileLines = new string[lineCount];
            int indexCounter = 0;

            Console.WriteLine(lineCount);

            input.Close();

            input = new StreamReader(filepath);

            while ((nextLine = input.ReadLine()) != null && indexCounter < fileLines.Length)
            {
                fileLines[indexCounter] = nextLine;
                indexCounter++;
            }

            Console.WriteLine("Welcome to Madlibs! Here we have a handful of stories that you get to help write.\nIt's easy, just write in a word for the appropriate prompt" +
                " when asked and we'll give you the story at the end.\n");
            Console.WriteLine("Okay, before we start, pick a integer number between " + storyMin + " and " + (storyMax+1) + ". We'll pick a story from your choice.\n");

            bool rejectUserChoice = true;

            while (rejectUserChoice)
            {
                try
                {
                    storyOption = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine();
                }
                catch
                {
                    Console.WriteLine("Error, that is not an option! Please pick a integer number between " + storyMin + " and " + (storyMax+1) + ". We'll pick a story from your choice.\n");
                    storyOption = 1;
                }

                if( storyOption > storyMax || storyOption < (storyMin-1)) 
                {
                    Console.WriteLine("Error, that is not an option! Please pick a integer number between " + storyMin + " and " + (storyMax+1) + ". We'll pick a story from your choice.\n");
                }
                else
                {
                    rejectUserChoice = false;
                }
            }

            string[] storySplit = fileLines[storyOption].Split();

            for(int i = 0; i < storySplit.Length; i++)
            {
                if (storySplit[i].Substring(0,1) == "\\")
                {
                    finalStory += "\n";

                }else if(storySplit[i].Substring(0,1) == "{")
                {
                    bool addComma = false;

                    if (storySplit[i].Contains(','))
                    {
                        addComma = true;
                        storySplit[i] = storySplit[i].TrimEnd(',');
                    }
                    storySplit[i] = storySplit[i].TrimEnd('}');
                    storySplit[i] = storySplit[i].TrimStart('{');
                    storySplit[i] = storySplit[i].Replace('_', ' ');

                    Console.Write("Please enter a(n): " + storySplit[i] +"\n");
                    storySplit[i] = Console.ReadLine();

                    finalStory += storySplit[i] + " ";

                    if(addComma)
                    {
                        finalStory += ",";
                    }
                }
                else
                {
                    finalStory += storySplit[i] + " ";    
                }
            }

            Console.Write(finalStory);  
        }

    }
}

