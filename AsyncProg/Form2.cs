using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncProg
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //async method can have multiple await
        private async void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("THREAD: " + Thread.CurrentThread.ManagedThreadId);
            listBox1.Items.Add("Item1");
            //await CallProcessing(); // CANNOT AWAIT VOID
            // SO THE METHOD ON WHICH AWAITED ON SHOULD RETURN TASK

            //CallProcessing();

            await CallProcessing();

            await Task.Run(() =>
            {
                Thread.Sleep(2000);
            });

            listBox1.Items.Add("Item3");
        }

        //public async void CallProcessing()
        public async Task CallProcessing()
        {
            Console.WriteLine("THREAD: " + Thread.CurrentThread.ManagedThreadId);
            string item = await Processing();
            listBox1.Items.Add($"{item}");
            Console.WriteLine("THREAD: " + Thread.CurrentThread.ManagedThreadId);
            listBox1.Items.Add("Item2");

        }

        public Task<string> Processing()
        {
            Console.WriteLine("THREAD: " + Thread.CurrentThread.ManagedThreadId);
            return Task.Run(() =>
            {
                string itemToreturn = "";
                try
                {
                    Console.WriteLine("THREAD: " + Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine("executing something...");
                    //listBox1.Items.Add("Item4"); // THIS WILL THROW CROSS THREAD OPERATION ERROR...
                    Thread.Sleep(5000);
                    itemToreturn = "Item *";
                    //throw new Exception("SystemException");

                }
                catch (Exception ex)
                {

                    listBox1.Invoke(new MethodInvoker(delegate ()
                    {
                        listBox1.Items.Add(ex.Message);
                    }));
                }
                return itemToreturn;
            });
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await RunDownloadAsync();
            //await DoSomething();
            //Thread.Sleep(3000);
            //button2.BackColor = Color.Green;
        }

        private async Task DoSomething()
        {

            await Task.Delay(5000);

            Thread.Sleep(2000);
            button2.BackColor = Color.Gray;
        }

        private List<string> PrepData()
        {
            List<string> output = new List<string>();
            //listBox1.Text = "";

            output.Add("https://www.google.com");
            output.Add("https://www.yahoo.com");
            output.Add("https://www.microsoft.com");
            output.Add("https://www.gmail.com");

            return output;
        }

        private async Task RunDownloadAsync()
        {
            List<string> websites = PrepData();

            foreach (var website in websites)
            {
                var result = await Task.Run(() => DownloadWebsite(website));

                ReportWSInfo(website, result);
            }
        }

        private string DownloadWebsite(string url)
        {
            WebClient client = new WebClient();

            return client.DownloadString(url);
        }

        private void ReportWSInfo(string url, string data)
        {
            listBox1.Items.Add( url + " : " + data.Length + Environment.NewLine);   
        }
    }
}
