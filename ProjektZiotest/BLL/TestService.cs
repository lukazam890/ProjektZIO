using Microsoft.EntityFrameworkCore;
using ProjektZiotest.IService;
using ProjektZiotest.Models;

namespace ProjektZiotest.BLL
{
    public class TestService : ITestService
    {
        private readonly QuizDB _context;

        public TestService(QuizDB context)
        {
            _context = context;
        }

        public Test GetTestById(int id)
        {
            try
            {
                return _context.Tests
                    .Include(t => t.Questions)
                    .FirstOrDefault(t => t.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the test: " + ex.Message);
            }
        }
        public void AddTest(Test test)
        {
            try
            {
                _context.Tests.Add(test);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the test: " + ex.Message);
            }
        }

        public void UpdateTest(int id, Test updatedTest)
        {
            try
            {
                var test = _context.Tests.FirstOrDefault(t => t.Id == id);
                if (test == null)
                    throw new Exception("Test not found.");

                // Update test properties if needed
                test.Nick = updatedTest.Nick;
                test.Date = updatedTest.Date;
                test.Result = updatedTest.Result;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the test: " + ex.Message);
            }
        }

        public void DeleteTest(int id)
        {
            try
            {
                var test = _context.Tests.FirstOrDefault(t => t.Id == id);
                if (test == null)
                    throw new Exception("Test not found.");

                _context.Tests.Remove(test);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the test: " + ex.Message);
            }
        }

        public List<Test> GetAllTests()
        {
            try
            {
                return _context.Tests
                    .Include(t => t.Questions)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all tests: " + ex.Message);
            }
        }

        public Test GetTestByNickAndDate(string nick, DateTime date)
        {
            try
            {
                return _context.Tests
                    .Include(t => t.Questions) 
                    .FirstOrDefault(t => t.Nick == nick && t.Date == date);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the test: " + ex.Message);
            }
        }

        public List<Test> GetTestsByUser(string nick)
        {
            try
            {
                return _context.Tests
                    .Include(t => t.Questions)
                    .Where(t => t.Nick == nick)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving tests: " + ex.Message);
            }
        }
        public void AddQuestionsToList(int testId, List<int> questionIds)
        {
            try
            {
                var test = _context.Tests.FirstOrDefault(t => t.Id == testId);
                if (test == null)
                    throw new Exception("Test not found.");

                test.Questions = new List<Question>();

                foreach (var questionId in questionIds)
                {
                    var question = _context.Questions.FirstOrDefault(q => q.Id == questionId);
                    if (question != null)
                    {
                        test.Questions.Add(question);
                    }
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding questions to the test: " + ex.Message);
            }
        }
    }
}
