using News.Types.DTO;
using System.Collections.Generic;

namespace News.Service.Website.Service
{
    public interface IWebsiteService
    {
        List<WebsiteDto> GetAllWebSites();
        WebsiteDto GetWebSiteByName(string name);
    }
}
