using System;
using System.Collections.Generic;
using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Domain.Models;
using System.Linq;

namespace GamingGuruBlog.Test
{
    internal class MockCategoryRepository : ICategoryRepository

    {
        private List<Category> _categories;

        public MockCategoryRepository()
        {
            _categories = new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Console"},
                new Category { CategoryId = 2, CategoryName = "Handheld"},
                new Category { CategoryId = 3, CategoryName = "PC"}
            };
        }

        public void AddCategory(Category newCategory)
        {
            _categories.Add(newCategory);
        }

        public void DeleteCategory(int id)
        {
           var categoryToDelete = _categories.Single(category => category.CategoryId == id);
            _categories.Remove(categoryToDelete);
        }

        public void EditCategory(Category updatedCategory)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAssignedcategories(int blogID)
        {
            throw new NotImplementedException();
        }
    }
}