using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncProg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            WebClient webClient = new WebClient();
            webClient.DownloadDataAsync(new Uri(""));
            //webClient.DownloadDataCompleted += 

            //Thread.Sleep(1000);
            label1.Text = "started exec!";

            //Task.Run(() =>
            //{

            //});

            Task tsk2 = Task.Run(() =>
            {
                //Console.WriteLine("started on another task");
                label1.Invoke(new MethodInvoker(delegate
                {
                    label1.Text = "started on another task";
                }));

                Thread.Sleep(5000);
            });

            //Task tsk1 = new Task(PerformHeavyWork);
            //tsk1.Start();

            //tsk1.Wait();
            //Thread T1 = new Thread(PerformHeavyWork);
            //T1.Start();

            //T1.Join();
            Thread.Sleep(2000);
            label1.Text = "finished!";
        }

        public int PerformHeavyWork()
        {
            
            int count = 0;
            int tid = Thread.CurrentThread.ManagedThreadId;

            using(StreamReader reader = new StreamReader(@"C:\\TM\\2024\\DEV Softs\\largeFile.txt"))
            {
                string fileContent = reader.ReadToEnd();
                count = fileContent.Length;

                
                Thread.Sleep(10000);
            }

            return count;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //Task t = new Task(()=> { PerformHeavyWork(); });

            Task<int> t = Task.Run<int>(PerformHeavyWork);
            //t.Start();

            await t;

            label1.Text = t.Result.ToString();

        }
    }
}
