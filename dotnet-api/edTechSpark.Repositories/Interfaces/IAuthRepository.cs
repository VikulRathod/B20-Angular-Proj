using edTechSpark.Core.Entities;
using edTechSpark.Models;

namespace edTechSpark.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        UserModel ValidateUser(string Email, string Password);
        bool CreateUser(User user, string Role);
    }
}
