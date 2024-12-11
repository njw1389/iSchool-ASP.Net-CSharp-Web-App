using Microsoft.AspNetCore.Mvc;
using P3.Models;
using P3.Services;
using System.Diagnostics;
using Newtonsoft.Json;
using System;

namespace P3.Controllers
{
    public class HomeController : FooterController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            /* About */
            DataRetrieval dataRetrieval = new DataRetrieval();
            var loadedAbout = await dataRetrieval.GetData("about/");
            var aboutResult = JsonConvert.DeserializeObject<AboutModel>(loadedAbout);
            /* News */
            var loadedNews = await dataRetrieval.GetData("news/");
            var newsResult = JsonConvert.DeserializeObject<NewsModel>(loadedNews);

            /* Holder Model */
            var indexViewModel = new IndexViewModel
            {
                About = aboutResult,
                News = newsResult,
            };

            /* Footer */
            ViewData["FooterModel"] = await GetFooterData();

            return View(indexViewModel);
        }

        public async Task<IActionResult> Degrees()
        {
            /*
             * Go Get Data
             * Put the Data in a Model
             * Send the Result to the View
             */
            DataRetrieval dataRetrieval = new DataRetrieval();
            var loadedDegrees = await dataRetrieval.GetData("degrees/");

            // We now have a String of Data - Need to Convert it to a JSON Object
            var degreesResult = JsonConvert.DeserializeObject<DegreesModel>(loadedDegrees);

            ViewData["FooterModel"] = await GetFooterData();

            // Send the Data to the View
            return View(degreesResult);
        }

        public async Task<IActionResult> GetCourseDetails(string courseId)
        {
            DataRetrieval dataRetrieval = new DataRetrieval();
            var loadedCourse = await dataRetrieval.GetData($"course/courseID={courseId}");
            var courseResult = JsonConvert.DeserializeObject<CourseModel>(loadedCourse);

            return Json(courseResult);
        }

        public async Task<IActionResult> Minors()
        {
            DataRetrieval dataRetrieval = new DataRetrieval();
            var loadedMinors = await dataRetrieval.GetData("minors/");
            var minorsResult = JsonConvert.DeserializeObject<MinorsModel>(loadedMinors);

            ViewData["FooterModel"] = await GetFooterData();

            return View(minorsResult);
        }

        public async Task<IActionResult> Employment()
        {
            DataRetrieval dataRetrieval = new DataRetrieval();
            var loadedEmployment = await dataRetrieval.GetData("employment/");
            var rtnResult = JsonConvert.DeserializeObject<EmploymentModel>(loadedEmployment);

            ViewData["FooterModel"] = await GetFooterData();

            return View(rtnResult);
        }

        public async Task<IActionResult> People()
        {
            DataRetrieval dataRetrieval = new DataRetrieval();
            var loadedPeople = await dataRetrieval.GetData("people/");
            var rtnResult = JsonConvert.DeserializeObject<PeopleModel>(loadedPeople);

            ViewData["FooterModel"] = await GetFooterData();

            return View(rtnResult);
        }

        //public async Task<IActionResult> Research()
        //{
            //DataRetrieval dataRetrieval = new DataRetrieval();
            //var loadedResearch = await dataRetrieval.GetData("research/");
            //var rtnResult = JsonConvert.DeserializeObject<ResearchModel>(loadedResearch);

            //ViewData["FooterModel"] = await GetFooterData();

            // Send the Data to the View
            //return View(rtnResult);
        //}

        //public async Task<IActionResult> Resources()
        //{
            //DataRetrieval dataRetrieval = new DataRetrieval();
            //var loadedResources = await dataRetrieval.GetData("resources/");
            //var resourcesResult = JsonConvert.DeserializeObject<ResourcesModel>(loadedResources);

            //ViewData["FooterModel"] = await GetFooterData();

            //return View(resourcesResult);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}