using GamingGuruBlog.Domain.Models;
using System.Collections.Generic;

namespace GamingGuruBlog.Domain.Interfaces
{
    public interface IBlogPostRepository
    {
        BlogPost GetBlogPost(int id);
        void EditBlogPost(BlogPost blogPost);
        void DeleteBlogPost(int id);
        int AddBlogPost(BlogPost newBlogPost);
        List<BlogPost> GetAllBlogPostsWithCategoriesAndTags();
        List<BlogPost> GetAllPostsByCategory(int id);
        List<BlogPost> GetAllBlogPostsByTag(int id);
    }
}
