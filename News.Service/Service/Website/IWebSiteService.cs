using News.Types.Website;
using System.Collections.Generic;

namespace News.Service.Website.Service
{
    public interface IWebsiteService
    {
        List<WebsiteDto> GetAllWebSites();
    }
}
