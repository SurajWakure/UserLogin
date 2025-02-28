using UserLogin.Models;

namespace UserLogin.Service
{
    public interface IUserService
    {
        UserModel Login(string username, string password);
    }
}
