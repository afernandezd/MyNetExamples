using System.Collections.Generic;
using AFD.Model;

namespace AFD.Services.Interface
{
    public interface IUserService
    {
        User CreateUser(User newUser);
        List<User> ReadUsers();
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}