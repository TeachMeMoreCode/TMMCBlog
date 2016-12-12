using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingGuruBlog.Data.Models;

namespace GamingGuruBlog.Data.Interfaces
{
    public interface IBlogCategoryRepository
    {
        void AddCategoryToBlog(int blogPostId, int category);
        void DeleteCategoryFromBlogPost(int blogPostId);
    }
}
