using News.Service.Service.Scraper;
using News.Types.D3Tree;
using News.Types.Website;
using News.Util.D3Tree;
using News.Util.WebScraper;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace News.Service.Scraper.Service
{   
    public class ScraperService : IScraperService
    {
        /// <summary>
        /// Asynchronoulsy Returns a json string of headlines D3 tree node data for the provided WebsiteDto
        /// </summary>
        /// <param name="dto">WebsiteDto</param>
        /// <returns>Task<string></returns>
        public async Task<string> GetHeadlines(WebsiteDto dto)
        {
            try
            {
                D3TreeNode node = await ConstructHeadlineData(dto.Name, dto.CanonicalUrl, dto.HeadLineSelector);

                /*Warp node in an array and send json result*/
                D3TreeNode[] result = new D3TreeNode[1];
                result.SetValue(node, 0);

                return JsonConvert.SerializeObject(result);
            }
            catch (Exception)
            {
                //TODO: Proper exception handling to propagate to calling client
                return JsonConvert.SerializeObject("[]");
            }
        }



        /// <summary>
        /// Asynchronoulsy Returns a d3 tree node headlines object for the given url,site name and headline selector.
        /// Fetches the html of the webpage asynchornously and extracts the news headline texts values
        /// using the provided selector (uses Html Agility pack nuget package). The list of headlines is
        /// cleaned and limited to the set headline count value. A D3TreeNode is then constrcuted for the
        /// headlines and returned.
        /// If in error, returns an empty D3TreeNode object.
        /// </summary>
        /// <param name="siteName"></param>
        /// <param name="url"></param>
        /// <param name="headlineSelector"></param>
        /// <returns>Task<D3TreeNode></returns>
        private async Task<D3TreeNode> ConstructHeadlineData(string siteName, string url, string headlineSelector)
        {
            try
            {
                /* Asynchoronusly read webpage and extract news headlines */
                var doc = await WebScraper.GetHtmlDocument(url);
                var rawList = await WebScraper.GetRawHeadlines(doc, headlineSelector);
                var cleanedList = await WebScraper.CleanHeadlines(rawList);
                var list = WebScraper.GetLimitedHeadlines(cleanedList, 12);

                /* Construct D3 tree data from news headline list*/
                var headlineNodes = D3TreeNodeMaker.GetNodesFromStringList(list);
                var node = D3TreeNodeMaker.ConstructNode(siteName, "null", headlineNodes);

                return node;
            }
            catch (Exception)
            {
                return D3TreeNode.Empty();
            }
        }
    }
}
