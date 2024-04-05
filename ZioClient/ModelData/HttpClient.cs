using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace ZioClient.ModelData
{
    public class HttpClient
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

        public void AddTest(Test modelData)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5216/api/Test");
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
