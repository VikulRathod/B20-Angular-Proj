using edTechSpark.Core.Entities;
using edTechSpark.Models;

namespace edTechSpark.Services.Interfaces
{
    public interface IAuthService
    {
        bool CreateUser(User user, string Password);
        UserModel ValidateUser(string Username, string Password);
    }
}
