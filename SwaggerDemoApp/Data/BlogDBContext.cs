using Microsoft.EntityFrameworkCore;
using SwaggerDemoApp.Entities;

namespace SwaggerDemoApp.Data
{
    public class BlogDBContext : DbContext
    {
        public DbSet<BlogEntity> Blogs { get; set; }
        public DbSet<PostEntity> Posts { get; set; }

        public BlogDBContext(DbContextOptions<BlogDBContext> options) : base(options) { }
    }
}