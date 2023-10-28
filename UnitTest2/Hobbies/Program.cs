using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobbies
{
    interface IEBook
    {
        void Scroll();
        void Bookmark();
        void Exit();
    }

    interface IPhysicalBook
    {
        void FlipPage();
        void DogEar();
        void Close();
    }

    public abstract class Book
    {

        private string bookTitle;
        public string author;

        public string BookTitle
        {
            get
            {
                return this.bookTitle;
            }

            set
            {
                this.bookTitle = value;
            }
        }

        public abstract void BeginReading();
        public abstract void FinishReading();

        public virtual void ReadSummary()
        {
        }
    }



    public class Paperback : Book, IPhysicalBook
    {
        public Paperback()
        {

        }

        public void FlipPage()
        {

        }

        public void DogEar()
        {
            Console.WriteLine("Why would you do such a thing...");
        }
        public void Close()
        {

        }


        public override void BeginReading()
        {
        }

        public override void FinishReading()
        {
        }

    }



    public class Kindle : Book, IEBook
    {
        public Kindle()
        {

        }

        public void Scroll()
        {

        }
        public void Bookmark()
        {

        }
        public void Exit()
        {

        }
        

        public override void BeginReading()
        {
        }

        public override void FinishReading()
        {
        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Kindle kindle = new Kindle();
            Paperback paperback = new Paperback();

            MyMethod(kindle);
            MyMethod(paperback);
        }

        static void MyMethod(object obj)
        {
            if (obj is IEBook)
            {
                IEBook iEBook = (IEBook)obj;
                iEBook.Bookmark();
            }

            if (obj is IPhysicalBook)
            {
                IPhysicalBook iPhysicalBook = (IPhysicalBook)obj;
                iPhysicalBook.DogEar();
            }
        }

    }

}

