namespace Labb_2_Blog.Data.DTO
{
    public class AddPostDTO
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int CategoryId { get; set; }
    }
}
