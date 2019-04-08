using HtmlAgilityPack;
using News.Service.Model;
using Newtonsoft.Json;
using OpenScraping;
using OpenScraping.Config;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace News.Service.Service
{
    public class Scraper : IScraper
    {
        public string GetHeadlines(WebsiteDto dto)
        {
            Node node = ConstructHeadlineData(dto.Name, dto.CanonicalUrl,dto.HeadLineSelector);
            Node[] result = new Node[1];

            

            result.SetValue(node, 0);
            return JsonConvert.SerializeObject(result);
        }

        private async void GetWebSite(string url)
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
             htmlDocument.LoadHtml(html);

            var x1 = htmlDocument.DocumentNode.Descendants("div");

            var x2 = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("href", "").Contains("http"))
                .ToList();

            var storyHtml = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("top-story__wrapper"))
                .ToList();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headlineSelector"></param>
        /// <returns></returns>
        private List<Node> GetWebData(string url, string headlineSelector)
        {
            HtmlWeb web = new HtmlWeb();
            List<Node> nodes = new List<Node>();
            HtmlDocument doc = web.Load(url);

            var headerNames = doc.DocumentNode
                .SelectNodes(headlineSelector)
                .Select(node => node.InnerText)
                .ToList();

            foreach (var header in headerNames)
            {
                nodes.Add(new Node(header, ""));
            }

            return nodes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteName"></param>
        /// <param name="url"></param>
        /// <param name="headlineSelector"></param>
        /// <returns></returns>
        private Node ConstructHeadlineData(string siteName, string url, string headlineSelector)
        {
            Node topNode = new Node(siteName, "null");

            
            List<Node> headlineNodes = GetWebData(url, headlineSelector);
            headlineNodes?.ForEach(x => x.Parent = siteName);
           
            topNode.Children = headlineNodes;

            return topNode;
        }
    }
}
