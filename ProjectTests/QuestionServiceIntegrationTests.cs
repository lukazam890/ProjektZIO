using Microsoft.EntityFrameworkCore;
using ProjectTests.ClassForTest;
using ProjektZiotest.BLL;
using ProjektZiotest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTests
{
    public class QuestionServiceIntegrationTests
    {
        private DbContextOptions<QuizDBTest> CreateNewContextOptions()
        {
            var builder = new DbContextOptionsBuilder<QuizDBTest>();

            builder.UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString());

            return builder.Options;
        }

        [Fact]
        public void AddQuestion_AddsQuestionToDatabase()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (var context = new QuizDBTest(options))
            {
                var questionService = new QuestionServiceTest(context);
                var question = new Question
                {
                    QuestionContent = "What is the capital of France?",
                    CorrectAnswer = 1,
                    Answer1 = "Paris",
                    Answer2 = "London",
                    Answer3 = "Berlin",
                    Answer4 = "Madrid",
                    Reference = "https://en.wikipedia.org/wiki/Paris"
                };

                // Act
                questionService.AddQuestion(question);
            }

            // Assert
            using (var context = new QuizDBTest(options))
            {
                Assert.Equal(1, context.Questions.Count());
                var question = context.Questions.Single();
                Assert.Equal("What is the capital of France?", question.QuestionContent);
            }
        }
        [Fact]
        public void UpdateQuestion_UpdatesQuestionInDatabase()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (var context = new QuizDBTest(options))
            {
                var questionService = new QuestionServiceTest(context);
                var question = new Question
                {
                    QuestionContent = "What is the capital of France?",
                    CorrectAnswer = 1,
                    Answer1 = "Paris",
                    Answer2 = "London",
                    Answer3 = "Berlin",
                    Answer4 = "Madrid",
                    Reference = "https://en.wikipedia.org/wiki/Paris"
                };
                questionService.AddQuestion(question);

                // Act
                var updatedQuestion = new Question
                {
                    QuestionContent = "What is the capital of Spain?",
                    CorrectAnswer = 1,
                    Answer1 = "Madrid",
                    Answer2 = "London",
                    Answer3 = "Berlin",
                    Answer4 = "Paris",
                    Reference = "https://en.wikipedia.org/wiki/Madrid"
                };
                questionService.UpdateQuestion(question.Id, updatedQuestion);
            }

            // Assert
            using (var context = new QuizDBTest(options))
            {
                Assert.Equal(1, context.Questions.Count());
                var question = context.Questions.Single();
                Assert.Equal("What is the capital of Spain?", question.QuestionContent);
            }
        }

        [Fact]
        public void DeleteQuestion_DeletesQuestionFromDatabase()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (var context = new QuizDBTest(options))
            {
                var questionService = new QuestionServiceTest(context);
                var question = new Question
                {
                    QuestionContent = "What is the capital of France?",
                    CorrectAnswer = 1,
                    Answer1 = "Paris",
                    Answer2 = "London",
                    Answer3 = "Berlin",
                    Answer4 = "Madrid",
                    Reference = "https://en.wikipedia.org/wiki/Paris"
                };
                questionService.AddQuestion(question);

                // Act
                questionService.DeleteQuestion(question.Id);
            }

            // Assert
            using (var context = new QuizDBTest(options))
            {
                Assert.Equal(0, context.Questions.Count());
            }
        }
    }
}
