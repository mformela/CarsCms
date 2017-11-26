using CarsCms.ApiConsumer.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CarsCms.ApiConsumer
{
    public class Client
    {
        private HttpClient _client;  
        private HttpResponseMessage _httpResponse;
        private const string Url = "http://localhost:53353/api/Performances";
        private const string UrlEmail = "http://localhost:53353/api/Email";
        private string _json;


        //tworzymy konstrukt z instancja klienta -> otwieramy ścieżkę do API
        public Client()
        {
            _client = new HttpClient();
        }


        //
        public async Task<List<Performance>> GetAll() // tworzy nam się nowy watek - wymagane są async przy API
        {
            _httpResponse = await _client.GetAsync(Url); // komunikacja z API; reszta to obrobienie tego co przyszło 
            _json = _httpResponse.Content.ReadAsStringAsync().Result; // httpResponse musimy przetworzyć na json (jest to string, nadaje mu strukturę jsonową) 
            return JsonConvert.DeserializeObject<List<Performance>>(_json); // statyczna klasa,  zeby zdeserializowała na listę konkretnego modelu 

        }

      



        //tutaj mamy kontakt w drugą stronę 
        public async Task<HttpStatusCode> SetPerformance(Performance performance)
        {
            //trzeba dociągnąć paczkę  System.Net.Http.Formatting.Extension

            _httpResponse = await _client.PostAsJsonAsync(Url, performance);
            return _httpResponse.StatusCode;

        }


        //tutaj dodajemy wątek dotyczący Api Email

        public async Task<HttpStatusCode> SendEmail(EmailApiModel emailModel)
        {
            //trzeba dociągnąć paczkę  System.Net.Http.Formatting.Extension

            _httpResponse = await _client.PostAsJsonAsync(UrlEmail, emailModel);
            return _httpResponse.StatusCode;

        }



    }
}