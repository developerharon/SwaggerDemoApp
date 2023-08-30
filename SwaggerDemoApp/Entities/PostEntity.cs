using System.ComponentModel.DataAnnotations;

namespace SwaggerDemoApp.Entities
{
    public sealed class PostEntity : BaseEntity
    {
        [Required, StringLength(200)]
        public string Title { get; set; }
        [Required, StringLength(1000)]
        public string Content { get; set; }

        public Guid BlogId { get; set; }

        public BlogEntity Blog { get; set; }
    }
}