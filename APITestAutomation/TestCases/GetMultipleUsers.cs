using APITestAutomation.Clients;
using APITestAutomation.Utilities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestAutomation.TestCases
{
    public class GetMultipleUsers
    {
        private UserClient userClient;

        [SetUp]
        public void Setup()
        {
            var baseUrl = ConfigReader.GetBaseUrl();        // Get base URL from config
            userClient = new UserClient(baseUrl);           // Initialize API client
        }

        [Test]
        public async Task GetMultipleUserRequest()
        {

            var response = await userClient.GetMultipleUsers();
            Console.WriteLine(response.Content);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));
            Assert.That(response.Content.Contains("page"), Is.True, "Response does not contain 'page' key");
            Assert.That(response.Content.Contains("per_page"), Is.True, "Response does not contain 'per_page' key");
            Assert.That(response.Content.Contains("total"), Is.True, "Response does not contain 'total' key");
            Assert.That(response.Content.Contains("total_pages"), Is.True, "Response does not contain 'total_pages' key");
            Assert.That(response.Content.Contains("data"), Is.True, "Response does not contain 'data' key");
        }
    }
}
