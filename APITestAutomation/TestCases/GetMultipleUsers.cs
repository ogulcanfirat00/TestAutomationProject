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
            Console.WriteLine("Status Code: " + response.StatusCode);
            Console.WriteLine("Response Content: " + response.Content);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));
            Assert.That(response.Content.Contains("page"), Is.True, "Response does not contain 'page' key");
            Assert.That(response.Content.Contains("per_page"), Is.True, "Response does not contain 'per_page' key");
            Assert.That(response.Content.Contains("total"), Is.True, "Response does not contain 'total' key");
            Assert.That(response.Content.Contains("total_pages"), Is.True, "Response does not contain 'total_pages' key");
            Assert.That(response.Content.Contains("data"), Is.True, "Response does not contain 'data' key");
        }

        [Test]
        public async Task GetSingleUserRequest()
        {
            var response = await userClient.GetSingleUser();
            Console.WriteLine("Status Code: " + response.StatusCode);
            Console.WriteLine("Response Content: " + response.Content);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));
            Assert.That(response.Content.Contains("data"), Is.True, "Response does not contain 'data' key");
            Assert.That(response.Content.Contains("id"), Is.True, "Response does not contain 'id' key");
            Assert.That(response.Content.Contains("email"), Is.True, "Response does not contain 'email' key");
            Assert.That(response.Content.Contains("first_name"), Is.True, "Response does not contain 'first_name' key");
            Assert.That(response.Content.Contains("last_name"), Is.True, "Response does not contain 'last_name' key");
            Assert.That(response.Content.Contains("avatar"), Is.True, "Response does not contain 'avatar' key");
            Assert.That(response.Content.Contains("support"), Is.True, "Response does not contain 'support' key");
            Assert.That(response.Content.Contains("url"), Is.True, "Response does not contain 'url' key");
            Assert.That(response.Content.Contains("text"), Is.True, "Response does not contain 'text' key");

        }
    }
}
