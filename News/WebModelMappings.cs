using AutoMapper;
using News.Models;
using News.Service;

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
