using Api.Model.Database;
using System.Threading.Tasks;

namespace Tourismus.WebApp._Infrastructure.Authentication {
    public interface IUserService {
        Task<User> AuthenticateAsync(string mail, string password);
        User Authorize();
    }
}
