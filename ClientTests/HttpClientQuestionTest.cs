using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using ZioClient.ModelData;
using System.Text.Json.Serialization.Metadata;
using Xunit;

namespace ClientTests
{
    public class HttpClientQuestionTest
    {
        private string url = "http://projektzioipp-001-site1.etempurl.com/api/Question";

        private JsonSerializerOptions JsonOptions = new JsonSerializerOptions{};

        [Fact]
        public void AddQuestionTest()
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

            var expectedResponseContent = "0";
            var expectedResponseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            expectedResponseMessage.Content = new StringContent(expectedResponseContent);

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Post &&
                        req.RequestUri == new Uri(url) &&
                        req.Content.ReadAsStringAsync().Result == JsonSerializer.Serialize(question, JsonOptions)),
                    ItExpr.IsAny<System.Threading.CancellationToken>()
                )
                .ReturnsAsync(expectedResponseMessage); 


            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var httpClientService = new HttpClientQuestion(httpClient);

            httpClientService.AddQuestion(question);

            Assert.Equal("Poprawnie dodano rekord", httpClientService.responseCommunicat);
        }

        [Fact]
        public void GetByIdTest()
        {
            var expectedId = 12;
            var question = new Question
            {
                id = expectedId,
                questionContent = "What is the capital of France?",
                correctAnswer = 1,
                answer1 = "Paris",
                answer2 = "London",
                answer3 = "Berlin",
                answer4 = "Madrid",
                reference = "https://en.wikipedia.org/wiki/Paris",
                testQuestions = new List<TestQuestion>()
            };

            var expectedResponseContent = JsonSerializer.Serialize(question);
            var expectedResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            expectedResponseMessage.Content = new StringContent(expectedResponseContent);

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Get &&
                        req.RequestUri == new Uri(url + "/" + expectedId)),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(expectedResponseMessage);

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var httpClientService = new HttpClientQuestion(httpClient);

            var result = httpClientService.GetById(expectedId);

            Assert.Equal(expectedId, question.id);
            Assert.Equal(question.questionContent, result.questionContent);
            Assert.Equal(question.answer1, result.answer1);
            Assert.Equal(question.answer2, result.answer2);
            Assert.Equal(question.answer3, result.answer3);
            Assert.Equal(question.answer4, result.answer4);
            Assert.Equal(question.reference, result.reference);
        }

        [Fact]
        public void GetAllTest()
        {
            var questions = new List<Question>()
            {
                new Question
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
                },
                new Question
                {
                    id = 1,
                    questionContent = "What is the capital of Germany?",
                    correctAnswer = 1,
                    answer1 = "Paris",
                    answer2 = "London",
                    answer3 = "Berlin",
                    answer4 = "Madrid",
                    reference = "https://en.wikipedia.org/wiki/Berlin",
                    testQuestions = new List<TestQuestion>()
                },
            };

            var expectedResponseContent = JsonSerializer.Serialize(questions);
            var expectedResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            expectedResponseMessage.Content = new StringContent(expectedResponseContent);

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Get &&
                        req.RequestUri == new Uri(url)),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(expectedResponseMessage);

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var httpClientService = new HttpClientQuestion(httpClient);

            var results = httpClientService.GetAll();

            Assert.NotEmpty(results);
            Assert.Equal(questions.Count, results.Count);
        }
    }
}
