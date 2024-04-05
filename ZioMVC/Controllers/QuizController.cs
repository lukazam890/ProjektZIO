using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZioMVC.Models;

namespace ZioMVC.Controllers
{
    public class QuizController : Controller
    {
        private readonly QuizDB _context;

        public QuizController(QuizDB context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StartTest(string nick)
        {
            if (string.IsNullOrEmpty(nick))
            {
                ModelState.AddModelError("Nick", "Proszę podać nick.");
                return View("Index");
            }

            var questions = _context.Questions.Take(5).ToList();

            var test = new Test
            {
                Nick = nick,
                Date = DateTime.Now,
                Questions = questions
            };

            _context.Tests.Add(test);
            _context.SaveChanges();

            // Przekaż pierwsze pytanie do widoku
            var firstQuestion = test.Questions.FirstOrDefault();
            return View("Question", firstQuestion);
        }
        [HttpPost]
        public IActionResult AnswerQuestion(int questionId, int selectedAnswer)
        {
            var test = _context.Tests
                .Include(t => t.Questions)
                .OrderByDescending(t => t.Date)
                .FirstOrDefault();

            if (test == null)
            {
                // Obsługa braku testu
            }

            // Znajdź pytanie w teście
            var currentQuestion = test.Questions.FirstOrDefault(q => q.Id == questionId);

            if (currentQuestion == null)
            {
                // Obsługa braku pytania
            }

            // Dodaj wybraną odpowiedź do listy wybranych odpowiedzi w teście
            if (test.SelectedAnswers == null)
            {
                test.SelectedAnswers = new List<int>(); // Inicjalizacja listy wybranych odpowiedzi
            }
            test.SelectedAnswers.Add(selectedAnswer);



            // Zwiększ pole Result instancji test, jeśli odpowiedź jest poprawna
            if (currentQuestion.CorrectAnswer == selectedAnswer)
            {
                test.Result++;
            }

            // Zapisz zmiany w bazie danych
            _context.SaveChanges();

            // Znajdź indeks następnego pytania do wyświetlenia
            var nextQuestionIndex = test.Questions.FindIndex(q => q.Id == questionId) + 1;

            if (nextQuestionIndex < test.Questions.Count)
            {
                // Jeśli istnieje następne pytanie, przekieruj użytkownika do widoku następnego pytania
                var nextQuestion = test.Questions[nextQuestionIndex];
                return View("Question", nextQuestion);
            }
            else
            {
                // Jeśli nie ma więcej pytań, przekieruj użytkownika do widoku końca testu
                return View("EndTest", test);
            }
        }


        public IActionResult EndTest(Test test)
        {
            return View(test);
        }
    }
}
