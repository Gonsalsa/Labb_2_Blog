using Labb_2_Blog.Core.Interface;
using Labb_2_Blog.Data.DTO;
using Labb_2_Blog.Data.Enteties;
using Labb_2_Blog.Data.Interfaces;

namespace Labb_2_Blog.Core.Services
{
    public class BlogpostService : IBlogPostService
    {
        private readonly IPostRepo _blogPostRepo;

        public BlogpostService(IPostRepo blogPostRepo)
        {
            _blogPostRepo = blogPostRepo;
        }

        public async Task<bool> AddBlogPostAsync(AddPostDTO dto)
        {
            if (dto == null)
            {
                return false;
            }

            var post = new BlogPost
            {
                BlogPostTitle = dto.Title,
                BlogPostContent = dto.Content,
                AuthorId = dto.AuthorId,
                CategoryId = dto.CategoryId
            };

            await _blogPostRepo.AddPostAsync(post);
            return true;
        }

        public async Task<bool> DeletePostAsync(int blogPostId, int deleterId)
        {
            if (deleterId <= 0)
            {
                return false;
            }

            var existing = await _blogPostRepo.GetPostByIdAsync(blogPostId);
            if (existing == null)
            {
                return false;
            }

            if (existing.AuthorId != deleterId)
            {
                return false;
            }

            await _blogPostRepo.DeletePostAsync(blogPostId);
            return true;
        }

        public async Task<BlogPost?> GetBlogPostByIdAsync(int id)
        {
            return await _blogPostRepo.GetPostByIdAsync(id);
        }

        public async Task<List<BlogPost>> GetBlogPostsAsync()
        {
            return await _blogPostRepo.GetAllPostAsync();
        }

        public async Task<List<BlogPost>> SearchByCategoryAsync(int CatId)
        {
            return await _blogPostRepo.GetPostByCategoryAsync(CatId);
        }

        public async Task<List<BlogPost>> SearchByTitleAsync(string title)
        {
            return await _blogPostRepo.GetPostByTitleAsync(title);
        }

        public async Task<bool> UpdateBlogPostAsync(int blogPostId, UpdatePostDTO dto, int updatingUserId)
        {
            var existing = _blogPostRepo.GetPostByIdAsync(blogPostId).Result;

            if (existing == null)
            {
                return false;
            }

            if (existing.AuthorId != updatingUserId)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(dto.Title))
            {
                existing.BlogPostTitle = dto.Title;
            }

            if (!string.IsNullOrEmpty(dto.Content))
            {
                existing.BlogPostContent = dto.Content;
            }

            if (dto.categoryId.HasValue)
            {
                existing.CategoryId = dto.categoryId.Value;
            }

            await _blogPostRepo.UpdatePostAsync(existing);
            return true;

        }
    }
}
