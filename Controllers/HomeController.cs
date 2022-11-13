using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyFirstAzureWebApp.Models;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyFirstAzureWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //return View();
        // var webClient = new WebClient();
        //        var json = webClient.DownloadString(@"C:\Users\monke\Code\MyFirstAzureWebApp\lib\resources\sampledata.json");
 //##Get string from json file             
               FileStream jsonStream = System.IO.File.OpenRead(@"C:\Users\monke\Code\MyFirstAzureWebApp\lib\resources\sampledata.json"); 
               string json;
                using(var sr = new StreamReader(jsonStream))
                {
                json = sr.ReadToEnd();
                }
 //##Deserialize that string               
                var brands = JsonConvert.DeserializeObject<Brands>(json);
 //##Send that deserialized json to the view               
            return View(brands);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Test()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
