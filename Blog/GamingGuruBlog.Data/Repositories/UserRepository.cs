using GamingGuruBlog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using GamingGuruBlog.Domain.Models;
using System.Data.SqlClient;
using Dapper;

namespace GamingGuruBlog.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> GetAllUsers()
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                List<User> user = connection.Query<User>("select * from AspNetUsers").ToList();

                return user;
            }
        }

        public User GetUser(string id)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                //TODO: try-catch
                var parameters = new DynamicParameters();
                parameters.Add("@ID", id);
                User user = connection.Query<User>("select * from AspNetUsers where ID = @ID",parameters).SingleOrDefault();

                return user;
            }
        }

        public void EditUser(User editedUser)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                //TODO: try-catch
                var parameters = new DynamicParameters();
                parameters.Add("UserID", editedUser.ID);
                parameters.Add("FirstName", editedUser.FirstName);
                parameters.Add("LastName", editedUser.LastName);

                connection.Execute("Update AspNetUsers SET FirstName = @FirstName, LastName =@LastName Where ID = @UserID", parameters);

            }
        }
       
    }
}
