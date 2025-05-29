using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace AsyncProg
{

    public partial class XMLParser : Form
    {
        private string xmlFilePath = string.Empty;
        private List<CustomDataItem> flattenedData = new List<CustomDataItem>();

        public XMLParser()
        {
            InitializeComponent();
        }
        private void BindData() {
            //Parent table  
            DataTable dtstudent = new DataTable();
            // add column to datatable  
            dtstudent.Columns.Add("Student_ID", typeof(int));
            dtstudent.Columns.Add("Student_Name", typeof(string));
            dtstudent.Columns.Add("Student_RollNo", typeof(string));

            //Child table  
            DataTable dtstudentMarks = new DataTable();
            dtstudentMarks.Columns.Add("Student_ID", typeof(int));
            dtstudentMarks.Columns.Add("Subject_ID", typeof(int));
            dtstudentMarks.Columns.Add("Subject_Name", typeof(string));
            dtstudentMarks.Columns.Add("Marks", typeof(int));

            //Adding Rows  
            dtstudent.Rows.Add(111, "Devesh", "03021013014");
            dtstudent.Rows.Add(222, "ROLI", "0302101444");
            dtstudent.Rows.Add(333, "ROLI Ji", "030212222");
            dtstudent.Rows.Add(444, "NIKHIL", "KANPUR");

            // data for devesh ID=111  
            dtstudentMarks.Rows.Add(111, "01", "Physics", 99);
            dtstudentMarks.Rows.Add(111, "02", "Maths", 77);
            dtstudentMarks.Rows.Add(111, "03", "C#", 100);
            dtstudentMarks.Rows.Add(111, "01", "Physics", 99);


            //data for ROLI ID=222  
            dtstudentMarks.Rows.Add(222, "01", "Physics", 80);
            dtstudentMarks.Rows.Add(222, "02", "English", 95);
            dtstudentMarks.Rows.Add(222, "03", "Commerce", 95);
            dtstudentMarks.Rows.Add(222, "01", "BankPO", 99);

            DataSet dsDataset = new DataSet();
            //Add two DataTables in Dataset  
            dsDataset.Tables.Add(dtstudent);
            dsDataset.Tables.Add(dtstudentMarks);

            DataRelation Datatablerelation = new DataRelation("DetailsMarks", dsDataset.Tables[0].Columns[0], dsDataset.Tables[1].Columns[0], true);
            dsDataset.Relations.Add(Datatablerelation);
            dataGrid1.DataSource = dsDataset.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //BindData();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            Dictionary<string, List<string>> dictEnvs = new Dictionary<string, List<string>>();


            XmlNodeList parent = xmlDoc.SelectNodes("//appsettings/env");
            if (parent != null)
            {
                foreach (XmlNode child in parent)
                {
                    string key = child.Attributes["id"].Value;
                    List<string> lstParams = new List<string>();

                    foreach (XmlNode childNode in child.ChildNodes)
                    {
                        if (childNode.Attributes != null)
                            lstParams.Add(childNode?.Attributes?[0].Value);
                    }
                    dictEnvs.Add(key, lstParams);
                }
            }

            InitializeData(dictEnvs);

            InitializeDataGridView();
        }

        private void InitializeData(Dictionary<string, List<string>> dictEnvs)
        {
            foreach (var kvp in dictEnvs)
            {
                flattenedData.Add(new CustomDataItem(kvp.Key, kvp.Value));
            }
        }

        private void InitializeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = true;

            //List<CustomDataItem> flattenedData = data
            //                    .SelectMany(kv => kv.Value.Select(v => new CustomDataItem { Key = kv.Key, Value = v }))
            //                    .ToList();

            dataGridView1.DataSource = flattenedData; // data.Select(kv => new { Key = kv.Key, Values = string.Join(" | ", kv.Value), Dups = kv.Value.Count != kv.Value.Distinct().Count() }).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a File";
                openFileDialog.Filter = "All files (*.config)|*.config"; // You can customize the filter as needed

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    xmlFilePath = textBox1.Text = openFileDialog.FileName;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Assuming the expand/collapse button is in the first column
            //{
            //    flattenedData[e.RowIndex].IsExpanded = !flattenedData[e.RowIndex].IsExpanded;
            //    dataGridView1.InvalidateRow(e.RowIndex);
            //}
        }
    }

    public class CustomDataItem
    {
        public string Key { get; set; }
        public List<string> Values { get; }
        public bool IsExpanded { get; set; }

        public CustomDataItem(string key, List<string> values)
        {
            Key = key;
            Values = values;
            IsExpanded = false;
        }
    }
}
