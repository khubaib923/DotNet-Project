using System.ComponentModel.DataAnnotations;

namespace NTier_Architecture.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int DisplayOrder { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
