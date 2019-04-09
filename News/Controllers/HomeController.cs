using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using News.Models;
using News.Service.Service.Scraper;
using News.Service.Website.Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class HomeController : Controller
    {
        private IWebsiteService _webSiteService;
        private IScraperService _scraper;

        public HomeController(IScraperService scraper, IWebsiteService webSiteService)
        {
            _scraper = scraper;
            _webSiteService = webSiteService;
        }

        public IActionResult Index()
        {
            WebsiteListVM vm = new WebsiteListVM();
            
            // Gets a List of Websites from the database.
            vm.Items = Mapper.Map<List<WebsiteVM>>(_webSiteService.GetAllWebSites());

            return View(vm);
        }

        public async Task<IActionResult> GetHeadlines(string name)
        {
            try
            {
                string result = await _scraper.GetHeadlines(name);
                return Content(result);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
        }
    }
}
