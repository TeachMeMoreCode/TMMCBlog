using GamingGuruBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingGuruBlog.Domain.Interfaces
{
    public interface IRoleRepository
    {
        List<Role> AllRoles();
        UserRole GetUserRole(string userId);
        void AddRoleToUser(string userId, string roleId);
    }
}
