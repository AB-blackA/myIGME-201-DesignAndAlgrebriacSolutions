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

            string[] fileLines;
            int storyOption;

            StreamReader input = null;

            try
            {
                input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");


                string nextLine; ;
                int lineCount = 0;
                while ((nextLine = input.ReadLine()) != null)
                {

                    lineCount++;
                    Console.WriteLine(nextLine);
                    Console.WriteLine();
                }


               /* fileLines = new string[lineCount];
                storyOption = fileLines.Length;

                for (int i = 0; i < nextLine.Length; i++)
                {
                    fileLines[i] = nextLine.Substring(i);
                }

                Console.WriteLine(fileLines[3]);*/

            }
            catch
            {
                Console.WriteLine(("Filepath not found, please ensure \"MadLibsTemplate.txt\" is in your \"c:\\\\templates\" directory "));
            }

            finally
            {
                if (input != null)
                {
                    input.Close();
                }

            }
        }
    }
}
