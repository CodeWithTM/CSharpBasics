using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_DesignPatterns
{
    internal class DecoratorPattern
    {

        // Decorator is a structural design pattern
        // that allows to add additional functionality to an object dynamically.

        // The decorator pattern is typically used to extend the functionalities of classes in a flexible and reusable way,
        // which can otherwise be implemented using sub classing

        //as an example, consider a simple text editor application that allows users to format text.
        //so we have plain text class, on top of it we want to add functionalities like bold, italic, underline etc

        //show me complete source code below
        public static void MainClient()
        {
            IText plainText = new PlainText("Hello, World!");

            IText boldText = new BoldDecorator(plainText);
            IText italicBoldText = new ItalicDecorator(boldText);


            Console.WriteLine("Plain Text: " + plainText.Render());
            Console.WriteLine("Bold Text: " + boldText.Render());
            Console.WriteLine("Italic Bold Text: " + italicBoldText.Render());

            //cerate cascaded like object creation
            IText decoratedTxt = new ItalicDecorator(new BoldDecorator(new PlainText("Sample Text")));

            Console.WriteLine(decoratedTxt);
        }
        // Component interface
        public interface IText
        {
            string Render();
        }
        // Concrete component
        public class PlainText : IText
        {
            private readonly string _text;

            public PlainText(string text)
            {
                _text = text;
            }

            public string Render()
            {
                return _text;
            }
        }
        // Base decorator
        public abstract class TextDecorator : IText
        {
            protected readonly IText _innerText;

            public TextDecorator(IText innerText)
            {
                _innerText = innerText;
            }

            public abstract string Render();
        }

        // Concrete decorator for bold text
        public class BoldDecorator : TextDecorator
        {
            public BoldDecorator(IText innerText) : base(innerText) { }

            public override string Render()
            {
                return "<b>" + _innerText.Render() + "</b>";
            }
        }
        // Concrete decorator for italic text
        public class ItalicDecorator : TextDecorator
        {
            public ItalicDecorator(IText innerText) : base(innerText) { }

            public override string Render()
            {
                return "<i>" + _innerText.Render() + "</i>";
            }
        }


    }
}
