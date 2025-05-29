using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_SOLID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(FileStream fs = File.OpenRead("C:\\DumpStack.log"))
            {
                byte[] data = new byte[fs.Length];
            }
        }
    }
}
