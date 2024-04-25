using System.ComponentModel.DataAnnotations;

namespace ProjektZiotest.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string QuestionContent { get; set; }

        private int _correctAnswer;
        public int CorrectAnswer
        {
            get { return _correctAnswer; }
            set
            {
                if (value < 1 || value > 4)
                {
                    throw new ArgumentOutOfRangeException(nameof(CorrectAnswer), "Correct answer must be between 1 and 4.");
                }
                _correctAnswer = value;
            }
        }

        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string Reference { get; set; }
        public List<TestQuestion>? TestQuestions { get; set; }

    }
}
