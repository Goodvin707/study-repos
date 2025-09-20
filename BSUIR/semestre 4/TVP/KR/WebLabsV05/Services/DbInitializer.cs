using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using WebLabsV05.DAL.Entities;
using WebLabsV05.DAL.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace WebLabsV05.Services
{
    public class DbInitializer
    {        
        public static async Task Seed(ApplicationDbContext context, 
                                        UserManager<ApplicationUser> userManager,
                                        RoleManager<IdentityRole> roleManager)
        {    
            context.Database.EnsureCreated();

            // проверка наличия ролей
            if(!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin", NormalizedName = "admin"
                };
                // создать роль manager
                var result = await roleManager.CreateAsync(roleAdmin);                
            }

            // проверка наличия пользователей
            if(!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser { Email = "user@mail.ru", UserName= "user@mail.ru" };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser { Email = "admin@mail.ru", UserName= "admin@mail.ru" };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }
        }
    }
}
