namespace ZenithSociety.Migrations.ClientMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZenithDataLib;
    using ZenithSociety.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithSociety.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ClientMigrations";
        }

        public void UserSeed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }
            if (!roleManager.RoleExists("Member"))
            {
                roleManager.Create(new IdentityRole("Member"));
            }
            var userManager = new UserManager<ApplicationUser>(new UserStore<Models.ApplicationUser>(context));
            if (userManager.FindByName("a@a.a") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "a@a.a",
                    UserName = "a"
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }
            if (userManager.FindByName("m@m.m") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "m@m.m",
                    UserName = "m"
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Member");
                }
            }
        }

        public List<Event> getEvents(ApplicationDbContext context)
        {
            List<Event> events = new List<Event>()
            {
                new Event()
                {
                    ActivityCategory = context.Activities.FirstOrDefault(a=> a.ActivityDescription.Equals("Senior’s Golf Tournament")).ActivityCategoryId,
                    StartDate = new DateTime(2017, 10, 17, 8, 30, 0),
                    EndDate = new DateTime(2017, 10, 17, 10, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    ActivityCategory = context.Activities.FirstOrDefault(a=> a.ActivityDescription.Equals("Leadership General Assembly Meeting")).ActivityCategoryId,
                    StartDate = new DateTime(2017, 10, 18, 8, 30, 0),
                    EndDate = new DateTime(2017, 10, 18, 10, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    ActivityCategory = context.Activities.FirstOrDefault(a=> a.ActivityDescription.Equals("Youth Bowling Tournament")).ActivityCategoryId,
                    StartDate = new DateTime(2017, 10, 20, 17, 30, 0),
                    EndDate = new DateTime(2017, 10, 20, 19, 15, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    ActivityCategory = context.Activities.FirstOrDefault(a=> a.ActivityDescription.Equals("Young ladies cooking lessons")).ActivityCategoryId,
                    StartDate = new DateTime(2017, 10, 20, 19, 00, 0),
                    EndDate = new DateTime(2017, 10, 20, 20, 00, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    ActivityCategory = context.Activities.FirstOrDefault(a=> a.ActivityDescription.Equals("Youth craft lessons")).ActivityCategoryId,
                    StartDate = new DateTime(2017, 10, 21, 8, 30, 0),
                    EndDate = new DateTime(2017, 10, 21, 10, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                   ActivityCategory = context.Activities.FirstOrDefault(a=> a.ActivityDescription.Equals("Youth choir practice")).ActivityCategoryId,
                    StartDate = new DateTime(2017, 10, 21, 10, 30, 0),
                    EndDate = new DateTime(2017, 10, 21, 12, 00, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                   ActivityCategory = context.Activities.FirstOrDefault(a=> a.ActivityDescription.Equals("Lunch")).ActivityCategoryId,
                    StartDate = new DateTime(2017, 10, 21, 12, 00, 0),
                    EndDate = new DateTime(2017, 10, 21, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    ActivityCategory = context.Activities.FirstOrDefault(a=> a.ActivityDescription.Equals("Pancake Breakfast")).ActivityCategoryId,
                    StartDate = new DateTime(2017, 10, 22, 7, 30, 0),
                    EndDate = new DateTime(2017, 10, 22, 8, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                   ActivityCategory = context.Activities.FirstOrDefault(a=> a.ActivityDescription.Equals("Swimming Lessons for the youth")).ActivityCategoryId,
                    StartDate = new DateTime(2017, 10, 22, 8, 30, 0),
                    EndDate = new DateTime(2017, 10, 22, 10, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    ActivityCategory = context.Activities.FirstOrDefault(a=> a.ActivityDescription.Equals("Swimming Exercise for parents")).ActivityCategoryId,
                    StartDate = new DateTime(2017, 10, 22, 8, 30, 0),
                    EndDate = new DateTime(2017, 10, 22, 10, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                   ActivityCategory = context.Activities.FirstOrDefault(a=> a.ActivityDescription.Equals("Bingo Tournament")).ActivityCategoryId,
                    StartDate = new DateTime(2017, 10, 22, 10, 30, 0),
                    EndDate = new DateTime(2017, 10, 22, 12, 00, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                   ActivityCategory = context.Activities.FirstOrDefault(a=> a.ActivityDescription.Equals("BBQ Lunch")).ActivityCategoryId,
                    StartDate = new DateTime(2017, 10, 22, 12, 00, 0),
                    EndDate = new DateTime(2017, 10, 22, 13, 00, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    ActivityCategory = context.Activities.FirstOrDefault(a=> a.ActivityDescription.Equals("Garage Sale")).ActivityCategoryId,
                    StartDate = new DateTime(2017, 10, 22, 13, 00, 0),
                    EndDate = new DateTime(2017, 10, 22, 18, 00, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },

            };
            context.SaveChanges();
            return events;
        }

        public List<Activity> getActivities()
        {
            List<Activity> activities = new List<Activity>()
            {

                new Activity()
                {
                    ActivityDescription = "Senior’s Golf Tournament"
                },
                
                new Activity()
                {
                    ActivityDescription = "Leadership General Assembly Meeting"
                },
                 
                new Activity()
                {
                    ActivityDescription = "Youth Bowling Tournament"
                },
                  
                new Activity()
                {
                    ActivityDescription = "Young ladies cooking lessons"
                },
             
                new Activity()
                {
                    ActivityDescription = "Youth craft lessons"
                },
                  
                new Activity()
                {
                    ActivityDescription = "Youth choir practice"
                },
                  
                new Activity()
                {
                    ActivityDescription = "Lunch"
                },
                  
                new Activity()
                {
                    ActivityDescription = "Pancake Breakfast"
                },
                
                
                new Activity()
                {
                    ActivityDescription = "Swimming Lessons for the youth"
                },
                  
                
                new Activity()
                {
                    ActivityDescription = "Swimming Exercise for parents"
                },
                  
                new Activity()
                {
                    ActivityDescription = "Bingo Tournament"
                },
                 
                new Activity()
                {
                    ActivityDescription = "BBQ Lunch"
                },
                 
                new Activity()
                {
                    ActivityDescription = "Garage Sale"
                }
                  
            };
            return activities;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            UserSeed(context);
            context.Activities.AddOrUpdate(
                a=> new { a.ActivityCategoryId },
                getActivities().ToArray()
                );
            context.SaveChanges();
            context.Events.AddOrUpdate(
                e => new { e.EventId },
                getEvents(context).ToArray()
            );
            context.SaveChanges();




        }
    }
}
