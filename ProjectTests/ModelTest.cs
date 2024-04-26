﻿using ProjektZiotest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTests
{
    public class ModelTest
    {
        [Fact]
        public void Test_Create_Test_Model()
        {

            var test = new Test
            {
                Id = 1,
                Nick = "TestUser",
                Date = DateTime.Now,
                Result = 80,
                TestQuestions = new List<TestQuestion>()
            };


            Assert.Equal(1, test.Id);
            Assert.Equal("TestUser", test.Nick);
            Assert.Equal(DateTime.Now.Date, test.Date.Date);
            Assert.Equal(80, test.Result);
            Assert.NotNull(test.TestQuestions);
            Assert.Empty(test.TestQuestions); 
        }

        [Fact]
        public void Test_Create_Question_Model()
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
                Reference = "https://en.wikipedia.org/wiki/Paris",
                TestQuestions = new List<TestQuestion>()
            };

            Assert.Equal(1, question.Id);
            Assert.Equal("What is the capital of France?", question.QuestionContent);
            Assert.Equal(1, question.CorrectAnswer);
            Assert.Equal("Paris", question.Answer1);
            Assert.Equal("London", question.Answer2);
            Assert.Equal("Berlin", question.Answer3);
            Assert.Equal("Madrid", question.Answer4);
            Assert.Equal("https://en.wikipedia.org/wiki/Paris", question.Reference);
            Assert.NotNull(question.TestQuestions);
            Assert.Empty(question.TestQuestions); 

            var exception = Record.Exception(() =>
            {
                var question = new Question
                {
                    Id = 1,
                    QuestionContent = "What is the capital of France?",
                    CorrectAnswer = 5, 
                    Answer1 = "Paris",
                    Answer2 = "London",
                    Answer3 = "Berlin",
                    Answer4 = "Madrid",
                    Reference = "https://en.wikipedia.org/wiki/Paris",
                    TestQuestions = new List<TestQuestion>()
                };
            });

            Assert.NotNull(exception);
            Assert.IsType<ArgumentOutOfRangeException>(exception);
            Assert.NotNull(exception);
            Assert.IsType<ArgumentOutOfRangeException>(exception);

        }

        [Fact]
        public void Test_Create_TestQuestion_Model()
        {

            var testQuestion = new TestQuestion
            {
                TestId = 1,
                Test = new Test(),
                QuestionId = 1,
                Question = new Question()
            };


            Assert.Equal(1, testQuestion.TestId);
            Assert.NotNull(testQuestion.Test);
            Assert.Equal(1, testQuestion.QuestionId);
            Assert.NotNull(testQuestion.Question);
        }
    }
}
