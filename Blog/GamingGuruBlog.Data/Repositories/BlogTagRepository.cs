using Dapper;
using GamingGuruBlog.Data.Interfaces;
using GamingGuruBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingGuruBlog.Data.Repositories
{
    public class BlogTagRepository : IBlogTagRepository
    {
        public void AddTagToBlog(int blogPostId, int tagId)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {

                var param = new DynamicParameters();

                param.Add("Tid", tagId);
                param.Add("Bid", blogPostId);

                connection.Execute("INSERT INTO BlogTag (TagID, BlogPostID) VALUES(@Tid, @Bid)", param);
            };
        }

        public void DeleteTagFromBlog(int blogPostId)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                var param = new DynamicParameters();
                param.Add("Bid", blogPostId);

                connection.Execute("Delete From BlogTag Where BlogPostID = @Bid", param);
            }
        }
        

    }

}
