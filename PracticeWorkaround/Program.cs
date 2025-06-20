using RestSharp;
using RestSharp.Authenticators;
using System.Threading;

//var options = new RestClientOptions("https://reqres.in/api/")
//{
//    //Authenticator = new HttpBasicAuthenticator("username", "password")
//};
//var client = new RestClient(options);
//var request = new RestRequest("users?page=1")/*.AddHeader("x-api-key", "reqres-free-v1")*/;
//// The cancellation token comes from the caller. You can still make a call without it.

//try
//{
//    var response = await client.GetAsync(request);
//    Console.WriteLine(response.Content);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex);
//}

var basePath = AppContext.BaseDirectory;
Console.WriteLine($"Looking for config in: {Path.Combine(basePath, "Configs/appsettings.json")}");