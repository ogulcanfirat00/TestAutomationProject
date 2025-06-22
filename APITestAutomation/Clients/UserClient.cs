using APITestAutomation.Models;
using Newtonsoft.Json;
using System.Text;

namespace APITestAutomation.Clients
{
    public class UserClient
    {        
        private readonly HttpClient httpClient;

        public UserClient(string baseUrl)
        {
            httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
            httpClient.DefaultRequestHeaders.Add("x-api-key", "reqres-free-v1");
        }

        public async Task<HttpResponseMessage> GetMultipleUsers(int page = 1)
        {
            var response = await httpClient.GetAsync($"users?page={page}");
            return response;
        }

        public async Task<HttpResponseMessage> GetSingleUser(int user = 1)
        {
            var response = await httpClient.GetAsync($"users/{user}");
            return response;
        }

        public async Task<HttpResponseMessage> CreateUser(UserRequest request)
        {

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("users", content);
            return response;

        }

        public async Task<HttpResponseMessage> CreateUserWithInvalidKeys(UserRequestWithWrongModel request)
        {

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("users", content);
            return response;

        }

    }
}
