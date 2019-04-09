using AutoMapper;
using News.Models;
using News.Types.DTO;

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
