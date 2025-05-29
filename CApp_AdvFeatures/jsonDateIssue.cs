using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CApp_AdvFeatures
{
    internal class jsonDateIssue
    {
        public static void Main1(string[] args)
        {
            Customer c = ReadJSON();

            string s = WriteJSON(c);

            Console.WriteLine(s);
            
            Console.ReadLine();
        }
        private static Customer ReadJSON()
        {
            string filePath = @"C:\Users\tukar\source\repos\NET_PREP\CApp\CApp_AdvFeatures\data.json";

            if (File.Exists(filePath))
            {
                //JsonSerializerSettings setting = new JsonSerializerSettings();
                //setting.DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm";
                //var customers = JsonConvert.DeserializeObject<Customer>(File.ReadAllText(filePath),
                //new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });

                var customers = JsonConvert.DeserializeObject<Customer>(File.ReadAllText(filePath));

                return customers;

            }
            return null;
        }

        private static string WriteJSON(Customer _customers)
        {
            return JsonConvert.SerializeObject(_customers, 
                new JsonSerializerSettings { DateFormatString= "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffK" });
        }
    }


}
