using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PE13___More_Classess.Program;

namespace PE13___More_Classess
{

    interface ICat
    {
        void Eat();
        void Play();
        void Scratch();
        void Purr();
    }

    interface IDog
    {

        void Eat();
        void Play();
        void Bark();
        void NeedWalk();
        void GoToVet();
    }

    public abstract class Pet
    {
        private string name;
        public int age;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public Pet()
        {
        }

        public Pet(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public abstract void Eat();
        public abstract void Play();
        public abstract void GoToVet();
    }


    public class Cat : Pet, ICat
    {
        public Cat()
        {

        }

        public override void Eat()
        {
            Console.WriteLine($"{Name}: Yuck, I don't like that!");
        }

        public override void Play()
        {
            Console.WriteLine($"{Name}: Where's that mouse...");
        }

        public void Purr()
        {
            Console.WriteLine($"{Name}: purrrrrrrrrrrrrrrrrrrr...");
        }

        public void Scratch()
        {
            Console.WriteLine($"{Name}: Hiss!");
        }

        public override void GoToVet()
        {
            Console.WriteLine($"{Name}: Ha! I never do this");
        }
    }


    public class Dog : Pet, IDog
    {
        public string license;

        public Dog(string sLicense, string sName, int nAge) : base(sName, nAge)
        {
            this.license = sLicense;
        }

        public override void Eat()
        {
            Console.WriteLine($"{Name}: Yummy, I will eat anything!");
        }

        public override void Play()
        {
            Console.WriteLine($"{Name}: Throw the ball, throw the ball!");
        }

        public void Bark()
        {
            Console.WriteLine($"{Name}: Woof woof!");
        }

        public void NeedWalk()
        {
            Console.WriteLine($"{Name}: Woof woof, I need to go out.");
        }

        public override void GoToVet()
        {
            Console.WriteLine($"{Name}: Whimper, whimper, no vet!");
        }
    }

    public class Pets
    {
        public List<Pet> petList = new List<Pet>();

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
            if (pet != null)
            {
                petList.Remove(pet);
            }
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




    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            int petEl = 0;

            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            Pets pets = new Pets();

            Random rand = new Random();

            for ( i = 0; i < 50; i++)
            {
                // 1 in 10 chance of adding an animal
                if (rand.Next(1, 11) == 1)
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        // add a dog
                        cat = new Cat();

                        Console.WriteLine("You bought a cat!");

                        Console.Write("Cat's Name => ");
                        cat.Name = Console.ReadLine();

                        Console.Write("Age => ");
                        cat.age = Convert.ToInt32(Console.ReadLine());

                        thisPet = cat;
                    }
                    else
                    {
                        // else add a cat
                        string sLicense;
                        string sName;
                        int nAge;

                        Console.WriteLine("You bought a dog!");

                        Console.Write("Dog's Name => ");
                        sName = Console.ReadLine();

                        Console.Write("Age => ");
                        nAge = Convert.ToInt32(Console.ReadLine());

                        Console.Write("License => ");
                        sLicense = Console.ReadLine();

                        dog = new Dog(sLicense, sName, nAge);

                        thisPet = dog;
                    }

                    pets.Add(thisPet);
                }
                else
                {
                    // choose a random pet from pets and choose a random activity for the pet to do
                    petEl = rand.Next(0, pets.Count);

                    thisPet = pets[petEl];

                    if (thisPet == null)
                    {
                        continue;
                    }

                    if (thisPet.GetType() == typeof(Cat))
                    {
                        iCat = (ICat)thisPet;

                        int nAction = rand.Next(0, 4);
                        switch (nAction)
                        {
                            case 0:
                                iCat.Eat();
                                break;
                            case 1:
                                iCat.Play();
                                break;
                            case 2:
                                iCat.Purr();
                                break;
                            case 3:
                                iCat.Scratch();
                                break;
                        }
                    }
                    else
                    {
                        iDog = (IDog)thisPet;
                        int nAction = rand.Next(0, 5);

                        switch (nAction)
                        {
                            case 0:
                                iDog.Eat();
                                break;
                            case 1:
                                iDog.Play();
                                break;
                            case 2:
                                iDog.Bark();
                                break;
                            case 3:
                                iDog.NeedWalk();
                                break;
                            case 4:
                                iDog.GoToVet();
                                break;
                        }
                    }
                }
            }
        }
    }

}
