using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CApp_AsyncWinApp
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            resultWindow.Text = string.Empty;
            resultWindow.Text += "Started.." + Environment.NewLine;

            var watch = Stopwatch.StartNew();

            RunDownloadSync();

            watch.Stop();
            var ellapsed = watch.ElapsedMilliseconds;

            resultWindow.Text += $"Completed in {ellapsed} ms" + Environment.NewLine;
        }

        private async void btnAsync_Click(object sender, EventArgs e)
        {
            resultWindow.Text = string.Empty;
            resultWindow.Text += "Started.." + Environment.NewLine;

            var watch = Stopwatch.StartNew();

            Progress<ProgressModel> p = new Progress<ProgressModel>();
            //p.ProgressChanged += onprogressChange;
            p.ProgressChanged += onProgressChange;

            try
            {
                await RunDownloadAsync(p, cts.Token);
            }
            catch (OperationCanceledException)
            {
                resultWindow.Text += $"Cancelled! {Environment.NewLine}";
            }


            //await RunDownload();

            watch.Stop();
            var ellapsed = watch.ElapsedMilliseconds;

            resultWindow.Text += $"Completed in {ellapsed} ms" + Environment.NewLine;
        }

        private void onProgressChange(object sender, ProgressModel e)
        {            
            downloadProgress.Value = e.Progress;
        }

        private void onprogressChange(object sender, string e)
        {
            downloadProgress.Value = int.Parse(e);
        }

        private async Task RunDownloadAsync(IProgress<ProgressModel> progress, CancellationToken cancellationToken)
        {
            List<string> websites = prepData();

            List<Task<WebsiteDataModel>> lstTasks = new List<Task<WebsiteDataModel>>();

            ProgressModel progressModel = new ProgressModel();

            foreach (var site in websites)
            {


                Task<WebsiteDataModel> t1 = Task.Run(() => DownloadWebsiteContent(site));

                //lstTasks.Add(t1);

                WebsiteDataModel dt = await t1;
                ReportWebInfo(dt);

                //cancellationToken.ThrowIfCancellationRequested();
                progressModel.Progress = 100;

                progress.Report(progressModel);

                //await Task.Run(() =>
                //{
                //    WebsiteDataModel d = DownloadWebsiteContent(site);

                //    ReportWebInfo(d);
                //});

                //WebsiteDataModel d = await DownloadWebsiteContentAsync(site);
                //ReportWebInfo(d);
            }
            //lstTasks[0].Wait();
            //WebsiteDataModel[] results = await Task.WhenAll(lstTasks);

            //foreach (WebsiteDataModel result in results)
            //{
            //    ReportWebInfo(result);
            //}
        }

        private async Task RunDownload()
        {
            List<string> websites = prepData();
            List<Task<WebsiteDataModel>> lstTasks = new List<Task<WebsiteDataModel>>();
            foreach (var website in websites)
            {
                lstTasks.Add(DownloadWebsiteContentAsync(website));
            }

            WebsiteDataModel[] results = await Task.WhenAll(lstTasks);

            foreach (WebsiteDataModel result in results)
            {
                ReportWebInfo(result);
            }
        }

        private async Task<WebsiteDataModel> DownloadWebsiteContentAsync(string websiteurl)
        {
            WebsiteDataModel websiteDataModel = new WebsiteDataModel();

            WebClient webClient = new WebClient();
            websiteDataModel.Url = websiteurl;

            websiteDataModel.Data = await webClient.DownloadDataTaskAsync(websiteurl);

            return websiteDataModel;
        }

        private void RunDownloadSync()
        {
            List<string> websites = prepData();

            foreach (string site in websites)
            {
                WebsiteDataModel dt = DownloadWebsiteContent(site);
                ReportWebInfo(dt);
            }
        }

        private List<string> prepData()
        {
            List<string> data = new List<string>();

            data.Add("https://www.google.com");
            data.Add("https://www.microsoft.com");
            data.Add("https://www.cnn.com");
            //data.Add("https://www.outlook.com");
            data.Add("https://www.netflix.com");
            data.Add("https://www.codeproject.com");

            return data;
        }

        private WebsiteDataModel DownloadWebsiteContent(string websiteurl)
        {
            WebsiteDataModel websiteDataModel = new WebsiteDataModel();

            WebClient webClient = new WebClient();
            websiteDataModel.Url = websiteurl;

            websiteDataModel.Data = webClient.DownloadData(websiteurl);

            return websiteDataModel;
        }

        private void ReportWebInfo(WebsiteDataModel data)
        {
            resultWindow.Text += $"Downloaded from:  {data.Url} Size: {data.Data.Length}" + Environment.NewLine;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }

        private async void btnAwait_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            
            await OperationAsync().ConfigureAwait(false);

            System.Diagnostics.Debug.Print($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            //resultWindow.Text = "WILL CAUSE EXCEPTION, AND DIFFERENT THREAD THAN MAIN THREAD IS TRYING TO UPDATE UI..";

            await OperationAsync().ConfigureAwait(true); // By default its true if configureAwait is not used..

            //While developing library code we can use ConfigureAwait(true)
            //as continution code will run on : UI thread 
        }

        private async Task OperationAsync()
        {
            System.Diagnostics.Debug.Print($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(1000);

            System.Diagnostics.Debug.Print($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        }
    }

    public class WebsiteDataModel
    {
        public byte[] Data { get; set; }
        public string Url { get; set; }
    }

    public class ProgressModel
    {
        public int Progress { get; set; } = 0;
        public List<WebsiteDataModel> sitesDownloaded { get; set; } = new List<WebsiteDataModel>();
    }
}
