using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PE13___More_Classess.Program;

namespace PE13___More_Classess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            Pets pets = new Pets();

            Random rand = new Random();

            for (int i = 0; i < 50; i++)
            {
                // 1 in 10 chance of adding an animal
                if (rand.Next(1, 11) == 1)
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        // add a dog

                    }
                    else
                    {
                        // else add a cat

                    }
                }
                else
                {
                    // choose a random pet from pets and choose a random activity for the pet to do
                }

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

            public int Count 
            {
                get
                {
                    return petList.Count;
                }
            }

            public void Add(Pet pet)
            {
                petList.Add(pet);
            }

            public void Remove(Pet pet)
            {
                petList.Remove(pet);
            }

            public void RemoveAt(int petEL)
            {
                petList.RemoveAt(petEL);
            }
        }


        public abstract class Pet
        {
            private string name;
            public int age;

            public string Name
            {
                get;

                set;
            }

            public abstract void Eat();

            public abstract void Play();

            public abstract void GoToVet();

            public Pet()
            {

            }

            public Pet(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
        }

        





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

            void Bakr();

            void NeedWalk();
            void GoToVet();
        }

        public class Dog : Pet
        {
            public override void Eat()
            {

            }

            public override void Play()
            {

            }

            public void Purr()
            {

            }

            public void Scratch()
            {

            }

            public override void GoToVet()
            {

            }
        }

        public class Cat : Pet
        {
            public override void Eat()
            {

            }

            public override void Play()
            {

            }

            public void Bark()
            {

            }

            public void NeedWalk()
            {

            }

            public override void GoToVet()
            {

            }
        }

    }
}
