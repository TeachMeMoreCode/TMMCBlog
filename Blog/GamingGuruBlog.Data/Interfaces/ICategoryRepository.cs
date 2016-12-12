using GamingGuruBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
