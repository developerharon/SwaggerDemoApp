using AutoMapper;
using SwaggerDemoApp.Entities;
using SwaggerDemoApp.UseCases.Blog.DTOs;

namespace SwaggerDemoApp.Mapping
{
    public sealed class BlogMappings : Profile
    {
        public BlogMappings()
        {
            CreateMap<CreateOrUpdateBlogDTO, BlogEntity>();
            CreateMap<BlogEntity, BlogDTO>();
        }
    }
}