using GamingGuruBlog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using GamingGuruBlog.Domain.Models;
using System.Data.SqlClient;
using Dapper;
namespace GamingGuruBlog.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public List<Role> AllRoles()
        {
            List<Role> allRoles = new List<Role>();

            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                allRoles = connection.Query<Role>("SELECT Id, AspNetRoles.Name FROM AspNetRoles").ToList();
            }
            return allRoles;
        }

        public UserRole GetUserRole(string userId)
        {
            string sql = "SELECT UserId, RoleId FROM AspNetUserRoles WHERE UserId = @UserId";
            UserRole userRole;
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                userRole = connection.Query<UserRole>(sql, new { UserId = userId}).FirstOrDefault();
            }
            return userRole;
        }

        public void AddRoleToUser(string userId, string roleId)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                var sql = "INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES (@UserId, @RoleId);";
                var parameters = new DynamicParameters();
                parameters.Add("UserId", userId);
                parameters.Add("RoleId", roleId);

                connection.Execute(sql, parameters);
            }
        }
    }
}
