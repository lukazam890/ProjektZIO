using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ZioClient.ModelData
{
    public class HttpClientQuestion
    {
        private static readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        public string responseCommunicat { get; set; } = " ";

        private string url = "http://localhost:5216/api/Question";

        public Question GetById(int id)
        {
            try
            {

                var response = client.GetStringAsync(url + "/"+id.ToString());

                responseCommunicat = "Poprawnie pobrano rekord";

                return JsonSerializer.Deserialize<Question>(response.Result);
            }
            catch (Exception)
            {
                responseCommunicat = "Brak połączenia z serwerem";
                return default(Question);
            }
        }
        public List<Question> GetAll()
        {
            try
            {
                var response = client.GetStringAsync(url);
                List<Question> dataObjects = JsonSerializer.Deserialize<List<Question>>(response.Result);
                if (dataObjects.Count > 0)
                {
                    responseCommunicat = "Poprawnie pobrano rekordy";
                    return dataObjects;
                }
                else
                {
                    responseCommunicat = "Tabela jest pusta";
                    return new List<Question>();
                }
            }
            catch (Exception)
            {
                responseCommunicat = "Brak połączenia z serwerem";
                return new List<Question>();
            }

        }
        public void Delete(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url +"/"+id);
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
        public void Put(int id, Question newQuestion)
        {
            Question question = GetById(id);
            var request = new HttpRequestMessage(HttpMethod.Put, url+"/"+id);
            question = newQuestion;
            var content = new StringContent(JsonSerializer.Serialize(question), null, "application/json");
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

        public void AddQuestion(Question modelData)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5216/api/Question");
            // nagłówki dla metody POST
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
    }
}
