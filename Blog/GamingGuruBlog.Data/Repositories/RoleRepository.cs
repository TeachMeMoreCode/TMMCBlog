using GamingGuruBlog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using GamingGuruBlog.Domain.Models;
using System.Data.SqlClient;
using Dapper;
namespace GamingGuruBlog.Data.Repositories
{
    class RoleRepository : IRole
    {
        public List<Role> AllRoles()
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                List<Role> allRoles = new List<Role>();
                allRoles = connection.Query<Role>("SELECT * FROM AspNetRoles").ToList();
            }
            return AllRoles();
        }
    }
}
