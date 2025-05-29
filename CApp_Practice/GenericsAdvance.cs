using System.Collections.Generic;
using System.Linq;

namespace CApp_Practice
{
    public class GenericsAdvance
    {
        public void Main()
        {
            //Generic methods type can be inferred from its parameters

            //Generic class type should be specified

            //Example of generic interfaces

            List<ICoordinates<double>> coordinates = new List<ICoordinates<double>>();

            coordinates.Add(new PrecisePoints<double>(1, 1));

            coordinates.Add(new PrecisePoints<double>(1, 2));

            //coordinates.Add(new SimplePoints(1,1));

            //Find method takes Predicate delegate
            //we are using anonymous methos with delegate keyward
            var result = coordinates.Find(
                delegate (ICoordinates<double> a)
                {
                    return a.X == 1 && a.Y == 2;
                });

            //Where method also takes Predicate delegate
            //we are using lambda expression
            var filetered = coordinates.Where((d) => d.X == 1);

            //If we dont use .ToList() at the end, it will return IEnumerable collection
            //which will be evaluated only when we iterate over the enumList
            IEnumerable<ICoordinates<double>> enumList = coordinates.Where((d) => d.X == 1);

            //If we use .ToList() at the end, then instead of IEnumerable collection
            //it will evaluate complete List and assign it to list varibale here itself
            IEnumerable<ICoordinates<double>> list = coordinates.Where((d) => d.X == 1).ToList();

            foreach (var a in enumList)
            {
            }
            foreach (var item in list)
            {
            }

            foreach (ICoordinates<double> point in coordinates)
            {
            }

            IEnumerable<ICoordinates<double>> enumerablecoordinates = new List<ICoordinates<double>>
            {
                new PrecisePoints<double>(2, 2),
                new PrecisePoints<double>(3,3)
            };
        }
    }

    public interface ICoordinates<T> where T : struct // so T will be of value type and no reference type is allowed
    {
        T X { get; set; }
        T Y { get; set; }
    }

    public struct SimplePoints : ICoordinates<int>
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class GenericPoints<T> : ICoordinates<T> where T : struct
    {
        public T X { set; get; }
        public T Y { set; get; }
    }

    public class PrecisePoints<T> : ICoordinates<T> where T : struct
    {
        public T X { get; set; }
        public T Y { get; set; }

        public PrecisePoints(T x, T y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "(" + "X: " + X + ", Y:" + Y + ")";
        }
    }

    public class LabelledPoints<T> : PrecisePoints<T> where T : struct
    {
        public LabelledPoints(T x, T y) : base(x, y)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}