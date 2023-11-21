using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web;

namespace TriviaApp
{

    class Trivia
    {
        public int response_code;
        public List<TriviaResult> results;
    }

    class TriviaResult
    {
        public string category;
        public string type; //multiple and bool
        public string difficulty;
        public string question;
        public string correct_answer;
        public List<string> incorrect_answers;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string url = null;
            string s = null;

            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader reader;

            url = "https://opentdb.com/api.php?amount=1&type=multiple";

            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());    
            s = reader.ReadToEnd();
            reader.Close();

            Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);

            for (int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
            {
                trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
            }

            //output question to user
            Console.WriteLine(trivia.results[0].question + "\n");

            //add all possible answers to list of strings
            List<string> choices = new List<string>();
            choices.Add(trivia.results[0].correct_answer);
            choices.Add(trivia.results[0].incorrect_answers[0]);
            choices.Add(trivia.results[0].incorrect_answers[1]);
            choices.Add(trivia.results[0].incorrect_answers[2]);

            Random random = new Random();

            //randomize contents of list
            for(int i = 0; i <  choices.Count; ++i)
            {
                int swap = random.Next(0, choices.Count);
                string temp;

                temp = choices[i];
                choices[i] = choices[swap];
                choices[swap] = temp;
            }

            //print out choices for user
            int answerCount = 1;
            foreach (string choice in choices)
            {
                Console.WriteLine(answerCount + " " + choice);
                answerCount++;
            }

            GetAnswer:
            //prompt an answer
            Console.WriteLine("\nYour Answer (write the number!): ");
            try
            {
                int answer = Int32.Parse(Console.ReadLine());

                //inform user if they are correct or not (show answer if not)
                if (choices[answer - 1] == trivia.results[0].correct_answer)
                {
                    Console.WriteLine("Correcto!!!");
                }
                else
                {
                    Console.WriteLine("Sorry, the correct answer was " + trivia.results[0].correct_answer);
                }
            }
            catch (Exception e)
            {
                goto GetAnswer;
            }
            
        }
    }
}
