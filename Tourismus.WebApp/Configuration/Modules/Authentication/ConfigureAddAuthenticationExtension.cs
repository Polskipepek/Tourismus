using Helpers.Constants;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

namespace Tourismus.WebApp.Configuration.Modules.Authentication {
    public static class ConfigureAddAuthenticationExtension {
        public const string AuthCookieName = "auth_Tourismus";
        public static void ConfigureAddAuthentication(this IServiceCollection services) {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.Cookie.Name = AuthCookieName;
                    options.Events.OnRedirectToLogin = async context => {
                        context.Response.Headers.Remove("Location");
                        context.Response.StatusCode = CookieAuthenticationConst.UnauthorizedStatusCode;

                        byte[] data = Encoding.UTF8.GetBytes(CookieAuthenticationConst.UnauthorizedResponseBody);
                        context.Response.ContentType = CookieAuthenticationConst.UnauthorizedResponseContentType;
                        await context.Response.Body.WriteAsync(data.AsMemory(0, data.Length));
                    };
                });
        }
    }
}
