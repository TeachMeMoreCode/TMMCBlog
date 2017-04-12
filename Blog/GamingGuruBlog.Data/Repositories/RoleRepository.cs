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
        public List<Role> GetUserRoles()
        {
            List<Role> allRoles = new List<Role>();
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                allRoles = connection.Query<Role>("SELECT * FROM AspNetRoles").ToList();
            }
            return allRoles;
        }

        public Role GetRole(int roleId)
        {
            Role userRole = new Role();
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                userRole = connection.Query<Role>($"SELECT * FROM AspNetRoles WHERE id = {roleId}").SingleOrDefault();
            }
            return userRole;
        }
    }
}
