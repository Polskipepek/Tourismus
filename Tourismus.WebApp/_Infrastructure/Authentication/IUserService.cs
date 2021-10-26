using System.Threading.Tasks;
using Tourismus.Model.Models;

namespace Tourismus.WebApp._Infrastructure.Authentication {
    public interface IUserService {
        Task<User> AuthenticateAsync(string mail, string password);
        User Authorize();
    }
}
