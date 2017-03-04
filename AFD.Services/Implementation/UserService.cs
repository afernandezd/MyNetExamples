using System.Collections.Generic;
using AFD.Data.EntityFramework;
using AFD.Model;
using AFD.Services.Interface;

namespace AFD.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UsersDao _userDao = new UsersDao();

        public UserService(UsersDao userDao)
        {
            _userDao = userDao;
        }

        public UserService()
        {
        }

        public User CreateUser(User newUser)
        {
            return _userDao.CreateUser(newUser);
        }

        public List<User> ReadUsers()
        {
            return _userDao.GetAllUsers();
        }

        public User FindUser(int id)
        {
            return _userDao.FindUser(id);
        }

        public void UpdateUser(User user)
        {
            _userDao.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            _userDao.DeleteUser(id);
        }
    }
}