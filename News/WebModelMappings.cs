using AutoMapper;
using News.Models;
using News.Types.Website;

namespace News
{
    public class WebModelMappings : Profile
    {
        public WebModelMappings()
        {
            CreateMap<WebsiteVM, WebsiteDto>().ReverseMap();
        }
    }
}
