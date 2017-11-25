using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ZenithWebsite.Models;

namespace ZenithWebsite.Data
{
    public class DummyData
    {

        public static void Initialize(ApplicationDbContext db, IServiceProvider services)
        {
            IServiceScopeFactory scopeFactory = services.GetRequiredService<IServiceScopeFactory>();

            using (IServiceScope scope = scopeFactory.CreateScope())
            {
                RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                UserManager<ApplicationUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                UserSeedAsync(db, roleManager, userManager);
            }
            if (!db.Activities.Any())
            {
                db.Activities.AddRange(getActivities().ToArray());
                db.SaveChanges();
            }
            if (!db.Events.Any())
            {
                db.Events.AddRange(getEvents(db).ToArray());
                db.SaveChanges();
            }
        }

        public static async void UserSeedAsync(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            var isAdminRoleExist = await roleManager.RoleExistsAsync("Admin");
            var isMemberRoleExist = await roleManager.RoleExistsAsync("Member");
            if (!isAdminRoleExist)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!isMemberRoleExist)
            {
                await roleManager.CreateAsync(new IdentityRole("Member"));
            }
            if (await userManager.FindByNameAsync("a") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "a@a.a",
                    UserName = "a"
                };
                var result = await userManager.CreateAsync(user, "P@$$w0rd");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
            if (await userManager.FindByNameAsync("m") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "m@m.m",
                    UserName = "m"
                };
                var result = await userManager.CreateAsync(user, "P@$$w0rd");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Member");
                }
            }
        }

        public static List<Event> getEvents(ApplicationDbContext context)
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

        public static List<Activity> getActivities()
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
    }
}
