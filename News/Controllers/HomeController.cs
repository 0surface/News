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
        private IWebsiteService _webSiteService;
        private IScraper _scraper;

        public HomeController(IScraper scraper, IWebsiteService webSiteService)
        {
            _scraper = scraper;
            _webSiteService = webSiteService;
        }

        public IActionResult Index()
        {
            WebsiteListVM vm = new WebsiteListVM();
            vm.Items = GetMockWebsiteList();
            return View(vm);
        }

        public IActionResult GetHeadlines(string name)
        {
            WebsiteVM selected = Websites()[name];
            if (selected != null)
            {
                string result = _scraper.GetHeadlines(Mapper.Map<WebsiteDto>(selected));
                return Content(result);
            }
            else
            {
                return StatusCode(404);
            }           
        }

        private Dictionary<string, WebsiteVM> Websites()
        {
            Dictionary<string, WebsiteVM> dict = new Dictionary<string, WebsiteVM>();

            try
            {
                List<WebsiteVM> webSites = GetMockWebsiteList();

                webSites.ForEach(w => dict.Add(w.Name, w));
            }
            catch (Exception) { }
            return dict;
        }

        private List<WebsiteVM> GetMockWebsiteList()
        {
            return Mapper.Map<List<WebsiteVM>>(_webSiteService.GetAllWebSites());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
