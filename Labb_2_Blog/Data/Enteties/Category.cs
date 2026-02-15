using System.ComponentModel.DataAnnotations;

namespace Labb_2_Blog.Data.Enteties
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
