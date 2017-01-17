using GamingGuruBlog.Domain.Models;
using System.Collections.Generic;

namespace GamingGuruBlog.Domain.Interfaces
{
    public interface IBlogServices
    {
        BlogPost CreateNewBlogPost(string newPost);
        List<Category> GetAllCategories();
        int AddNewBlogPost(BlogPost newPost);
        List<Category> GetAssignedCategories(int blogID);
    }
}
