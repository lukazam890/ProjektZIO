using Microsoft.EntityFrameworkCore;
using ProjectTests.ClassForTest;
using ProjektZiotest.BLL;
using ProjektZiotest.IService;
using ProjektZiotest.Models;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace ProjectTests
{
    [Binding]
    public class QuestionServiceAcceptanceTests
    {
        private IQuestionService _questionService;
        private Question _question;

        private DbContextOptions<QuizDBTest> CreateNewContextOptions()
        {
            var builder = new DbContextOptionsBuilder<QuizDBTest>();
            builder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
            return builder.Options;
        }

        [Given(@"I have a question service")]
        public void GivenIHaveAQuestionService()
        {
            var context = new QuizDBTest(CreateNewContextOptions());
            _questionService = new QuestionServiceTest(context);
        }

        [When(@"I add a new question")]
        public void WhenIAddANewQuestion()
        {
            _question = new Question
            {
                QuestionContent = "What is the capital of France?",
                CorrectAnswer = 1,
                Answer1 = "Paris",
                Answer2 = "London",
                Answer3 = "Berlin",
                Answer4 = "Madrid",
                Reference = "https://en.wikipedia.org/wiki/Paris"
            };
            _questionService.AddQuestion(_question);
        }

        [Then(@"The question should be added to the database")]
        public void ThenTheQuestionShouldBeAddedToTheDatabase()
        {
            var question = _questionService.GetQuestionById(_question.Id);
            Assert.NotNull(question);
            Assert.Equal("What is the capital of France?", question.QuestionContent);
        }
    }
}
