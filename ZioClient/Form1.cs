using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZioClient.ModelData;

namespace ZioClient
{
    public partial class Form1 : Form
    {
        private static readonly HttpClientQuestion httpRequestQ = new HttpClientQuestion();
        private static readonly HttpClientTest httpRequestT = new HttpClientTest();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test t = httpRequestT.GetById(1);
            t.nick = "testowy";
            httpRequestT.Put(1, t);
            textBox1.Text = t.nick.ToString();




        }
    }
}
