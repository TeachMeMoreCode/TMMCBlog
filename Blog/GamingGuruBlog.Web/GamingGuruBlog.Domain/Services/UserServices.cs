using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingGuruBlog.Domain.Services
{
    public class UserServices : IUserServices
    {
        private IUserRepository _userRepo;

        public UserServices(IUserRepository newUserRepo)
        {
            _userRepo = newUserRepo;
        }

        public User GetUser(string userID)
        {
            return _userRepo.GetUser(userID);
        }

        public void EditUser(User editedUser)
        {
            _userRepo.EditUser(editedUser);
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

    }
}
