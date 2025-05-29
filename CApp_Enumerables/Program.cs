using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Enumerables
{
    internal class Program
    {
        static String location;
        static DateTime time;
        static void Main(string[] args)
        {



                Console.WriteLine(location == null ? "location is null" : location);
                Console.WriteLine(time == null ? "time is null" : time.ToString());
            

            //CSVParser cSVParser = new CSVParser();
            //cSVParser.Main(args);

            //EnumerableAdvance enumerableAdvance = new EnumerableAdvance();
            //enumerableAdvance.Main(args);

            EnumerableBasics enumerableBasics = new EnumerableBasics();
            enumerableBasics.Main(args);

        }


    }
}
