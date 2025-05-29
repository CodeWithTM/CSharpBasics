using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Enumerables
{
    internal class CSVParser
    {
        public void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader(@"C:\\Users\\tukar\\source\\repos\\NET_PREP\\CApp\\CApp_Enumerables\\data.csv"))
            {
                using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    var data = csv.GetRecords<Product>();

                    foreach (var row in data)
                    {
                        Console.WriteLine(row);
                    }
                }
            }
        }
    }

    internal class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{this.Id} {this.Name} {this.Description}";
        }
    }
}
