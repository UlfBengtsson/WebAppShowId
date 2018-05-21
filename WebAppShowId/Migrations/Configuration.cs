namespace WebAppShowId.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebAppShowId.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAppShowId.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WebAppShowId.Models.ApplicationDbContext";
        }

        protected override void Seed(WebAppShowId.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }
            if (!roleManager.RoleExists("Normal"))
            {
                roleManager.Create(new IdentityRole("Normal"));
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (userManager.FindByEmail("admin@admin.se") == null)
            {
                ApplicationUser admin = new ApplicationUser()
                {
                    Email = "admin@admin.se",
                    UserName = "admin@admin.se"
                };
                userManager.Create(admin, "Qwe!23");
                userManager.AddToRole(userManager.FindByEmail("admin@admin.se").Id, "Admin");
            }

            if (userManager.FindByEmail("normal@normal.se") == null)
            {
                ApplicationUser normal = new ApplicationUser()
                {
                    Email = "normal@normal.se",
                    UserName = "normal@normal.se"
                };
                userManager.Create(normal, "Qwe!23");
                userManager.AddToRole(userManager.FindByEmail("normal@normal.se").Id, "Normal");
            }

            context.Hotels.AddOrUpdate(
                  h => h.Name,
                  new Hotel() { Name = "Thump", Stars = 1 },
                  new Hotel() { Name = "Grand", Stars = 5 }
               );
            context.SaveChanges();



        }
    }
}
