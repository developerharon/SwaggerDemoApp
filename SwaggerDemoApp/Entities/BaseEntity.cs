using System.ComponentModel.DataAnnotations;

namespace SwaggerDemoApp.Entities
{
    public class BaseEntity
    {
        [Required, Key]
        public Guid Id { get; set; }
    }
}