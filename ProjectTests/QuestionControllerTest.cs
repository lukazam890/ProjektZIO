using Microsoft.AspNetCore.Mvc;
using ProjektZiotest.Controllers;
using ProjektZiotest.IService;
using ProjektZiotest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace ProjectTests
{
    public class QuestionControllerTests
    {
        private readonly Mock<IQuestionService> _mockService;
        private readonly QuestionController _controller;

        public QuestionControllerTests()
        {
            _mockService = new Mock<IQuestionService>();
            _controller = new QuestionController(_mockService.Object);
        }

        [Fact]
        public void GetQuestionById_ReturnsNotFound_WhenQuestionDoesNotExist()
        {
            _mockService.Setup(service => service.GetQuestionById(It.IsAny<int>())).Returns((Question)null);

            var result = _controller.GetQuestionById(1);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetQuestionById_ReturnsQuestion_WhenQuestionExists()
        {
            var question = new Question { Id = 1 };
            _mockService.Setup(service => service.GetQuestionById(It.IsAny<int>())).Returns(question);

            var result = _controller.GetQuestionById(1);

            Assert.Equal(question, result.Value);
        }
        [Fact]
        public void AddQuestion_ReturnsCreatedAtAction_WhenQuestionIsAdded()
        {
            var question = new Question { Id = 1 };
            _mockService.Setup(service => service.AddQuestion(It.IsAny<Question>()));

            var result = _controller.AddQuestion(question);

            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public void UpdateQuestion_ReturnsNoContent_WhenQuestionIsUpdated()
        {
            var question = new Question { Id = 1 };
            _mockService.Setup(service => service.UpdateQuestion(It.IsAny<int>(), It.IsAny<Question>()));

            var result = _controller.UpdateQuestion(1, question);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteQuestion_ReturnsNoContent_WhenQuestionIsDeleted()
        {
            _mockService.Setup(service => service.DeleteQuestion(It.IsAny<int>()));

            var result = _controller.DeleteQuestion(1);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void GetAllQuestions_ReturnsAllQuestions()
        {
            var questions = new List<Question> { new Question { Id = 1 }, new Question { Id = 2 } };
            _mockService.Setup(service => service.GetAllQuestions()).Returns(questions);

            var result = _controller.GetAllQuestions();

            Assert.Equal(questions, result.Value);
        }
    }
}
