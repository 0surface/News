using System.Collections.Generic;

namespace News.Service.Service
{
    public interface IWebsiteService
    {
        List<WebsiteDto> GetAllWebSites();
    }
}
