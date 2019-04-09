using News.Types.Website;
using System.Collections.Generic;

namespace News.Service.Website.Service
{
    public class WebsiteService : IWebsiteService
    {
        /// <summary>
        /// Gets All WebsiteDto objects from the database.
        /// </summary>
        /// <returns>List<WebsiteDto></returns>
        public List<WebsiteDto> GetAllWebSites()
        {
            /*TODO : Fetech website list data from Repository*/

            List<WebsiteDto> list = new List<WebsiteDto>();
            list.Add(new WebsiteDto()
            {
                Id = 1,
                Name = "BBC",
                CanonicalUrl = "https://www.bbc.co.uk/",
                LogoImageUrl ="/images/bbc.png",
                HeadLineSelector = "//span[@class='top-story__title']"
            });

            list.Add(new WebsiteDto()
            {
                Id = 2,
                Name = "The Sun",
                CanonicalUrl = "https://www.thesun.co.uk/",
                LogoImageUrl = "/images/thesun.png",
                HeadLineSelector = "//p[@class='teaser__subdeck']"
            });

            return list;
        }
    }
}
