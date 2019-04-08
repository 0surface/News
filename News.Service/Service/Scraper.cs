using News.Service.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace News.Service.Service
{
    public class Scraper : IScraper
    {
        public string GetHeadlines(string url)
        {
            Node node = MockHeadlineData();
            Node[] result = new Node[1];

            result.SetValue(node, 0);
            return JsonConvert.SerializeObject(result);
        }

        private Node MockHeadlineData()
        {
            Node topNode = new Node("BBC", "null");

            List<Node> secondLevel = new List<Node>()
            {
                new Node ("News HeadLine 1",topNode.Name),
                new Node("News HeadLine 2", topNode.Name),
                new Node("News HeadLine 3", topNode.Name),
                new Node("News HeadLine 4", topNode.Name),
                new Node("News HeadLine 5", topNode.Name),
                new Node("News HeadLine 6", topNode.Name),
                new Node("News HeadLine 7", topNode.Name),
            };

            topNode.Children = secondLevel;

            return topNode;
        }
    }
}
