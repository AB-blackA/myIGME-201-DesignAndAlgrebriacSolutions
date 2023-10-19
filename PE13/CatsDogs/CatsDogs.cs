using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsDogs
{
    public interface ICat
    {

        void Eat();

        void Play();

        void Scratch();

        void Purr();

    }

    public interface IDog
    {
        void Eat();

        void Play();

        void Bark();

        void NeedWalk();

        void GotoVet();

    }

    public abstract class Pet
    {

        private string name;

        public int age;

        public Pet()
        {

        }

        public Pet(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public abstract void Eat();
        public abstract void Play();
        public abstract void GotoVet();

        
    }

    public class Cat : Pet, ICat
    {
        public Cat()
        {

        }

        public override void Eat()
        {
            Console.WriteLine("{0}: I cannot wait for you to perish so I can eat something GOOD for once...", base.Name);
        }

        public override void GotoVet()
        {
            Console.WriteLine("{0}: Time to dissapear!!! *scrams*", base.Name);
        }

        public override void Play()
        {
            Console.WriteLine("{0}: For what reason do you interrupt me, huma- IS THAT A FEATHER ON A STRING? *paws wildly*", base.Name);
        }

        public void Purr()
        {
            Console.WriteLine("{0}: Prrrrrrrrrrrrrhh...", base.Name);
        }

        public void Scratch()
        {
            Console.WriteLine("{0}: *HISSSSSSSSSSS*", base.Name);
        }
    }

    public class Dog : Pet, IDog
    {

        public string license;

        public Dog(string license, string name, int age)
        {
            this.license = license;
            base.Name = name;
            base.age = age;
        }

        public void Bark()
        {
            Console.WriteLine("{0}: WOOF WOOF *WAGS TAIL*", base.Name);
        }

        public override void Eat()
        {
            Console.WriteLine("{0}: I WOULD EAT ANYTHING FROM YOU, BEST FRIEND FOREVER", base.Name);
        }

        public override void GotoVet()
        {
            Console.WriteLine("{0}: WHY HAVE YOU FORSAKEN ME *whimpers*", base.Name);
        }

        public void NeedWalk()
        {
            Console.WriteLine("{0}: IF I SCRATCH THE DOOR ENOUGH IT WILL OPEN", base.Name);
        }

        public override void Play()
        {
            Console.WriteLine("{0}: GET BALL RETURN BALL GET BALL RETURN BALL BALL BALL BALL", base.Name);
        }
    }

    public class Pets
    {
        List<Pet> petList = new List<Pet>();

        public Pet this[int nPetEl]
        {
            get
            {
                Pet returnVal;
                try
                {
                    returnVal = (Pet)petList[nPetEl];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                // if the index is less than the number of list elements
                if (nPetEl < petList.Count)
                {
                    // update the existing value at that index
                    petList[nPetEl] = value;
                }
                else
                {
                    // add the value to the list
                    petList.Add(value);
                }
            }
        }

        public  int Count
        {
            get { return this.petList.Count; }
        }

        public void Add(Pet pet)
        {
            this.petList.Add(pet);
        }

        public void Remove(Pet pet)
        {
            this.petList.Remove(pet);
        }

        public void RemoveAt(int petEI)
        {
            this.petList.RemoveAt(petEI);
        }
    }
}
