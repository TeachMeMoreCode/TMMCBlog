using GamingGuruBlog.Domain.Models;
using System.Collections.Generic;

namespace GamingGuruBlog.Data.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategory(int id);
        void DeleteCategory(int id);
        void AddCategory(Category newCategory);
        void EditCategory(Category updatedCategory);
    }
}
