using ZioClient.ModelData;
using Xunit;
using System;
using System.Collections.Generic;

namespace ClientTests
{
    public class ModelTests
    {
        [Fact]
        public void TestModelTest()
        {
            Test test = new Test
            {
                id = 1,
                nick = "TestUser",
                date = DateTime.Now,
                result = 80,
                testQuestions = new List<TestQuestion>()
            };

            
            Assert.Equal(1, test.id);
            Assert.Equal("TestUser", test.nick);
            Assert.Equal(DateTime.Now.Date, test.date.Date);
            Assert.Equal(80, test.result);
            Assert.NotNull(test.testQuestions);
            Assert.Empty(test.testQuestions);
            
        }

        [Fact]
        public void QuestionModelTest()
        {
            var question = new Question
            {
                id = 1,
                questionContent = "What is the capital of France?",
                correctAnswer = 1,
                answer1 = "Paris",
                answer2 = "London",
                answer3 = "Berlin",
                answer4 = "Madrid",
                reference = "https://en.wikipedia.org/wiki/Paris",
                testQuestions = new List<TestQuestion>()
            };

            Assert.Equal(1, question.id);
            Assert.Equal("What is the capital of France?", question.questionContent);
            Assert.Equal(1, question.correctAnswer);
            Assert.Equal("Paris", question.answer1);
            Assert.Equal("London", question.answer2);
            Assert.Equal("Berlin", question.answer3);
            Assert.Equal("Madrid", question.answer4);
            Assert.Equal("https://en.wikipedia.org/wiki/Paris", question.reference);
            Assert.NotNull(question.testQuestions);
            Assert.Empty(question.testQuestions);
        }

        [Fact]
        public void TestQuestionModelTest()
        {
            var testQuestion = new TestQuestion
            {
                testId = 1,
                test = new Test(),
                questionId = 1,
                question = new Question()
            };


            Assert.Equal(1, testQuestion.testId);
            Assert.NotNull(testQuestion.test);
            Assert.Equal(1, testQuestion.questionId);
            Assert.NotNull(testQuestion.question);
        }
    }
}