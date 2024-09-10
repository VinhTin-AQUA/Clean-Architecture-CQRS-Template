using Application.Features.Blogs.Queries.GetAllBlogs;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Blog, BlogVM>().ReverseMap();
        }
    }
}
