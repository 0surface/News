using System.Collections.Generic;

namespace News.Service
{
    public class WebsiteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CanonicalUrl { get; set; }
        public string HeadLineSelector { get; set; }
        public List<string> SubUrls { get; set; }
    }
}
