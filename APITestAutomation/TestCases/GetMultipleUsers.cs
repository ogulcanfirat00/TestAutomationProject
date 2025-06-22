using APITestAutomation.Clients;
using APITestAutomation.Models;
using APITestAutomation.Utilities;
using Newtonsoft.Json;

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
            var responseJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<UserListResponse>(responseJson);

            Console.WriteLine("Status: " + response.StatusCode);
            Console.WriteLine("Content: " + responseJson);

            
            //Console.WriteLine("Email of first user: " + result.Data[0].First_Name);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));
            Assert.That(responseJson.Contains("page"), Is.True, "Response does not contain 'page' key");
            Assert.That(responseJson.Contains("per_page"), Is.True, "Response does not contain 'per_page' key");
            Assert.That(responseJson.Contains("total"), Is.True, "Response does not contain 'total' key");
            Assert.That(responseJson.Contains("total_pages"), Is.True, "Response does not contain 'total_pages' key");
            Assert.That(responseJson.Contains("data"), Is.True, "Response does not contain 'data' key");
            Assert.That(responseJson.Contains("id"), Is.True, "Response does not contain 'id' key");
            Assert.That(responseJson.Contains("email"), Is.True, "Response does not contain 'email' key");
            Assert.That(responseJson.Contains("first_name"), Is.True, "Response does not contain 'first_name' key");
            Assert.That(responseJson.Contains("last_name"), Is.True, "Response does not contain 'last_name' key");
            Assert.That(responseJson.Contains("avatar"), Is.True, "Response does not contain 'avatar' key");
            Assert.That(responseJson.Contains("support"), Is.True, "Response does not contain 'support' key");
            Assert.That(responseJson.Contains("url"), Is.True, "Response does not contain 'url' key");
            Assert.That(responseJson.Contains("text"), Is.True, "Response does not contain 'text' key");

        }

        [Test]
        public async Task GetSingleUserRequest()
        {
            var response = await userClient.GetSingleUser();
            var responseJson = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Status Code: " + response.StatusCode);
            Console.WriteLine("Response Content: " + responseJson);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));
            Assert.That(responseJson.Contains("data"), Is.True, "Response does not contain 'data' key");
            Assert.That(responseJson.Contains("id"), Is.True, "Response does not contain 'id' key");
            Assert.That(responseJson.Contains("email"), Is.True, "Response does not contain 'email' key");
            Assert.That(responseJson.Contains("first_name"), Is.True, "Response does not contain 'first_name' key");
            Assert.That(responseJson.Contains("last_name"), Is.True, "Response does not contain 'last_name' key");
            Assert.That(responseJson.Contains("avatar"), Is.True, "Response does not contain 'avatar' key");
            Assert.That(responseJson.Contains("support"), Is.True, "Response does not contain 'support' key");
            Assert.That(responseJson.Contains("url"), Is.True, "Response does not contain 'url' key");
            Assert.That(responseJson.Contains("text"), Is.True, "Response does not contain 'text' key");

            

        }

        [Test]
        public async Task CreateUser()
        {
            var response = await userClient.CreateUser(new UserRequest 
            {Name= "asdcede", Job = "dsasasad" });            

            var responseStatusCode = response.StatusCode;
            var responseJson = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Status Code: " + responseStatusCode);
            Console.WriteLine("Response Content: " + responseJson);

            Assert.That((int)response.StatusCode, Is.EqualTo(201));
            Assert.That(responseJson.Contains("Name"), Is.True, "Response does not contain 'name' key");
            Assert.That(responseJson.Contains("Job"), Is.True, "Response does not contain 'job' key");
            Assert.That(responseJson.Contains("id"), Is.True, "Response does not contain 'id' key");
            Assert.That(responseJson.Contains("createdAt"), Is.True, "Response does not contain 'createdAt' key");
        }

        [Test]
        public async Task CreateUserWithInvalidKeys()
        {
            var response = await userClient.CreateUserWithInvalidKeys(new UserRequestWithWrongModel 
            {InvalidKeyOne = "fdfdkskflds", InvalidKeyTwo = "addasjkdfjds" });

            var responseStatusCode = response.StatusCode;
            var responseContent = response.Content;

            Console.WriteLine("Status Code: " + responseStatusCode);
            Console.WriteLine("Response Content: " + responseContent);

            Assert.That((int)response.StatusCode, Is.EqualTo(400));
        }
    }
}
