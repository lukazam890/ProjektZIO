using Microsoft.EntityFrameworkCore;
using ProjectTests.ClassForTest;
using ProjektZiotest.BLL;
using ProjektZiotest.IService;
using ProjektZiotest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTests.ClassForTest;

namespace ProjectTests
{
    public class QuestionServiceTests
    {
        private DbContextOptions<QuizDBTest> CreateNewContextOptions()
        {
            var builder = new DbContextOptionsBuilder<QuizDBTest>();

            builder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());


            return builder.Options;
        }

        [Fact]
        public void Test_AddQuestion()
        {
            using (var context = new QuizDBTest(CreateNewContextOptions()))
            {
                IQuestionService questionService = new QuestionServiceTest(context);
                var question = new Question
                {
                    Id = 1,
                    QuestionContent = "What is the capital of France?",
                    CorrectAnswer = 1,
                    Answer1 = "Paris",
                    Answer2 = "London",
                    Answer3 = "Berlin",
                    Answer4 = "Madrid",
                    Reference = "https://en.wikipedia.org/wiki/Paris"
                };

                questionService.AddQuestion(question);

                var result = context.Questions.Find(1);
                Assert.NotNull(result);
                Assert.Equal("What is the capital of France?", result.QuestionContent);
            }
        }

        [Fact]
        public void Test_UpdateQuestion()
        {
            using (var context = new QuizDBTest(CreateNewContextOptions()))
            {
                var question = new Question
                {
                    Id = 1,
                    QuestionContent = "What is the capital of France?",
                    CorrectAnswer = 1,
                    Answer1 = "Paris",
                    Answer2 = "London",
                    Answer3 = "Berlin",
                    Answer4 = "Madrid",
                    Reference = "https://en.wikipedia.org/wiki/Paris"
                };
                context.Questions.Add(question);
                context.SaveChanges();

                IQuestionService questionService = new QuestionServiceTest(context);
                var updatedQuestion = new Question
                {
                    Id = 1,
                    QuestionContent = "What is the capital of Spain?",
                    CorrectAnswer = 4,
                    Answer1 = "Madrid",
                    Answer2 = "London",
                    Answer3 = "Berlin",
                    Answer4 = "Paris",
                    Reference = "https://en.wikipedia.org/wiki/Madrid"
                };

                questionService.UpdateQuestion(1, updatedQuestion);

                var result = context.Questions.Find(1);
                Assert.NotNull(result);
                Assert.Equal("What is the capital of Spain?", result.QuestionContent);
                Assert.Equal(4, result.CorrectAnswer);
            }
        }

        [Fact]
        public void Test_DeleteQuestion()
        {

            using (var context = new QuizDBTest(CreateNewContextOptions()))
            {

                var question = new Question
                {
                    Id = 1,
                    QuestionContent = "What is the capital of France?",
                    CorrectAnswer = 1,
                    Answer1 = "Paris",
                    Answer2 = "London",
                    Answer3 = "Berlin",
                    Answer4 = "Madrid",
                    Reference = "https://en.wikipedia.org/wiki/Paris"
                };
                context.Questions.Add(question);
                context.SaveChanges();


                IQuestionService questionService = new QuestionServiceTest(context);
                questionService.DeleteQuestion(1);

                var result = context.Questions.Find(1);
                Assert.Null(result);
            }
        }

        [Fact]
        public void Test_GetAllQuestions()
        {

            using (var context = new QuizDBTest(CreateNewContextOptions()))
            {

                context.Questions.Add(new Question
                {
                    Id = 1,
                    QuestionContent = "Question 1",
                    CorrectAnswer = 1,
                    Answer1 = "A1",
                    Answer2 = "A2",
                    Answer3 = "A3",
                    Answer4 = "A4",
                    Reference = "Ref1"
                });
                context.Questions.Add(new Question
                {
                    Id = 2,
                    QuestionContent = "Question 2",
                    CorrectAnswer = 2,
                    Answer1 = "B1",
                    Answer2 = "B2",
                    Answer3 = "B3",
                    Answer4 = "B4",
                    Reference = "Ref2"
                });
                context.SaveChanges();


                IQuestionService questionService = new QuestionServiceTest(context);
                var allQuestions = questionService.GetAllQuestions();

                Assert.Equal(2, allQuestions.Count);
                Assert.Contains(allQuestions, q => q.Id == 1);
                Assert.Contains(allQuestions, q => q.Id == 2);
            }
        }
    }
}
