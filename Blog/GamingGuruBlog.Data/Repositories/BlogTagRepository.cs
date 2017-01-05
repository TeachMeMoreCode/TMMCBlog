using Dapper;
using GamingGuruBlog.Domain.Interfaces;
using System.Data.SqlClient;

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
