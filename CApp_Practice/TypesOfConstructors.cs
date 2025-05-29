using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{
    public class TypesOfConstructors
    {

        public void M1(ref int i)
        {

        }
        public void Main()
        {
            
            //Book storyBook = new Book() { Title = "T", Author = "A" };
            //storyBook.AddPage(1, "desc1");
            //storyBook.AddPage(2, "desc2");



            BaseClass baseClass = new BaseClass(2);



            //int j = baseClass.I;

            //DerivedClass derivedClass = new DerivedClass();

            //BaseClass baseClass = new DerivedClass();


            //If we assign value like below then constructor will not be invoked..
            BaseClass baseClass1 = baseClass;

            //In below case none of the constructor will be invoked, and b will hold null reference..
            //we need to use new keyword for creating an instance
            BaseClass b;


            baseClass.BMEthod();
        }

    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public List<Page> Pages { get; set; } = new List<Page>();
        private Book() {

            Console.WriteLine("Book constructor");
        }
        
        public void AddPage(int pagenumber, string content)
        {
            Pages.Add(new Page { pageNumber = pagenumber, Content = content });
            
        }
        public class Page : Book // even if Book class has private C, nested class can inherite it
        {
            public int pageNumber { get; set; }

            public string Content { get; set; }

            public Page()
            {
                // even if Book class has private C, we can create its instance inside nested class
                new Book();
                Console.WriteLine("Page constructor");
            }
        }
    }



    public class Parent
    {

    }

    public class Child : Parent
    { 
    
    }

    public class BaseClass
    {
        private int i = 10;

        public int I
        {
            get
            {
                return i;
            }
            set
            {
                i = value;
            }
        }

        public BaseClass() { }

        public BaseClass(int initialVal)
        {
            i = initialVal;
        }

        public void BMEthod() { }


    }

    public class DerivedClass : BaseClass
    {

        public DerivedClass() : base()
        {

        }

        public void DMethod() { }


    }

    public class  AnotherDerivedcls : BaseClass
    {
        public AnotherDerivedcls() : base (2)
        {

        }
    }
}
