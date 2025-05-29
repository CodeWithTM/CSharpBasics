using System;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;

namespace CApp_Practice
{
    internal class string_String
    {
        public void Main()
        {
            string svar = "";
            for(int i=-0; i<1000000; i++)
            {
                svar += i;
            }
            int? @int = null;
            
            //string intNum = @int.Value.ToString(); // throws exception if value is null
            Convert.ToString( @int ); //It will handle null values and return empty string in case of null value

            string s = Convert.ToString(123, new CustomNumberFormatProvider());

            Console.WriteLine(s.ToString());

            string str = ""; //alias to String class
            String str1 = "";   

            //both of this points to --> public sealed class String {}
            //but if we use String class then using System; namespace has to be added.. and that is not the case with string bcoz its an alias and its fixed.. it will keep on referencing String class

            str = new string(new char[] { 'A'});

            //str = new String(new char[] { 'A' });

            str1 = new String(new char[] { 'B' });

            str.ToLower();

            //str1.ToLower();
        }
    }

    public class StringFormatter : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            return arg.ToString();
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            return null;
        }
    }

    public class CustomNumberFormatProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is IFormattable formattable)
            {
                // Custom formatting logic
                return $"[Formatted: {formattable.ToString(format, CultureInfo.InvariantCulture)}]";
            }
            return arg.ToString();
        }
    }


    //if some1 create class with name String, then above variable keep referencing this class rathar than the class inside System namespace

    //public class String
    //{
    //    public String(char[] c)
    //    {

    //    }
    //}
}
