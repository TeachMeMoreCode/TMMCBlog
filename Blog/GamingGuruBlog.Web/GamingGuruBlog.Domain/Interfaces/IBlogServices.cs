using GamingGuruBlog.Domain.Models;
using System.Collections.Generic;

namespace GamingGuruBlog.Domain.Interfaces
{
    public interface IBlogServices
    {
        BlogPost GetBlogPost(int blogID);

        BlogPost GetApprovedBlogPost(int id);

        List<BlogPost> GetAllBlogPosts();

        List<BlogPost> GetApprovedBlogPosts();

        List<BlogPost> AllApprovedBlogPostsByTag(int tagID);

        List<BlogPost> AllApprovedBlogPostsByCategoryID(int categoryID);

        void DeleteBlogPost(int blogID);

        List<Category> GetAllCategories();

        List<Category> GetUsedCategories();

        void AddNewBlogPost(BlogPost newPost);
        List<Category> GetAssignedCategories(int blogID);
        void AddCategoriesToBlogPost(int blogPostID, List<Category> categoryIDs);
        void ProcessEditedBlogPost(BlogPost editedBlogPost);
        User GetUser(string userID);
        void EditUser(User editedUser);
        List<User> GetAllUsers();
        void DeleteCategory(int categoryID);
        void EditCategory(Category changedCategory);
        Category GetCategory(int categoryID);
        void AddCategory(Category newCategory);
    }
}