using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace ZioClient.ModelData
{
    public class HttpClientTest
    {
        private static readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        public string responseCommunicat { get; set; } = " ";

        private string url = "http://localhost:5216/api/Test";

        public void AddTest(Test modelData)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("access-control-allow-origin", "*");
            var content = new StringContent(JsonSerializer.Serialize(modelData), null, "application/json");

            request.Content = content;

            try
            {
                var response = client.SendAsync(request).Result;
                if (response.Content.ReadAsStringAsync().Result == "0")
                {
                    responseCommunicat = "Poprawnie dodano rekord";
                }

                else
                {
                    responseCommunicat = "Operacja dodania rekordu się nie powiodła";
                }
            }
            catch (Exception)
            {
                responseCommunicat = "Brak połączenia z webApi";
            }

        }
        public void Put(int id, List<Question> questions)
        {
            Test test = GetById(id);
            var request = new HttpRequestMessage(HttpMethod.Put, url + "/" + id+ "/add-questions");
            test.questions = questions;
            var content = new StringContent(JsonSerializer.Serialize(test), null, "application/json");
            request.Content = content;
            try
            {
                var response = client.SendAsync(request).Result;
                if (response.Content.ReadAsStringAsync().Result == "0")
                {
                    responseCommunicat = "Poprawnie dodano rekord";
                }

                else
                {
                    responseCommunicat = "Operacja dodania rekordu się nie powiodła";
                }
            }
            catch (Exception)
            {
                responseCommunicat = "Brak połączenia z webApi";
            }

        }
        public Test GetById(int id)
        {
            try
            {

                var response = client.GetStringAsync(url + "/" + id.ToString());

                responseCommunicat = "Poprawnie pobrano rekord";

                return JsonSerializer.Deserialize<Test>(response.Result);
            }
            catch (Exception)
            {
                responseCommunicat = "Brak połączenia z serwerem";
                return default(Test);
            }
        }
        public List<Test> GetByNick(string nick)
        {
            try
            {
                var response = client.GetStringAsync(url+"/user/"+nick);
                List<Test> dataObjects = JsonSerializer.Deserialize<List<Test>>(response.Result);
                if (dataObjects.Count > 0)
                {
                    responseCommunicat = "Poprawnie pobrano rekordy";
                    return dataObjects;
                }
                else
                {
                    responseCommunicat = "Tabela jest pusta";
                    return new List<Test>();
                }
            }
            catch (Exception)
            {
                responseCommunicat = "Brak połączenia z serwerem";
                return new List<Test>();
            }

        }
        public void Put(int id, Test newTest)
        {
            Test test = GetById(id);
            var request = new HttpRequestMessage(HttpMethod.Put, url + "/" + id);
            test = newTest;
            var content = new StringContent(JsonSerializer.Serialize(test), null, "application/json");
            request.Content = content;
            try
            {
                var response = client.SendAsync(request).Result;
                if (response.Content.ReadAsStringAsync().Result == "0")
                {
                    responseCommunicat = "Poprawnie dodano rekord";
                }

                else
                {
                    responseCommunicat = "Operacja dodania rekordu się nie powiodła";
                }
            }
            catch (Exception)
            {
                responseCommunicat = "Brak połączenia z webApi";
            }

        }
        public void Delete(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url + "/" + id);
            try
            {
                var response = client.SendAsync(request).Result;
                response.EnsureSuccessStatusCode();
                if (response.Content.ReadAsStringAsync().Result == "0")
                {
                    responseCommunicat = "Usunięto niepotrzebne rekordy";
                }
                else
                {
                    responseCommunicat = "Nie było rekordów w tej tabeli";
                }
            }
            catch (Exception)
            {
                responseCommunicat = "Brak połączenia z serwerem";
            }


        }
    }
}
