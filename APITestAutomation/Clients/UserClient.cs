using APITestAutomation.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestAutomation.Clients
{
    public class UserClient
    {
        private readonly RestClient client;

        public UserClient(string baseUrl)
        {
            client = new RestClient(baseUrl);             
        }

        public RestResponse CreateUser(UserRequest request)
        {
            var req = new RestRequest("users", Method.Post); 
            req.AddJsonBody(request);                        
            return client.Execute(req);                      
        }

        public async Task<RestResponse> GetMultipleUsers(int page = 1)
        {
            var request = new RestRequest($"users?page={page}", Method.Get).AddHeader("x-api-key", "reqres-free-v1");
            return await client.ExecuteAsync(request);
        }

    }
}
