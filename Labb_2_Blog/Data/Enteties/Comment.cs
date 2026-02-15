using System.ComponentModel.DataAnnotations;

namespace Labb_2_Blog.Data.Enteties
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentContent { get; set; }

        //Främmande nycklar
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
