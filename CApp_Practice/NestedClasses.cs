using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{

    // Nested classes-
    // we have main / outer blueprint and inside that there is inner blueprint

    // Building a House
    // House will contain Door, Door cannot exist separatly

    public class House
    {
        public int carpetArea;

        public House()
        {

        }

        public class Door
        {
            public string material;
            public string color;

            public Door()
            {
                
            }
        }
    }

    internal class NestedClasses
    {
        public static void MainNC()
        {
            House h1 = new House();

            House.Door d1 = new House.Door();


            MyArrayList ints = new MyArrayList(10);

            ints.Add(1);
            ints.Add(2);
            ints.Add(3);
            ints.Add(4);
            ints.Add(5);


            //ArrayList class makes use of Nested classes, we can build our own similar class ->
            MyArrayList.Enumerator enumerator = ints.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            
        }
    }


    class Order
    {
        public int OrderId { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order(int orderId)
        {
            OrderId = orderId;
        }

        public void AddItem(string name, int quantity)
        {
            Items.Add(new OrderItem(name, quantity));
        }

        // 🔥 Nested class
        public class OrderItem
        {
            public string Name { get; set; }
            public int Quantity { get; set; }

            public OrderItem(string name, int quantity)
            {
                Name = name;
                Quantity = quantity;
            }
        }
    }

    class MyArrayList
    {
        private int[] _items;
        private int _count;

        public MyArrayList(int size)
        {
            _items = new int[size];
            _count = 0;
        }

        public void Add(int value)
        {
            _items[_count++] = value;
        }

        // 🔥 Nested class (Enumerator)
        public class Enumerator
        {
            private MyArrayList _list;
            private int _index = -1;

            public Enumerator(MyArrayList list)
            {
                _list = list;
            }

            public bool MoveNext()
            {
                _index++;
                return _index < _list._count;
            }

            public int Current => _list._items[_index];
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }
    }

}
