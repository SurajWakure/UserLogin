using UserLogin.Models;

namespace UserLogin.Reposetory
{
    public interface IUserRepository
    {
        UserModel ValidateUser(string username, string password);
    }
}
