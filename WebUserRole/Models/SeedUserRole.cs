using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace WebUserRole.Models
{

    public static class SeedUserRole
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
        {
            //initializing custom roles 
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            // var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { "Admin", "Manager", "Member" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 1
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            // var tst= Configuration.GetSection("AppSettings")["UserSettings:UserName"];
            //tst = Configuration["UserSettings:UserName"];
            //Here you could create a super user who will maintain the web app
            var poweruser = new IdentityUser
            {
                // UserName = Configuration.GetSection("AppSettings")["UserSettings:UserName"],
                // Email = Configuration.GetSection("AppSettings")["UserSettings:UserEmail"],
                UserName = Configuration["UserSettings:UserName"],
                Email = Configuration["UserSettings:UserEmail"],
            };

            //Ensure you have these values in your appsettings.json file
            string userPWD = Configuration["UserSettings:UserPassword"];
            var _user = await UserManager.FindByEmailAsync(Configuration["UserSettings:UserEmail"]);

            if (_user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPWD);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the role
                    await UserManager.AddToRoleAsync(poweruser, "Admin");
                }
            }
        }
    }

}
