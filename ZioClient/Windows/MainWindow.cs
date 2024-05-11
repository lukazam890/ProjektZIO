using Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZioClient.Model;
using ZioClient.Model.ModelData;
using ZioClient.ModelData;
using ZioClient.WindowManagment;
using ZioClient.WindowManagment.Interfaces;

namespace ZioClient
{
    public partial class MainWindow : Form
    {
        private static readonly HttpClientQuestion httpRequestQ = new HttpClientQuestion(new System.Net.Http.HttpClient());
        private static readonly HttpClientTest httpRequestT = new HttpClientTest(new System.Net.Http.HttpClient());
        private static readonly IMainWindowManager mainWindowManager = new MainWindowManager();
        private static int questionIndex;
        private static int numberOfQuestions;
        public MainWindow()
        {
            InitializeComponent();
            initialize();
        }
        private void initialize()
        {
            switchControls();
        }

        /*private void button1_Click(object sender, EventArgs e)
        {

     
            List<int> lista = new List<int> { 2, 3 }; 
            httpRequestT.PutQuestion(2,lista);  //test dodania pytań
            Test t = httpRequestT.GetById(1);
            textbox_nick.Text = t.testQuestions.Count.ToString();  //test get by id
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

        }*/

        private void bnt_gettingQuestions_Click(object sender, EventArgs e)
        {
            questionIndex = 0;
            numberOfQuestions = Convert.ToInt32(numericUpDown_numberOfQuestions.Value);
            Settings.QuestionsProcess = mainWindowManager.getQuestions(numberOfQuestions);
            Settings.AreQuestionsReady = true;
            setQuestion(0);
            switchControls();
        }
        private void setQuestion(int index)
        {
            QuestionProcess questionProcess = Settings.QuestionsProcess[index];
            Question question = questionProcess.Question;
            radioButton_answer1.Text = question.answer1;
            radioButton_answer2.Text = question.answer2;
            radioButton_answer3.Text = question.answer3;
            radioButton_answer4.Text = question.answer4;
            label_questionContent.Text = question.questionContent;

            switch(questionProcess.AnswerNumber)
            {
                case 0:
                default:
                    radioButton_answer1.Checked = false;
                    radioButton_answer2.Checked = false;
                    radioButton_answer3.Checked = false;
                    radioButton_answer4.Checked = false;
                    break;
                case 1:
                    radioButton_answer1.Checked = true;
                    break;
                case 2:
                    radioButton_answer2.Checked = true;
                    break;
                case 3: 
                    radioButton_answer3.Checked = true;
                    break;
                case 4: 
                    radioButton_answer4.Checked = true; 
                    break;
            }
            
            var imageSVG = SvgDocument.Open("../../Graphics/" + question.reference);
            SvgDocument svgDocument = SvgDocument.Open("../../Graphics/" + question.reference);
            svgDocument.Height = pictureBox_pictureOfQuestion.Height;
            Bitmap bitmap = svgDocument.Draw();
            pictureBox_pictureOfQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            pictureBox_pictureOfQuestion.Image = bitmap;
            displayQuestionNumber();
        }

        private void bnt_nextQuestion_Click(object sender, EventArgs e)
        {
            if (radioButton_answer1.Checked == true)
                Settings.QuestionsProcess[questionIndex].AnswerNumber = 1;
            else if (radioButton_answer2.Checked == true)
                Settings.QuestionsProcess[questionIndex].AnswerNumber = 2;
            else if (radioButton_answer3.Checked == true)
                Settings.QuestionsProcess[questionIndex].AnswerNumber = 3;
            else if (radioButton_answer4.Checked == true)
                Settings.QuestionsProcess[questionIndex].AnswerNumber = 4;
            else
                Settings.QuestionsProcess[questionIndex].AnswerNumber = 0;
            if (questionIndex < numberOfQuestions-1)
            {
                questionIndex++;
                setQuestion(questionIndex);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Czy jesteś pewny, że chcesz zakończyć test?", "Zakończenie testu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show(mainWindowManager.testResult(Settings.QuestionsProcess), "Wynik");
                }

                reset();
            }
        }

        private void bnt_previousQuestion_Click(object sender, EventArgs e)
        {
            if (radioButton_answer1.Checked == true)
                Settings.QuestionsProcess[questionIndex].AnswerNumber = 1;
            else if (radioButton_answer2.Checked == true)
                Settings.QuestionsProcess[questionIndex].AnswerNumber = 2;
            else if (radioButton_answer3.Checked == true)
                Settings.QuestionsProcess[questionIndex].AnswerNumber = 3;
            else if (radioButton_answer4.Checked == true)
                Settings.QuestionsProcess[questionIndex].AnswerNumber = 4;
            else
                Settings.QuestionsProcess[questionIndex].AnswerNumber = 0;
            if(questionIndex>0)
            {
                questionIndex--;
                setQuestion(questionIndex);
            }
        }
        private void displayQuestionNumber()
        {
            label_questionNumber.Text = (questionIndex+1) + "/" + numberOfQuestions;
        }
        private void reset()
        {
            Settings.QuestionsProcess = null;
            Settings.AreQuestionsReady = false;
            radioButton_answer1.Text = "";
            radioButton_answer2.Text = "";
            radioButton_answer3.Text = "";
            radioButton_answer4.Text = "";
            label_questionContent.Text = "";
            pictureBox_pictureOfQuestion.Image = null;
            switchControls();
        }

        private void switchControls()
        {
            radioButton_answer1.Checked = false;
            radioButton_answer2.Checked = false;
            radioButton_answer3.Checked = false;
            radioButton_answer4.Checked = false;
            if (radioButton_answer1.Enabled == false)
            {
                radioButton_answer1.Enabled = true;
                radioButton_answer2.Enabled = true;
                radioButton_answer3.Enabled = true;
                radioButton_answer4.Enabled = true;
                bnt_previousQuestion.Enabled = true;
                bnt_nextQuestion.Enabled = true;
                button_reset.Enabled = true;
                bnt_gettingQuestions.Enabled = false;
                numericUpDown_numberOfQuestions.Enabled = false;
            }
            else
            {
                radioButton_answer1.Enabled = false;
                radioButton_answer2.Enabled = false;
                radioButton_answer3.Enabled = false;
                radioButton_answer4.Enabled = false;
                bnt_previousQuestion.Enabled = false;
                bnt_nextQuestion.Enabled = false;
                button_reset.Enabled = false;
                bnt_gettingQuestions.Enabled = true;
                numericUpDown_numberOfQuestions.Enabled = true;
            }
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy napewno chcesz zresetować test?", "Zakończenie testu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                reset();
            }
        }
    }
}
