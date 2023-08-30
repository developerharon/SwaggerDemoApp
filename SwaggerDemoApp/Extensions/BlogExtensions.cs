using AutoMapper;
using SwaggerDemoApp.Entities;
using SwaggerDemoApp.UseCases.Blog.DTOs;

namespace SwaggerDemoApp.Extensions
{
    public static class BlogExtensions
    {
        public static IEnumerable<BlogDTO> MapBlogEntityListToDTOList(this IEnumerable<BlogEntity> blogEntities, IMapper mapper)
        {
            var result = new List<BlogDTO>(blogEntities.Count());
            foreach (var blogEntity in blogEntities)
            {
                result.Add(blogEntity.MapBlogEntityToDTO(mapper));
            }
            return result;
        }

        public static BlogDTO MapBlogEntityToDTO(this BlogEntity blogEntity, IMapper mapper) => mapper.Map<BlogDTO>(blogEntity);
    }
}