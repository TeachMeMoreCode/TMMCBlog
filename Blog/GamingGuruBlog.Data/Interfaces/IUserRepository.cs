using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingGuruBlog.Data.Models;

namespace GamingGuruBlog.Data.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUser(string id);
        void EditUser(User editedUser);
    }
}
