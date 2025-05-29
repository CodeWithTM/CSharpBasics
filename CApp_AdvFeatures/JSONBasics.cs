using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CApp_AdvFeatures
{
    internal class JSONBasics
    {
        public static void Main1(string[] args)
        {

            JObjectManipulator jObjectManipulator = new JObjectManipulator();
            jObjectManipulator.GetObjectKeys();


            JToken jT = JToken.Parse(File.ReadAllText(@"C:\Users\tukar\source\repos\NET_PREP\CApp\CApp_AdvFeatures\customerData.json"));

            foreach (var t in jT)
            {
                Console.WriteLine(t.ToString());
            }

            var obj = BuildDynamicObj();

            int cnt = obj.Count;
            //int cnt = obj.Length;
            WriteDynamicToJSON(obj);


            var empJson = ReadNestedJSON();

            var cs = ReadJSON();

            foreach (Customer c in cs)
            {
                Console.WriteLine($"{c.Name} -- {c.DOB}" );

                System.Diagnostics.Debug.WriteLine(c.Name);
            }

            string json = WriteJSON(cs);

            //JObject jobj = JObject.Parse(json);
            JArray jArray = JArray.Parse(json);

            foreach (JToken jToken in jArray.AsJEnumerable())
            {
                System.Diagnostics.Debug.WriteLine(jToken["Name"]);
                
            }

            IEnumerable<JToken> ja = jArray.Where(c => c["Name"].ToString() == "TM");

            Customer c1 = new Customer() { ID = 1003, Name = "JG", DOB = DateTime.Now, IsActive = true, Address = "MR" };
            string json1 = WriteCustomerJSON(c1);

            JObject jobj1 = JObject.Parse(json1);

            Console.ReadLine();
        }

        private static dynamic BuildDynamicObj()
        {
            var dyobj = 1;
            dynamic j = "1";

            //dyobj = (int)j;

            j = dyobj;

            dynamic obj = new { id = 101, name = "abc", desc = "" };

            var lstDynamic = new List<dynamic>()
            {
                new { id=101, name="abc", isactive = true },
                new { id=102, name="abc" }
            };

            
            return lstDynamic;
        }

        private static List<Customer> ReadJSON()
        {
            string filePath = @"C:\Users\tukar\source\repos\NET_PREP\CApp\CApp_AdvFeatures\customerData.json";

            if (File.Exists(filePath))
            {
                JsonSerializerSettings setting = new JsonSerializerSettings();
                setting.DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm";
                var customers = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(filePath), new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });

                return customers;

            }
            return null;
        }

        private static Employee ReadNestedJSON()
        {
            string filePath = @"C:\Users\tukar\source\repos\NET_PREP\CApp\CApp_AdvFeatures\customerData.json";

            if (File.Exists(filePath))
            {
                JsonSerializerSettings setting = new JsonSerializerSettings();
                setting.DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm";
                var employee = JsonConvert.DeserializeObject<Employee>(File.ReadAllText(filePath), new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });

                return employee;

            }
            return null;
        }

        private static string WriteJSON(List<Customer> _customers)
        {
            return JsonConvert.SerializeObject(_customers, new JsonSerializerSettings {  NullValueHandling = NullValueHandling.Ignore });
        }

        private static string WriteCustomerJSON(Customer _customer)
        {
            return JsonConvert.SerializeObject(_customer, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        private static void WriteDynamicToJSON(dynamic obj)
        {
            //Serialize
            string s = JsonConvert.SerializeObject(obj);


            //De-serialize
            var d = JsonConvert.DeserializeObject<List<DynamicEmp>>(s, new ExpandoObjectConverter());

            foreach (DynamicEmp item in d)
            {
                
            }
        }
    }

    public class Employee
    {
        public string empId { get; set; }
        public string empName { get; set; }
        public List<Customer> customers { get; set; } 

        //public Customer[] customers { get; set; }     //ARRAY & LIST  DESERIALIZE TO THE SAME..
    }

    public class DynamicEmp
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool? isactive { get; set; }
    }

    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime? DOB { get; set; }
        public bool? IsActive { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

    }


    public class JObjectManipulator
    {

        private readonly JObject _jobject;
        
        public JObjectManipulator()
        {

            var jsonString = File.ReadAllText(@"C:\Users\tukar\source\repos\NET_PREP\CApp\CApp_AdvFeatures\customerData.json");

            _jobject = JObject.Parse(jsonString);

        }

        public void GetObjectKeys()
        {

            string empid = (string)_jobject["empId"];

            JArray customer = (JArray)_jobject["customers"];

            string id = (string)customer[0]["ID"];

            JObject cust1 = (JObject)customer[0];
            string id1 = (string)cust1["ID"];

            string eid = _jobject.Value<string>("empId");


            //JToken tt = new JObject();

            if (_jobject.TryGetValue("empId", out JToken tt)) { 
            
            }


            if(_jobject.TryGetValue("customers", out JToken t1) && t1 is JArray custArray)
            {
                if((((JObject)custArray[0]).TryGetValue("DOB", out JToken dob)) && dob is JValue jv){
                    Console.WriteLine(jv.Value);
                }
            }
            Console.WriteLine(tt);

        }
    }
}
