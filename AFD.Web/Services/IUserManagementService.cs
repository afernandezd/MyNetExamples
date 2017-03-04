using System.ServiceModel;
using AFD.Model;

namespace AFD.Web.Services
{
    [ServiceContract]
    public interface IUserManagementService
    {
        [OperationContract]
        bool CreateUser(User user);
        [OperationContract]
        User FindUser(int id);
        [OperationContract]
        bool UpdateUser(User user);
        [OperationContract]
        bool DeleteUser(int id);
    }
}
