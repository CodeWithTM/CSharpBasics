using CApp_Practice;


//consider  this as code inside another assembly / class library project
namespace AnotherNS
{
    public class A1Modifier
    {
        public void m1()
        {
            //so in that case as this prop is marked with internal AM, it will be accessible
            AModifier accessModifiers = new AModifier();
            accessModifiers.Name = "";
        }
    }
}

namespace CApp_Practice
{

    //with access modifiers we achieve ENCAPSULATION, so that misuse of data can b prevented

    class AccessModifiers
    {
        public void Main()
        {
            AModifier aModifier = new AModifier();

        }
    }

    public class AModifier
    {
        public AModifier() { }

        public int MyProperty { get; set; }

        internal string Name { get; set; }
        public void M()
        {
        }
    }
    //protected - within a class and its derived class

    public class DModifier : AModifier
    {
        public void M2()
        {
            MyProperty = 1;
            Name = "a";
        }

        //static method needs a obj reference..
        public static void SM()
        {
            AModifier aModifier = new AModifier();
            aModifier.MyProperty = 1;
            aModifier.Name = "a";
        }
    }

    public class D1Modifier : DModifier
    {
        public void M3()
        {
            Name = "b";
        }
    }
}


