using EbaNews.Core.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;

namespace EbaNews.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userRole = new IdentityRole { Name = "user" };
            var adminRole = new IdentityRole { Name = "admin" };
            var ownerRole = new IdentityRole { Name = "owner" };
            var password = new PasswordHasher().HashPassword("qwerty");
            var admin = new ApplicationUser { Email = "email@email.com", UserName = "God", PasswordHash = password };

            var createdUserResult = userManager.Create(admin);
            roleManager.Create(userRole);
            roleManager.Create(adminRole);
            roleManager.Create(ownerRole);

            if (createdUserResult.Succeeded)
            {
                userManager.AddToRole(admin.Id, userRole.Name);
                userManager.AddToRole(admin.Id, adminRole.Name);
                userManager.AddToRole(admin.Id, ownerRole.Name);
            }
        }
    }
}
