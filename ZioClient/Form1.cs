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

     
            List<int> lista = new List<int> { 2, 3 }; 
            httpRequestT.PutQuestion(2,lista);  //test dodania pytań
            Test t = httpRequestT.GetById(1);
            textBox1.Text = t.testQuestions.Count.ToString();  //test get by id
            Console.WriteLine(t.testQuestions.Count.ToString());

            List<Test> listb = httpRequestT.GetAll();
            Console.WriteLine(listb.Count.ToString());  //test get all
            httpRequestT.Delete(4);
             listb = httpRequestT.GetAll();
            Console.WriteLine("po usunieciu"+ listb.Count.ToString());  //test get all

            Test nowy = new Test();
            nowy.nick = "poprawny";
            httpRequestT.AddTest(nowy);
            listb = httpRequestT.GetAll();
            Console.WriteLine(listb.LastOrDefault().nick.ToString());


            Console.WriteLine("\nsprawdzenie Questions\n");

            Question question = new Question();
            question = httpRequestQ.GetById(1);
            Console.WriteLine(question.questionContent.ToString());
            Console.WriteLine(question.testQuestions.FirstOrDefault().testId);

            List<Question> list = httpRequestQ.GetAll();
            Console.WriteLine(list.Count.ToString());

        }
    }
}
