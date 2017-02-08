using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingGuruBlog.Domain
{
    public class CategoryServices
    {
        private ICategoryRepository _categoryRepo;
        private IBlogCategoryRepository _blogCategoryRepo;

        public CategoryServices(ICategoryRepository newCategoryRepo, IBlogCategoryRepository newBlogCategoryRepo)
        {
            _categoryRepo = newCategoryRepo;
            _blogCategoryRepo = newBlogCategoryRepo;
        }

        public void AddCategory(Category newCategory)
        {
            if (newCategory != null)
            {
                _categoryRepo.AddCategory(newCategory);
            }
        }

        public void DeleteCategory(int categoryID)
        {
            _categoryRepo.DeleteCategory(categoryID);
        }

        public void EditCategory(Category changedCategory)
        {
            _categoryRepo.EditCategory(changedCategory);
        }

        public Category GetCategory(int categoryID)
        {
            return _categoryRepo.GetCategory(categoryID);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepo.GetAllCategories();
        }

        public List<Category> GetUsedCategories()
        {
            return _categoryRepo.GetOnlyUsedCategories();
        }

        public void AddCategoriesToBlogPost(int blogPostID, List<Category> categoryIDs)
        {
            foreach (var catID in categoryIDs)
            {
                _blogCategoryRepo.AddCategoryToBlog(blogPostID, catID.CategoryId);
            }
        }

    }
}
