using AFD.Model;
using AFD.Services.Implementation;

namespace AFD.Web.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly UserService _userService = new UserService();

        public bool CreateUser(User user)
        {
            return _userService.CreateUser(user) != null;
        }

        public User FindUser(int id)
        {
            return _userService.FindUser(id);
        }

        public bool UpdateUser(User user)
        {
            _userService.UpdateUser(user);
            return _userService.FindUser(user.Id) != null;
        }

        public bool DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return _userService.FindUser(id) != null;
        }
    }
}