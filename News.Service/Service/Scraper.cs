using Newtonsoft.Json;

namespace News.Service.Service
{
    public class Scraper : IScraper
    {
        public string GetHeadlines(string url)
        {
            return JsonConvert.SerializeObject("");
        }
    }
}
