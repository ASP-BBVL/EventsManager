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
			if (!roleManager.RoleExists("Member"))
			{
				roleManager.Create(new IdentityRole("Member"));
			}
			var userManager = new UserManager<ApplicationUser>(new UserStore<Models.ApplicationUser>(context)); 
			if(userManager.FindByName("a@a.a") == null )
			{
				var user = new ApplicationUser
				{
					Email = "a@a.a",
					UserName = "a@a.a"
				};
				var result = userManager.Create(user, "P@$$w0rd");
				if(result.Succeeded)
				{
					userManager.AddToRole("Admin");
				}
			}
			if (userManager.FindByName("m@m.m") == null)
			{
				var user = new ApplicationUser
				{
					Email = "m@m.m",
					UserName = "m@m.m"
				};
				var result = userManager.Create(user, "P@$$w0rd");
				if (result.Succeeded)
				{
					userManager.AddToRole("Member");
				}
			}
		}
    }
}
