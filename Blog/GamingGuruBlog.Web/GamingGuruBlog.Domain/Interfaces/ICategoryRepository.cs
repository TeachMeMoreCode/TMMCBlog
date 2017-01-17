using GamingGuruBlog.Domain.Models;
using System.Collections.Generic;

namespace GamingGuruBlog.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategory(int id);
        void DeleteCategory(int id);
        void AddCategory(Category newCategory);
        void EditCategory(Category updatedCategory);
        List<Category> GetAssignedcategories(int blogID);
    }
}
