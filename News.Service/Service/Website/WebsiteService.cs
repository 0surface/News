using News.Types.DTO;
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

            list.Add(new WebsiteDto()
            {
                Id = 3,
                Name = "The Guardian",
                CanonicalUrl = "https://www.theguardian.com/uk",
                LogoImageUrl = "/images/theGuardian.png",
                HeadLineSelector = "//span[@class='js-headline-text']"
            });


            list.Add(new WebsiteDto()
            {
                Id = 4,
                Name = "The Independent",
                CanonicalUrl = "https://www.independent.co.uk/",
                LogoImageUrl = "/images/theindependent.png",
                HeadLineSelector = "//div[@class='headline']"
            });

            return list;
        }
    }
}
