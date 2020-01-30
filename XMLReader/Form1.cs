using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\BNU\new2.xml";
            dataSet1.ReadXml(filePath);
            dataGridView1.DataSource = dataSet1;
            dataGridView1.DataMember = "LinearRing";
            // 
            string testing = dataGridView1.Rows[0].Cells[0].Value.ToString();
            string[] cord = testing.Split(' ');
            foreach (var word in cord)
            {
                richTextBox1.Text = word + "\n" + richTextBox1.Text;
            }
        }
    }
}
