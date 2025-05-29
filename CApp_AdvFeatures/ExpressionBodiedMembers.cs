using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CApp_AdvFeatures
{
    //Expression bodied member(EBD) introduced in C# 7.0
    internal class ExpressionBodiedMembers
    {
        public static void Main1(string[] args)
        {
            Location loc = new Location("Nagpur");

            loc.ShowOtherlocation();

            Console.WriteLine(loc[1]);

            Console.ReadLine();
        }
    }

    public class Location
    {
        private string[] locations = { "Mumbai", "Pune" };

        private string _OtherLocation;
        public Location(string loc) => _OtherLocation = loc; // constructor can also use EBD

        public string OtherLocation
        {
            get => _OtherLocation;
            set => _OtherLocation = value;
        }

        public string this[int index]   //indexer also support EBD
        {
            get => locations[index];
            set => locations[index] = value;
        }

        public void ShowOtherlocation() => Console.WriteLine($"Other Location: {OtherLocation}");        

        public void Showlocation(int idx) => Console.WriteLine($"Other Location: {this[idx]}");

    }
}
