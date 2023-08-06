using Dunder_Mifflin_Paper_Company.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dunder_Mifflin_Paper_Company.Data
{
    public static class SeedIdentityData
    {
        private class SeedUser
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string Role { get; set; }
        }
        private static List<SeedUser> seedUsers = new List<SeedUser>
        {
            new SeedUser{ FirstName = "Robert", LastName="California", PhoneNumber = "0631157923", Role="CEO"},
            new SeedUser{ FirstName = "Michael", LastName="Scott", PhoneNumber = "0738361851", Role = "Manager"},
            new SeedUser{ FirstName = "Dwight", LastName="Schrute", PhoneNumber = "0631157923", Role = "Sales"},
            new SeedUser{ FirstName = "Jim", LastName="Halpert", PhoneNumber = "0681472368", Role = "Sales"},
            new SeedUser{ FirstName = "Pam", LastName="Beasley", PhoneNumber = "0782036914", Role = "Sales"},
            new SeedUser{ FirstName = "Stanley", LastName="Hudson", PhoneNumber = "0836541287", Role = "Sales"},
            new SeedUser{ FirstName = "Phyllis", LastName="Vance", PhoneNumber = "0817853691", Role = "Sales"},
            new SeedUser{ FirstName = "Andy", LastName="Bernard", PhoneNumber = "0658469632", Role = "Sales"},

            new SeedUser{ FirstName = "Larry", LastName="Meyers", PhoneNumber = "08695123357", Role = "Customer"},
            new SeedUser{ FirstName = "Barbara", LastName="Allen", PhoneNumber = "0879634852", Role = "Customer"},
            new SeedUser{ FirstName = "Aaron", LastName="Grandy", PhoneNumber = "0825963872", Role = "Customer"},
            new SeedUser{ FirstName = "Phil", LastName="Maguire", PhoneNumber = "0761285697", Role = "Customer"},
            new SeedUser{ FirstName = "Daniel", LastName="Schofield", PhoneNumber = "0671286355", Role = "Customer"},
            new SeedUser{ FirstName = "Jan", LastName="Levinson", PhoneNumber = "0852159638", Role = "Customer"},
            new SeedUser{ FirstName = "Roy", LastName="Anderson", PhoneNumber = "0154456412", Role = "Customer"},
        };

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<AppIdentityDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            string username, password;
            foreach(SeedUser user in seedUsers)
            {
                username = user.LastName.ToLower() + user.FirstName.Substring(0, 1).ToLower();
                password = $"@{user.LastName}";
                if (await userManager.FindByNameAsync(username) == null)
                {
                    if (await roleManager.FindByNameAsync(user.Role) == null)
                    {
                        await roleManager.CreateAsync(new IdentityRole(user.Role));
                    }

                    IdentityUser identityUser = new IdentityUser
                    {
                        UserName = username,
                        Email = $"{username}@gmail.com",
                        PhoneNumber = user.PhoneNumber
                    };

                    IdentityResult result = await userManager.CreateAsync(identityUser, password);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(identityUser, user.Role);
                    }
                }

            }
        }
    }
}
