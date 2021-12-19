using Autofac;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tourismus.FakeData.FakeSeeds;
using Tourismus.Model.Models;
using Tourismus.WebApp.Configuration.Modules;
using Tourismus.WebApp.Configuration.Modules.Authentication;
using Tourismus.WebApp.Configuration.Modules.OData;

namespace Tourismus {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddControllersWithViews();
            services.AddOData();
            services.ConfigureAddAuthentication();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddMvc(option => {
                option.CacheProfiles.Add("NoCaching", new CacheProfile() {
                    NoStore = true,
                    Location = ResponseCacheLocation.None
                });
            });
        }
        public void ConfigureContainer(ContainerBuilder builder) {
            ModuleRegistrator.RegisterAllModules(builder);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                endpoints.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
                endpoints.MapODataRoute("odata", "odata", EdmModelBuilder.GetModel());
            });

            app.UseSpa(spa => {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment()) {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()) {
                var context = serviceScope.ServiceProvider.GetRequiredService<TourismusDbContext>();
                if (context.Database.GetService<IRelationalDatabaseCreator>().HasTables() == false) {
                    context.Database.Migrate();
                    new TourismusDbSeeder().SeedFakeData(context);
                }
            }

           
        }
    }
}
