using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZioClient.Model.ModelData;
using ZioClient.ModelData;
using ZioClient.WindowManagment.Interfaces;

namespace ZioClient.WindowManagment
{
    public class MainWindowManager: IMainWindowManager
    {
        private HttpClientQuestion HttpClientQuestion = new HttpClientQuestion(new System.Net.Http.HttpClient());
        private HttpClientTest HttpClientTest = new HttpClientTest(new System.Net.Http.HttpClient());
        List<QuestionProcess> Questions;
        public List<QuestionProcess> getQuestions(int numberOfQuestions)
        {
            Random random = new Random();
            List<Question> allQuestions = HttpClientQuestion.GetAll();
            int min = allQuestions.Min(x => x.id);
            int max = allQuestions.Max(x => x.id);
            List<int> randomNumbers = new List<int>();
            for(int i=0; i< numberOfQuestions; i++)
            {
                int number;
                bool isNotGoodNumber = true;
                do
                {
                    number = random.Next(min, max);
                    if (allQuestions.Find(x => x.id == number) != null && randomNumbers.Find(x=>x == number) == 0)
                        isNotGoodNumber = false;
                } while (isNotGoodNumber);
                randomNumbers.Add(number);
            }
            Questions = new List<QuestionProcess>();
            foreach (int number in randomNumbers) 
            {
                QuestionProcess questionProcess = new QuestionProcess();
                questionProcess.Question = allQuestions.First(x => x.id == number);
                questionProcess.AnswerNumber = 0;
                Questions.Add(questionProcess);
            }
            return Questions;
        }
        public string testResult(List<QuestionProcess> questionProcesses)
        {
            int score = 0;
            foreach (QuestionProcess questionProcess in questionProcesses)
                if (questionProcess.AnswerNumber == questionProcess.Question.correctAnswer)
                    score++;
            Test test = new Test { nick="Test", date=DateTime.Now };
            HttpClientTest.AddTest(test);
            int idTest = HttpClientTest.GetAll().Max(x => x.id);
            List<int> QuestionsId = new List<int>();
            Questions.ForEach( q => QuestionsId.Add(q.Question.id));
            HttpClientTest.PutQuestion(idTest, QuestionsId);
            double scorePercent = ((double)((double)score / (double)questionProcesses.Count)) * 100;
            string result = $"Wynik: {score}/{questionProcesses.Count}, co stanowi: {scorePercent}%";
            return result ;
        }
    }
}
