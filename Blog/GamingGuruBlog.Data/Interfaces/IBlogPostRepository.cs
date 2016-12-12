using GamingGuruBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingGuruBlog.Data.Interfaces
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
