using News.Types.Website;
using System.Threading.Tasks;

namespace News.Service.Service.Scraper
{
    public interface IScraperService
    {
        Task<string> GetHeadlines(WebsiteDto dto);
    }
}
