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
                List<User> allUsers = connection.Query<User>("select * from AspNetUsers").ToList();

                foreach (var user in allUsers)
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("UserID", user.ID);
                    user.Role = connection.Query<Role>("SELECT Id, Name FROM AspNetRoles AS roles JOIN AspNetUserRoles AS userRole ON roles.Id = userRole.RoleId WHERE userRole.UserId = @UserID", parameter).SingleOrDefault();
                }


                return allUsers;
            }
        }

        public User GetUser(string id)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                //TODO: try-catch
                var parameters = new DynamicParameters();
                parameters.Add("@ID", id);
                User singleUser = connection.Query<User>("select * from AspNetUsers where ID = @ID",parameters).SingleOrDefault();
                parameters.Add("UserID", singleUser.ID);
                singleUser.Role = connection.Query<Role>("SELECT Id, Name FROM AspNetRoles AS roles JOIN AspNetUserRoles AS userRole ON roles.Id = userRole.RoleId WHERE userRole.UserId = @UserID", parameters).SingleOrDefault();
            
                return singleUser;
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

        public void EditUserRole(SetRoleID editedUserRole)
        {
            //TODO try-catch
            var parameters = new DynamicParameters();
            parameters.Add("UserID", editedUserRole.UserId);
            parameters.Add("RoleID", editedUserRole.RoleId);
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                connection.Execute("UPDATE AspNetUserRoles SET RoleId = @RoleID WHERE UserId = @UserID", parameters);
            }
        }

    }
}
