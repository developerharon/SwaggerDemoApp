using System.ComponentModel.DataAnnotations;

namespace SwaggerDemoApp.Entities
{
    public sealed class BlogEntity : BaseEntity
    {
        [Required, StringLength(200)]
        public string Url { get; set; }

        public List<PostEntity> Posts { get; set; } = new List<PostEntity>();
    }
}