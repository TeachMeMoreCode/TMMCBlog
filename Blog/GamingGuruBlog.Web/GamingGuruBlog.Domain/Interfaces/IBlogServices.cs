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
        void ProcessEditedBlogPost(BlogPost editedBlogPost);
        List<BlogPost> GetBlogPostByCategoryID(int categoryID);
        List<BlogPost> AllBlogPostsByTag(int tagID);
        void DeleteBlogPost(int blogID);
        List<BlogPost> GetAllBlogPosts();
        User GetUser(string userID);
        void EditUser(User editedUser);
        List<User> GetAllUsers();
        void DeleteCategory(int categoryID);
        void EditCategory(Category changedCategory);
        Category GetCategory(int categoryID);
        void AddCategory(Category newCategory);
    }
}