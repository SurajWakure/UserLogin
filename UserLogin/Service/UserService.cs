using UserLogin.Models;
using UserLogin.Reposetory;

namespace UserLogin.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel Login(string username, string password)
        {
            return _userRepository.ValidateUser(username, password);
        }
    }
}
