using GamingGuruBlog.Domain.Models;
using System.Collections.Generic;

namespace GamingGuruBlog.Domain.Interfaces
{
    public interface IBlogPostRepository
    {
        BlogPost GetBlogPost(int id);
        BlogPost GetApprovedBlogPost(int id);
        void EditBlogPost(BlogPost blogPost);
        void DeleteBlogPost(int id);
        int AddBlogPost(BlogPost newBlogPost);
        List<BlogPost> GetAllBlogPostsWithCategoriesAndTags();
        List<BlogPost> GetApprovedPostsByCategory(int id);
        List<BlogPost> GetpprovedBlogPostsByTag(int id);
        List<BlogPost> ApprovedBlogPostsWithCategoriesAndTags();
    }
}
