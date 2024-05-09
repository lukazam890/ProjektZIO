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
        private HttpClientQuestion HttpClientQuestion = new HttpClientQuestion();
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
                    if (allQuestions.Find(x => x.id == number) != null)
                        isNotGoodNumber = false;
                } while (isNotGoodNumber);
                randomNumbers.Add(number);
            }
            List<QuestionProcess> result = new List<QuestionProcess>();
            foreach (int number in randomNumbers) 
            {
                QuestionProcess questionProcess = new QuestionProcess();
                questionProcess.Question = allQuestions.First(x => x.id == number);
                questionProcess.AnswerNumber = 0;
                result.Add(questionProcess);
            }
            return result;
        }
        public string testResult(List<QuestionProcess> questionProcesses)
        {
            int score = 0;
            foreach (QuestionProcess questionProcess in questionProcesses)
                if (questionProcess.AnswerNumber == questionProcess.Question.correctAnswer)
                    score++;
            double scorePercent = ((double)((double)score / (double)questionProcesses.Count)) * 100;
            string result = $"Wynik: {score}/{questionProcesses.Count}, co stanowi: {scorePercent}%";
            return result ;
        }
    }
}
