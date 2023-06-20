

using System.ComponentModel.DataAnnotations;

namespace FirstWebApplication.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayProperty { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
