using System;
using System.Globalization;


namespace CApp_Practice
{
    public class BasicConcepts
    {
        public void Main()
        {
            string str1 = new DateTime().ToString();

            String str2 = string.Empty;

            if (string.IsNullOrEmpty(str1))
            {

            }

            if (string.IsNullOrWhiteSpace(str2))
            {

            }

            MyStringFormatProvider myCustom = new MyStringFormatProvider();

            string formattedStr = string.Format(myCustom, "{0:Custom}", DateTime.Now);

            //str1.ToString(new MyStringFormatProvider());

        }
    }

    public class MyStringFormatProvider : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is null || format != "Custom")
                return string.Format(CultureInfo.CurrentCulture, "{0}", arg);

            switch (arg)
            {
                case int i:
                    return (i * 2).ToString();
                case DateTime dt:
                    return dt.ToString("yyyy-MM-dd");
                default:
                    return arg.ToString();
            }
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
    }
}
