using System.Net;
using System.Threading.Tasks;
using MyFirstAzureWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MyFirstAzureWebApp.Controllers
{
    public class BrandController : Controller
        {
            public IActionResult Index()
            {
                var webClient = new WebClient();
                var json = webClient.DownloadString(@"C:\Users\monke\Code\MyFirstAzureWebApp\lib\resources\sampledata.json");
              
                
                var brands = JsonConvert.DeserializeObject<Brands>(json);
                return View(brands);
            }
        }

}