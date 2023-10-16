using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatsDogs;

namespace PE13___CatsDogs
{
    /* Author: Andrew Black since 10/16/23
     * Purpose: Program makes use of Cat and Dog classes for practice
     * Limitations: Requires use of CatsDogs library
     */
    internal class Program
    {
        /* Method: Main
         * Purpose: Create Pets and use some of their functions
         * Limitations: none
         */
        static void Main(string[] args)
        {
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            Pets pets = new Pets();

            Random rand = new Random();

            for(int i = 0; i < 50; i++)
            {
                //if else provided by professor
                // 1 in 10 chance of adding an animal
                if (rand.Next(1, 11) == 1)
                {

                    string name;
                    int age;
                    string license;

                    //add dog
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("Congratulations on adopting a dog!\n" +
                            "What's their name?");
                        name = Console.ReadLine();

                    askAge:
                        Console.WriteLine("What's their age?");
                        try
                        {
                            age = Int16.Parse(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            goto askAge;
                        }

                        Console.WriteLine("What's their license?");
                        license = Console.ReadLine();

                        pets.Add(new Dog(license, name, age));

                    }

                    // else add a cat
                    else
                    {
                        Console.WriteLine("Congratulations on adopting a cat!\n" +
                            "What's their name?");
                        name = Console.ReadLine();

                    askAge:
                        Console.WriteLine("What's their age?");
                        try
                        {
                            age = Int16.Parse(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            goto askAge;
                        }

                        cat = new Cat
                        {
                            Name = name,
                            age = age
                        };

                        pets.Add(cat);
                        

                    }
                }
                else
                {
                    // choose a random pet from pets and choose a random activity for the pet to do

                    thisPet = pets[rand.Next(0, pets.Count)];

                    //number of random activities is five, used in switch case
                    int activity = rand.Next(0, 5);

                    if (thisPet == null)
                    {
                        continue;
                    }

                    //try for each interface possibility
                    try { 
                        iCat = (ICat)thisPet;
                        switch (activity)
                        {
                            //pick one of five activities
                            case 0:
                                iCat.Eat();
                                break;
                            case 1:
                                iCat.Play();
                                break;
                            case 2:
                                thisPet.GotoVet();
                                break;
                            case 3:
                                iCat.Purr();
                                break;
                            case 4:
                                iCat.Scratch(); 
                                break;
                        }
                    }

                    catch 
                    { 
                        iDog = (IDog)thisPet;
                        switch (activity)
                        {
                            //pick one of five activities
                            case 0:
                                iDog.Eat();
                                break;
                            case 1:
                                iDog.Play();
                                break;
                            case 2:
                                thisPet.GotoVet();
                                break;
                            case 3:
                                iDog.Bark();
                                break;
                            case 4:
                                iDog.NeedWalk();
                                break;
                        }
                    }


                }

            }
        }
    }
}
