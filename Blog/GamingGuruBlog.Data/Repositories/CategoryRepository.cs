using GamingGuruBlog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using GamingGuruBlog.Domain.Models;
using System.Data.SqlClient;
using Dapper;

namespace GamingGuruBlog.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public void AddCategory(Category newCategory)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("CategoryName", newCategory.CategoryName);

                connection.Execute("Insert Into Category (CategoryName) values (@CategoryName)", parameters);
            }
        }

        public void DeleteCategory(int id)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", id);

                connection.Execute("delete b from BlogCategory b left join Category c on b.CategoryID = c.CategoryID where c.CategoryID = @ID", parameters);
                connection.Execute("delete c from Category c left join BlogCategory b on b.CategoryID = c.CategoryID where c.CategoryID = @ID", parameters);
            }
        }

        public void EditCategory(Category updatedCategory)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", updatedCategory.CategoryId);
                parameters.Add("CategoryName", updatedCategory.CategoryName);
                connection.Execute("update Category Set CategoryName = @CategoryName where CategoryID = @ID", parameters);

            }
        }

        public Category GetCategory(int id)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", id);
                Category category = connection.Query<Category>("select * from Category where Category.CategoryID = @ID", parameters).SingleOrDefault();

                return category;
            }
        }

        public List<Category> GetAllCategories()
        {
            List<Category> allCategories = new List<Category>();
            //TODO: probably need a try-catch
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                allCategories = connection.Query<Category>("SELECT * FROM Category").ToList();
            }

            return allCategories;
        }

        public List<Category> GetAssignedcategories(int blogID)
        {
            if (blogID > 0)
            {
                using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
                {
                    return connection.Query<Category>($"SELECT * FROM BlogPost AS bp JOIN BlogCategory AS bc ON bp.BlogPostID = bc.BlogPostID JOIN Category AS cat ON bc.CategoryID = cat.CategoryID WHERE bp.BlogPostID = {blogID}").ToList(); 
                }

            }
            else
            {
                return null;
            }
        }
    }
}
