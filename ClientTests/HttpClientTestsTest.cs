using Moq.Protected;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using ZioClient.ModelData;
using System.Text.Json;

namespace ClientTests
{
    public class HttpClientTestsTest
    {
        private string url = "http://projektzioipp-001-site1.etempurl.com/api/Test";

        private JsonSerializerOptions JsonOptions = new JsonSerializerOptions{};

        [Fact]
        public void AddTestTest()
        {
            var test = new Test
            {
                id = 1,
                nick = "Test",
                result = 10,
                date = DateTime.Now,
                testQuestions = new List<TestQuestion>()
            };
            var expectedResponseContent = "0";
            var expectedResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            expectedResponseMessage.Content = new StringContent(expectedResponseContent);

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Post &&
                        req.RequestUri == new Uri(url) &&
                        //req.Headers.Contains("access-control-allow-origin") &&
                        req.Content.ReadAsStringAsync().Result == JsonSerializer.Serialize(test, JsonOptions)),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(expectedResponseMessage);

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var httpClientService = new HttpClientTest(httpClient);

            httpClientService.addTest(test);

            Assert.Equal("Poprawnie dodano pytania do testu.", httpClientService.responseCommunicat);
        }

        [Fact]
        public void PutQuestions()
        {
            int id = 10;
            var test = new Test
            {
                id = id,
                nick = "Test",
                result = 10,
                date = DateTime.Now,
                testQuestions = new List<TestQuestion>()
            };
            var questions = new List<int> { 1,2, 3 };
            var expectedResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Put &&
                        req.RequestUri == new Uri($"{url}/{id}/add-questions") &&
                        req.Content.ReadAsStringAsync().Result == JsonSerializer.Serialize(questions, JsonOptions)),
                    ItExpr.IsAny<System.Threading.CancellationToken>()
                )
                .ReturnsAsync(expectedResponseMessage); 

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var httpClientService = new HttpClientTest(httpClient);

            httpClientService.PutQuestion(id, questions);

            Assert.Equal("Poprawnie dodano pytania do testu.", httpClientService.responseCommunicat);
        }

        [Fact]
        public void GetAllTest()
        {
            var tests = new List<Test>
            {
                new Test
                {
                    id = 1,
                    nick = "Test",
                    result = 10,
                    date = DateTime.Now,
                    testQuestions = new List<TestQuestion>()
                },
                new Test
                {
                    id = 2,
                    nick = "Test1",
                    result = 10,
                    date = DateTime.Now,
                    testQuestions = new List<TestQuestion>()
                },
            };

            var expectedResponseContent = JsonSerializer.Serialize(tests);
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
            var httpClientService = new HttpClientTest(httpClient);

            var results = httpClientService.GetAll();

            Assert.NotEmpty(results);
            Assert.Equal(tests.Count, results.Count);
        }

        [Fact]
        public void GetByNick()
        {
            string nick = "Test";
            var tests = new List<Test> 
            { 
                new Test
                {
                    id= 1,
                    nick = nick,
                    date = DateTime.Now,
                    result = 10
                },
                new Test
                {
                    id= 2,
                    nick = nick,
                    date = DateTime.Now,
                    result = 5
                }
            };

            var expectedResponseContent = JsonSerializer.Serialize(tests);
            var expectedResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            expectedResponseMessage.Content = new StringContent(expectedResponseContent);

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Get &&
                        req.RequestUri == new Uri(url + "/user/" + nick)),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(expectedResponseMessage);

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var httpClientService = new HttpClientTest(httpClient);

            var results = httpClientService.GetByNick(nick);

            Assert.NotEmpty(results);
            Assert.Equal(tests.Count, results.Count);
            Assert.Equal("Poprawnie pobrano rekordy", httpClientService.responseCommunicat);
        }
    }
}
