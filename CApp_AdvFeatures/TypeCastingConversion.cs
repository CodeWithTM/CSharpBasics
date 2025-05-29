using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_AdvFeatures
{
    internal class TypeCastingConversion
    {
        public void Main(string[] args)
        {

            //Type conversion - its implicit and done by compiler
            int i = 100;

            double d = i;
            float f = 1;

            //int j = d;
            int k = (int)d;

            double d1 = 100.657;
            int k1 = (int)d1;

            int k2 = Convert.ToInt32(d1); // --> 101

            int k3 = Convert.ToInt32(4.5);
            int k4 = Convert.ToInt32(7.5);

            //Type Casting / Casting is explicit done by the programmer


            //Parsing
            int parsedInt1 = int.Parse("1");

            //int parsedInt2 = int.Parse("1a"); // invalid format exception
            
            bool isParsed = int.TryParse("1", out _); // _ is called as Discard operator - as we are not interested in out value we can use discard opearot

            int parssedInt3 = Convert.ToInt32("1");

            int parssedInt4 = Convert.ToInt32("1a");
        }
    }
}
