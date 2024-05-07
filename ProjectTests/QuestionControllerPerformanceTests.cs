using Moq;
using ProjektZiotest.Controllers;
using ProjektZiotest.IService;
using ProjektZiotest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using ProjektZiotest.Controllers;
using ProjektZiotest.IService;
using ProjektZiotest.Models;
using Moq;

namespace ProjectTests
{
    public class QuestionControllerPerformanceTests
    {
        private readonly QuestionController _controller;
        private readonly Mock<IQuestionService> _mockService;

        public QuestionControllerPerformanceTests()
        {
            _mockService = new Mock<IQuestionService>();
            _controller = new QuestionController(_mockService.Object);
        }

        [Benchmark]
        public void GetQuestionByIdTest()
        {
            _mockService.Setup(service => service.GetQuestionById(It.IsAny<int>())).Returns(new Question { Id = 1 });

            for (int i = 0; i < 1000; i++)
            {
                _controller.GetQuestionById(i);
            }
        }
        [Benchmark]
        public void AddQuestionTest()
        {
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

            for (int i = 0; i < 1000; i++)
            {
                _controller.AddQuestion(question);
            }
        }

        [Benchmark]
        public void UpdateQuestionTest()
        {
            var question = new Question
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

            for (int i = 0; i < 1000; i++)
            {
                _controller.UpdateQuestion(1, question);
            }
        }

        [Benchmark]
        public void DeleteQuestionTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                _controller.DeleteQuestion(i);
            }
        }
    }
}