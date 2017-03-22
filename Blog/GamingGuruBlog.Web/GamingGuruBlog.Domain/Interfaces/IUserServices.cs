using GamingGuruBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingGuruBlog.Domain.Interfaces
{
    public interface IUserServices
    {
        User GetUser(string userID);
        void EditUser(User editedUser);
        List<User> GetAllUsers();
        List<Role> GetUserRoles();
    }
}
