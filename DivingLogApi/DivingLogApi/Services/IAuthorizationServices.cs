using DivingLogApi.Models;
using System.Threading.Tasks;

namespace DivingLogApi.Services
{
    public interface IAuthorizationServices
    {
        Task<User> Login(string login, string password);
        Task<User> Register(User user, string password);
        Task<bool> UserExist(string login);
    }
}