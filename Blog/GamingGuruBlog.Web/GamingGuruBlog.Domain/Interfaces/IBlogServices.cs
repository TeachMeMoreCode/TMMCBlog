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

        void AddNewBlogPost(BlogPost newPost);
      
        void ProcessEditedBlogPost(BlogPost editedBlogPost);
      
        User GetUser(string userID);
      
        void EditUser(User editedUser);
      
        List<User> GetAllUsers();
    }
}