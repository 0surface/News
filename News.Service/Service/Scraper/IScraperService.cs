using News.Types.DTO;
using System.Threading.Tasks;

namespace News.Service.Service.Scraper
{
    public interface IScraperService
    {
        Task<string> GetHeadlines(string name);
    }
}
