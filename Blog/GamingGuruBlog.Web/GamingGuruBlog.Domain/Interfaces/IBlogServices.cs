using GamingGuruBlog.Domain.Models;
using System.Collections.Generic;

namespace GamingGuruBlog.Domain.Interfaces
{
    public interface IBlogServices
    {
        BlogPost CreateNewBlogPost(string newPost);
        List<Category> GetAllCategories();
    }
}
