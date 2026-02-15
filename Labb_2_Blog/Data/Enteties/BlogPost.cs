using System.ComponentModel.DataAnnotations;

namespace Labb_2_Blog.Data.Enteties
{
    public class BlogPost
    {
        [Key]
        public int BlogPostId { get; set; }
        public string BlogPostTitle { get; set; }
        public string BlogPostContent { get; set; }

        //Främmande nycklar
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
