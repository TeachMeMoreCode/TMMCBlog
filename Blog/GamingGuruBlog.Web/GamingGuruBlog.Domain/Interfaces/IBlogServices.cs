using GamingGuruBlog.Domain.Models;
using System.Collections.Generic;

namespace GamingGuruBlog.Domain.Interfaces
{
    public interface IBlogServices
    {
        List<Category> GetAllCategories();
        int AddNewBlogPost(BlogPost newPost);
        List<Category> GetAssignedCategories(int blogID);
        void AddCategoriesToBlogPost(int blogPostID, List<Category> categoryIDs);
        List<Tag> AddCreatedTags(List<Tag> tagNames);
        void AddTagsToBlog(int blogID, List<Tag> tagID);
        BlogPost GetBlogPost(int blogID);
        List<Tag> GetAllTags();
    }
}