using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Generics
{
    internal class Generics_Basic
    {
        public void Main(string[] args)
        {
            MobileStore ms = new MobileStore();
            ms.AddMobile(new Mobile() { ID = 1001, Brand = "Apple" });

            ms.AddMobile(new Mobile() { ID = 1002, Brand = "One+" });

            ms.GetMobileById(1001);

            ms.GetMobiles();

            GenericStore<Mobile> genericStore = new GenericStore<Mobile>();
            genericStore.AddProduct(new Mobile() { ID = 1004, Brand = "Apple" });

            genericStore.GetProductById(1004);

            bool r1 = isEquals<int>(1, 1);
            bool r2 = isEquals<string>("1", "1");
        }

        public bool isEquals<T>(T num1, T num2)
        {
            EqualityComparer<T>.Default.Equals(num1, num2);
            return num1.Equals(num2);
        }
    }

    public abstract class Product
    {
        public int ID { get; set; }
    }

    public class Book : Product
    {
        public string AuthorName { get; set; }
    }

    public class Mobile : Product
    {
        public string Brand { get; set; }
    }

    public class BookStore
    {
        List<Book> books = new List<Book>();
        Dictionary<int, Book> dictBooks = new Dictionary<int, Book>();
        public BookStore() { }
        
        public void AddBook(Book book)
        {
            books.Add(book);
            dictBooks.Add(book.ID, book);
        }

        public Book GetBookById(int id)
        {
            return dictBooks[id];
        }

        public List<Book> GetBooks()
        {
            return books;
        }
    }

    public class MobileStore
    {
        List<Mobile> mobiles = new List<Mobile>();
        Dictionary<int, Mobile> dictMobiles = new Dictionary<int, Mobile>();
        public MobileStore() { }

        public void AddMobile(Mobile mob)
        {
            mobiles.Add(mob);
            dictMobiles.Add(mob.ID, mob);
        }

        public Mobile GetMobileById(int id)
        {
            return dictMobiles[id];
        }

        public List<Mobile> GetMobiles()
        {
            return mobiles;
        }
    }

    public interface IGenProducts<T>
    {
        void AddProduct(T prod);

        T GetProductById(int i);

        List<T> GetProducts();

        int CompareProducts(T prod1, T prod2);
    }

    public class GenericStore<T> : IGenProducts<T> where T : Product 
    {
        List<T> products = new List<T>();
        Dictionary<int, T> dictProducts = new Dictionary<int, T>();
        public GenericStore() { }

        public void AddProduct(T mob)
        {
            products.Add(mob);
            dictProducts.Add(mob.ID, mob);
        }

        public T GetProductById(int id)
        {
            return dictProducts[id];
        }

        public List<T> GetProducts()
        {
            return products;
        }

        public int CompareProducts(T prod1, T prod2)
        {
            return prod1.ID.CompareTo(prod2.ID);
        }
    }
}
