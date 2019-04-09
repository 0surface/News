using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using News.Models;
using News.Service.Service.Scraper;
using News.Service.Website.Service;
using News.Types.DTO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            vm.Items = GetWebsiteList();
            return View(vm);
        }

        public async Task<IActionResult> GetHeadlines(string name)
        {
            WebsiteVM selected = Websites()[name];
            if (selected != null)
            {
                string result = await _scraper.GetHeadlines(Mapper.Map<WebsiteDto>(selected));
                return Content(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Returns a Dictionary of websites with website names as key.
        /// </summary>
        /// <returns>Dictionary<string, WebsiteVM></returns>
        private Dictionary<string, WebsiteVM> Websites()
          => GetWebsiteList()?.ToDictionary(website => website.Name, website => website);

        /// <summary>
        /// Gets a List of Websites from the database.
        /// </summary>
        /// <returns>List<WebsiteVM></returns>
        private List<WebsiteVM> GetWebsiteList() =>
            Mapper.Map<List<WebsiteVM>>(_webSiteService.GetAllWebSites());

    }
}
