using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using News.Models;
using News.Service;
using News.Service.Service;

namespace News.Controllers
{
    public class HomeController : Controller
    {
        private IScraper _scraper;

        public HomeController(IScraper scraper)
        {
            _scraper = scraper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetHeadlines(string website)
        {            
            string result = _scraper.GetHeadlines(Mapper.Map<WebsiteDto>(Websites()["BBC"]));
            return Content(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private Dictionary<string, WebsiteVM> Websites()
        {
            Dictionary<string, WebsiteVM> dict = new Dictionary<string, WebsiteVM>();
            dict.Add("BBC", new WebsiteVM() {
                Id = 1,
                Name = "BBC",
                CanonicalUrl = "https://www.bbc.co.uk/",
                HeadLineSelector = "//span[@class='top-story__title']"
            });
            return dict;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
