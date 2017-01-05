using GamingGuruBlog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using GamingGuruBlog.Domain.Models;
using System.Data.SqlClient;
using Dapper;

namespace GamingGuruBlog.Data.Repositories
{
    public class StaticPageRepository : IStaticPageRepository
    {
        public void AddStaticPage(StaticPage newStaticPage)
        {
            using(SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("UserId", newStaticPage.UserId);
                parameters.Add("Title", newStaticPage.Title);
                parameters.Add("Body", newStaticPage.Body);

                connection.Execute("Insert Into StaticPage (UserID,Title, Body) values (@UserId,@Title,@Body)",parameters);
            }
        }

        public void DeleteStaticPage(int id)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", id);

                connection.Execute("Delete from StaticPage where StaticPage.StaticPageID = @ID", parameters);
            }
        }
    

        public void EditStaticPage(StaticPage updatedStaticPage)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", updatedStaticPage.StaticPageId);
                parameters.Add("Title", updatedStaticPage.Title);
                parameters.Add("Body", updatedStaticPage.Body);
                connection.Execute("update StaticPage Set Title = @Title, Body = @Body  where StaticPageID = @ID",parameters);

            }
        }

        public List<StaticPage> GetAllStaticPages()
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                List<StaticPage> staticPages = connection.Query<StaticPage>("select * from StaticPage").ToList();

                return staticPages;
            }
        }

        public StaticPage GetStaticPage(int id)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", id);
                StaticPage staticPage = connection.Query<StaticPage>("select * from StaticPage where StaticPage.StaticPageID = @ID", parameters).SingleOrDefault();

                return staticPage;
            }
        }
    }
}
