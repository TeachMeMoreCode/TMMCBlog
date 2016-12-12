using GamingGuruBlog.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingGuruBlog.Data.Models;
using System.Data.SqlClient;
using Dapper;

namespace GamingGuruBlog.Data.Repositories
{
    public class BlogCategoryRepository : IBlogCategoryRepository
    {
        public void AddCategoryToBlog(int blogPostId, int category)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {

                var param = new DynamicParameters();

                param.Add("Cid", category);
                param.Add("Bid", blogPostId);

                connection.Execute("INSERT INTO BlogCategory (CategoryID, BlogPostID) VALUES(@Cid, @Bid)", param);
            };
        }

        public void DeleteCategoryFromBlogPost(int blogPostId)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                var param = new DynamicParameters();
                param.Add("Bid", blogPostId);

                connection.Execute("Delete From BlogCategory Where BlogPostID = @Bid", param);
            }

        }
    }
}
