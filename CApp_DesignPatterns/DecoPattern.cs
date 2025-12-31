using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_DesignPatterns
{

    //THIS IS JUST A PRACTICE CLASS - ACTUAL CLASS : DecoratorPattern.cs
    internal class DecoPattern
    {
        public static void MainClient()
        {
            IText painText = new PlainText("Hello, World!");

            BoldDecorator boldDecorator = new BoldDecorator(painText);

            string decoratedTxt = boldDecorator.Render();
        }
    }

    public interface IText
    {
        string Render();
    }

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

    public abstract class TextDecorator
    {
        private readonly IText _innerText;


        public TextDecorator(IText innerText)
        {
            _innerText = innerText;
        }

        public virtual string Render()
        {
            return _innerText.Render();
        }

        //public abstract string Render();
    }

    public class BoldDecorator : TextDecorator
    {
        public BoldDecorator(IText innerText) : base(innerText)
        {
        }

        public override string Render()
        {
            return "<b>" + base.Render() + "</b>";
        }
    }
}
