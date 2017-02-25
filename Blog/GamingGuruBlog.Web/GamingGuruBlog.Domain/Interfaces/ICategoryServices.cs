using GamingGuruBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingGuruBlog.Domain.Interfaces
{
    public interface ICategoryServices
    {
        void AddCategory(Category newCategory);
        void DeleteCategory(int categoryID);
        void EditCategory(Category changedCategory);
        Category GetCategory(int categoryID);
        List<Category> GetAllCategories();
        List<Category> GetUsedCategories();
        void AddCategoriesToBlogPost(int blogPostID, List<Category> categoryIDs);
        void DeleteCategoryFromBlogPost(int blogPostID);
    }
}
