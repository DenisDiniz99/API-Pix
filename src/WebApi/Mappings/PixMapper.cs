using AutoMapper;
using WebApi.ApiModels;
using WebApi.Models;

namespace WebApi.Mappings
{
    public class PixMapper : Profile
    {
        public PixMapper()
        {
            CreateMap<StaticPix, StaticPixRequest>().ReverseMap();
        }
    }
}