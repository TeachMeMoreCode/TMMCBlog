using System.Collections.Generic;
using GamingGuruBlog.Domain.Models;

namespace GamingGuruBlog.Data.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUser(string id);
        void EditUser(User editedUser);
    }
}
