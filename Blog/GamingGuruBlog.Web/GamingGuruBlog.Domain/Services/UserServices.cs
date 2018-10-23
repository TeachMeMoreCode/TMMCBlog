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
        private readonly IUserRepository _userRepo;
        private readonly IRoleRepository _roleRepo;

        public UserServices(IUserRepository newUserRepo, IRoleRepository newRoleRepo)
        {
            _userRepo = newUserRepo;
            _roleRepo = newRoleRepo;
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
            var users = _userRepo.GetAllUsers();
            foreach (var user in users)
            {
                var userRole = _roleRepo.GetUserRole(user.ID);
                user.RoleId = userRole.RoleId;
            }           
            return users;
        }

        public List<Role> GetAllRoles()
        {
            return _roleRepo.AllRoles();
        }

        public void AddRoleToUser(string userId, string roleId)
        {
            _roleRepo.AddRoleToUser(userId, roleId);
        }
    }
}
