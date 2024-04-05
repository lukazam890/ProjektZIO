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
        private static readonly HttpClient httpRequest = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Question q = httpRequest.GetById(2);
            textBox1.Text = q.questionContent;
            q.answer1 = "alaa";
            httpRequest.AddQuestion(q);


            Test t = new Test();
            t.date = DateTime.Now;
            t.nick = "lolek";
            t.result = 0;
            httpRequest.AddTest(t);
        }
    }
}
