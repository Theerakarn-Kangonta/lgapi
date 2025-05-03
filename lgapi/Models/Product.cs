using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lgapi.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(255)]
        public string? Name { get; set; }

        [MaxLength(4000)]
        public string? Detail { get; set; }

        public int? CategoryGroup { get; set; }

        [MaxLength(1000)]
        public string? ImageUrl { get; set; }
    }
}
