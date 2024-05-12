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
        private HttpClient client = new HttpClient();

        public HttpClientQuestion(HttpClient client) 
        {
            this.client = client;
        }

        public string responseCommunicat { get; set; } = " ";

        private string url = "http://projektzioipp-001-site1.etempurl.com/api/Question";

        public void AddQuestion(Question modelData)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("access-control-allow-origin", "*");
            var content = new StringContent(JsonSerializer.Serialize(modelData), null, "application/json");
            responseCommunicat = JsonSerializer.Serialize(modelData).ToString();
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
    }
}
