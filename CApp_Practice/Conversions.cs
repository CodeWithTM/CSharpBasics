using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{
    internal class Conversions
    {

        //Working with String

        // .ToString() vs Convert.ToString()
        // .ToString() doesnt handle null types. e.g. x.Tostring() if x is null then it will throw an exception
        // Convert.ToString() can handle null values

        // IFormatProvider
        // IFormattable
        // DateTime : IFormattable
        // public string ToString(string format, IFormatProvider provider)


        public static void MainConert()
        {

            NullOrEmpty();

            int x=10;

            x.ToString(new MyFormatProvider());

            Convert.ToString(x);

            DateTime dt = DateTime.Now;

            //string convertedDT = Convert.ToString(dt, "yyyy-MM-dd"); WE CANNOT DO THIS

            string converted =  dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            
            Console.WriteLine(string.Format(new MyFormatProvider(), "{0:U}", "hello"));
            double d = 2345.6;
            d.ToString("", new MyFormatProvider());

            Convert.ToString(dt, CultureInfo.InvariantCulture);
        }

        public static void NullOrEmpty()
        {

            string s = " ";

            bool b= String.IsNullOrEmpty(s); // this will return false because s is not null and it is not empty, it contains a space character

           

            s = "   ";

            int length = s.Length;

            b=string.IsNullOrWhiteSpace(s); // this will return true as s is not null and it is not empty but it contains only whitespace characters

            s = "\t\t";

            s = "\n";

            b= string.IsNullOrEmpty(s); // this will return false because s is not null and it is not empty, it contains a tab character

            b = string.IsNullOrWhiteSpace(s);

            length = s.Length;

            // string.IsNullOrEmpty() checks if the string is null or has a length of 0. It does NOT consider whitespace characters as empty.
        }
    }

    public class MyFormatProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            // If someone asks for an ICustomFormatter, return THIS object
            if (formatType == typeof(ICustomFormatter))
                return this;

            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            // Example custom formatting logic
            if (arg == null)
                return string.Empty;

            // Example: if format = "U" -> uppercase
            if (arg is string s)
            {
                if (string.Equals(format, "U", StringComparison.OrdinalIgnoreCase))
                    return s.ToUpper();

                if (string.Equals(format, "L", StringComparison.OrdinalIgnoreCase))
                    return s.ToLower();
            }

            // fallback to default formatting
            return arg.ToString();
        }
    }
}
