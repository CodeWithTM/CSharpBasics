using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CApp_AdvFeatures
{
    public class PatientDetails
    {
        public PatientDetails(int id) {
            Thread.Sleep(5000);
            Console.WriteLine("cntr called.. object created!");
            this.Id = id;
        }
        public int Id { get; set; }

        public void DispId()
        {
            Console.WriteLine("id accessed!");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            VolatileKeyword.Main1(args);


            //Lazy initialization of object
            //object creation is deferred, till the time any of object property/method is accessed
            //object created with lazy initilization are THREAD SAFE
            //PatientDetails pd = new PatientDetails(1001);
            Lazy<PatientDetails> lazyPD = new Lazy<PatientDetails> (() => new PatientDetails(1001),
                LazyThreadSafetyMode.ExecutionAndPublication);

            //pd.DispId();

            Console.WriteLine(lazyPD.IsValueCreated);
            lazyPD.Value.DispId();
            Console.WriteLine(lazyPD.IsValueCreated);

            jsonDateIssue.Main1(args);

            JSONBasics.Main1(args);

            ExpressionBodiedMembers.Main1(args);

            //nullable value type operator ?
            int? num1 = null;

            //Console.WriteLine(num1.Value);

            int num2 = num1.GetValueOrDefault();

            if (num1.HasValue)
            {
                Console.WriteLine(num1.Value);
            }

            //null-coalescing operator ??

            int? num3 = 5;
            //int? num3 = null;

            int? num4 = num3 ?? 0;
            int b = 10;

            //num4 ??= b;

            TypeCastingConversion typeCastingConversion = new TypeCastingConversion();
            typeCastingConversion.Main(args);

            //Is_vs_as is_Vs_As = new Is_vs_as();
            //is_Vs_As.Main(args);

        }
    }
}
