using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SwaggerDemoApp.Data;
using SwaggerDemoApp.Entities;
using SwaggerDemoApp.Infrastructure;
using SwaggerDemoApp.UseCases.Blog.DTOs;

namespace SwaggerDemoApp.UseCases.Blog.Commands
{
    public record CreateOrUpdateBlogCommand(CreateOrUpdateBlogDTO dto) : IRequest<Response<Guid>>;

    public sealed class CreateOrUpdateBlogCommandHandler : IRequestHandler<CreateOrUpdateBlogCommand, Response<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly BlogDBContext _dbContext;
        private readonly ILogger _logger;

        public CreateOrUpdateBlogCommandHandler(IMapper mapper, BlogDBContext dbContext, ILogger<CreateOrUpdateBlogCommandHandler> logger)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Response<Guid>> Handle(CreateOrUpdateBlogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.dto.Id != Guid.Empty)
                {
                    var dbBlog = await _dbContext.Blogs.FirstOrDefaultAsync(x => x.Id == request.dto.Id);

                    if (dbBlog != null)
                    {
                        _mapper.Map(request.dto, dbBlog);
                        _dbContext.Update(dbBlog);
                        await _dbContext.SaveChangesAsync(cancellationToken);
                        return Response<Guid>.Create(Enums.ResponseType.Success, dbBlog.Id, string.Empty);
                    }
                }

                var blog = _mapper.Map<BlogEntity>(request.dto);
                await _dbContext.AddAsync(blog, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Response<Guid>.Create(Enums.ResponseType.Success, blog.Id, string.Empty);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Response<Guid>.Create(Enums.ResponseType.Error, default, ex.Message);
            }
        }
    }
}