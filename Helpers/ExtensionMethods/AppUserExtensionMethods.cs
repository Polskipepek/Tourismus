using Tourismus.Model.Models;

namespace Helpers.ExtensionMethods {
    public static class AppUserExtensionMethods {
        public static User WithoutSensitiveDataButToken(this User user) {
            return user == null ? null : new User {
                Id = user.Id,
                Token = user.Token,
                IsAdmin = user.IsAdmin,
                
            };
        }
    }
}
