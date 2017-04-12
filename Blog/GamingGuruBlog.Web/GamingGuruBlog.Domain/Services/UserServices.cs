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
        private IRoleRepository _roleRepo;

        public UserServices(IUserRepository newUserRepo, IRoleRepository newUserRoleRepo)
        {
            _userRepo = newUserRepo;
            _roleRepo = newUserRoleRepo;
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

        public List<Role> GetUserRoles()
        {
            return _roleRepo.GetUserRoles();
        }

        public Role GetRole(int roleId)
        {
            return _roleRepo.GetRole(roleId);
        }

        public void EditUserRole(SetRoleID newRole)
        {
            _userRepo.EditUserRole(newRole);
        }
    }
}
