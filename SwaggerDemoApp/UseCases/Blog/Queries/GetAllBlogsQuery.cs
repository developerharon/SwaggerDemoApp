using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SwaggerDemoApp.Data;
using SwaggerDemoApp.Extensions;
using SwaggerDemoApp.Infrastructure;
using SwaggerDemoApp.UseCases.Blog.DTOs;

namespace SwaggerDemoApp.UseCases.Blog.Queries
{
    public record GetAllBlogsQuery : IRequest<Response<IEnumerable<BlogDTO>>>;

    public sealed class GetAllBlogsQueryHandler : IRequestHandler<GetAllBlogsQuery, Response<IEnumerable<BlogDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly BlogDBContext _dbContext;
        private readonly ILogger _logger;

        public GetAllBlogsQueryHandler(IMapper mapper, BlogDBContext dbContext, ILogger<GetAllBlogsQueryHandler> logger)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<BlogDTO>>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var dbBlogs = await _dbContext.Blogs.ToListAsync();
                var blogsDto = dbBlogs.MapBlogEntityListToDTOList(_mapper);
                return Response<IEnumerable<BlogDTO>>.Create(Enums.ResponseType.Success, blogsDto, string.Empty);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Response<IEnumerable<BlogDTO>>.Create(Enums.ResponseType.Error, null, ex.Message);
            }
        }
    }
}