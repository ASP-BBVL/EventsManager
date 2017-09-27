namespace ZenithSociety.Migrations.ClientMigrations
{
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using ZenithSociety.Models;

	internal sealed class Configuration : DbMigrationsConfiguration<ZenithSociety.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ClientMigrations";
        }

        protected override void Seed(ApplicationDbContext context)
        {
			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if(!roleManager.RoleExists("Admin"))
			{
				roleManager.Create(new IdentityRole("Admin"));
			}
			if (!roleManager.RoleExists("Guest"))
			{
				roleManager.Create(new IdentityRole("Guest"));
			}
			var userManager = new UserManager<ApplicationUser>(new UserStore<Models.ApplicationUser>(context)); 
			if(userManager.FindByName("a@a.a") == null )
			{
				var user = new ApplicationUser
				{
					Email = "a@a.a",
					UserName = "a@a.a"
				};
			
			}
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
		}
    }
}
