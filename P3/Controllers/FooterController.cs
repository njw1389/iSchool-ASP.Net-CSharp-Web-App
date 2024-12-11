using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P3.Models;
using P3.Services;

namespace P3.Controllers
{
    // Simple Controller So I'm Not Repeating Code In Every Pages Task<IActionResult>
    public class FooterController : Controller
    {
        protected async Task<FooterModel> GetFooterData()
        {
            DataRetrieval dataRetrieval = new DataRetrieval();
            var loadedFooter = await dataRetrieval.GetData("footer/");
            return JsonConvert.DeserializeObject<FooterModel>(loadedFooter);
        }
    }
}