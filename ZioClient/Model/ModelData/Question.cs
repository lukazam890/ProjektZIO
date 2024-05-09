using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZioClient.ModelData
{
    public class Question
    {
        public int id { get; set; }
        public string questionContent { get; set; }
        public int correctAnswer { get; set; }
        public string answer1 { get; set; }
        public string answer2 { get; set; }
        public string answer3 { get; set; }
        public string answer4 { get; set; }
        public string reference { get; set; }
        public List<TestQuestion> testQuestions { get; set; } = new List<TestQuestion>();
    }
}

