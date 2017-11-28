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
                db.Activities.AddRange(GetActivities().ToArray());
                db.SaveChanges();
            }
            if (!db.Events.Any())
            {
                db.Events.AddRange(GetEvents(db).ToArray());
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

        public static List<Event> GetEvents(ApplicationDbContext context)
        {
            List<Event> events = new List<Event>()
            {
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Senior’s Golf Tournament"
                    },
                    StartDate = new DateTime(2017, 12, 22, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 22, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Leadership General Assembly Meeting"
                    },
                    StartDate = new DateTime(2017, 12, 24, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 24, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Youth Bowling Tournament"
                    },
                    StartDate = new DateTime(2017, 12, 14, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 14, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Young ladies cooking lessons"
                    },
                    StartDate = new DateTime(2017, 12, 16, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 16, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Youth craft lessons"
                    },
                    StartDate = new DateTime(2017, 12, 11, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 11, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Youth choir practice"
                    },
                    StartDate = new DateTime(2017, 12, 19, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 19, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Lunch Sunday"
                    },
                    StartDate = new DateTime(2017, 12, 21, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 21, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Pancake Breakfast"
                    },
                    StartDate = new DateTime(2017, 12, 17, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 17, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Swimming Lessons for the youth"
                    },
                    StartDate = new DateTime(2017, 12, 24, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 24, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Swimming Exercise for parents"
                    },
                    StartDate = new DateTime(2017, 12, 28, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 28, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Bingo Tournament"
                    },
                    StartDate = new DateTime(2017, 12, 10, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 10, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "BBQ Lunch"
                    },
                    StartDate = new DateTime(2017, 12, 3, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 3, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Garage Sale"
                    },
                    StartDate = new DateTime(2017, 12, 26, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 26, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Senior’s Golf Tournament"
                    },
                    StartDate = new DateTime(2017, 12, 22, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 22, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Leadership General Assembly Meeting"
                    },
                    StartDate = new DateTime(2017, 12, 24, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 24, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Youth Bowling Tournament"
                    },
                    StartDate = new DateTime(2017, 12, 14, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 14, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Young ladies cooking lessons"
                    },
                    StartDate = new DateTime(2017, 12, 16, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 16, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Youth craft lessons"
                    },
                    StartDate = new DateTime(2017, 12, 11, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 11, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Youth choir practice"
                    },
                    StartDate = new DateTime(2017, 12, 19, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 19, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Lunch Sunday"
                    },
                    StartDate = new DateTime(2017, 12, 21, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 21, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Pancake Breakfast"
                    },
                    StartDate = new DateTime(2017, 12, 17, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 17, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Swimming Lessons for the youth"
                    },
                    StartDate = new DateTime(2017, 12, 24, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 24, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Swimming Exercise for parents"
                    },
                    StartDate = new DateTime(2017, 12, 28, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 28, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Bingo Tournament"
                    },
                    StartDate = new DateTime(2017, 12, 10, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 10, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "BBQ Lunch"
                    },
                    StartDate = new DateTime(2017, 12, 3, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 3, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Garage Sale"
                    },
                    StartDate = new DateTime(2017, 12, 26, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 26, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Senior’s Golf Tournament"
                    },
                    StartDate = new DateTime(2017, 12, 26, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 26, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Leadership General Assembly Meeting"
                    },
                    StartDate = new DateTime(2017, 12, 6, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 6, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Youth Bowling Tournament"
                    },
                    StartDate = new DateTime(2017, 12, 25, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 25, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Young ladies cooking lessons"
                    },
                    StartDate = new DateTime(2017, 12, 20, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 20, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Youth craft lessons"
                    },
                    StartDate = new DateTime(2017, 12, 11, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 11, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Youth choir practice"
                    },
                    StartDate = new DateTime(2017, 12, 1, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 30, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Lunch Sunday"
                    },
                    StartDate = new DateTime(2017, 12, 19, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 19, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Pancake Breakfast"
                    },
                    StartDate = new DateTime(2017, 12, 1, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 1, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Swimming Lessons for the youth"
                    },
                    StartDate = new DateTime(2017, 12, 21, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 21, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Swimming Exercise for parents"
                    },
                    StartDate = new DateTime(2017, 12, 29, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 29, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Bingo Tournament"
                    },
                    StartDate = new DateTime(2017, 12, 16, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 16, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "BBQ Lunch"
                    },
                    StartDate = new DateTime(2017, 12, 22, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 22, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Garage Sale"
                    },
                    StartDate = new DateTime(2017, 12, 14, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 14, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Garage Sale"
                    },
                    StartDate = new DateTime(2017, 11, 30, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 30, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Senior’s Golf Tournament"
                    },
                    StartDate = new DateTime(2017, 11, 29, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 29, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Leadership General Assembly Meeting"
                    },
                    StartDate = new DateTime(2017, 11, 28, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 28, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Youth Bowling Tournament"
                    },
                    StartDate = new DateTime(2017, 11, 27, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 27, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Young ladies cooking lessons"
                    },
                    StartDate = new DateTime(2017, 11, 27, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 27, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Youth craft lessons"
                    },
                    StartDate = new DateTime(2017, 11, 28, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 28, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Youth choir practice"
                    },
                    StartDate = new DateTime(2017, 11, 29, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 29, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Lunch Sunday"
                    },
                    StartDate = new DateTime(2017, 11, 28, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 28, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Pancake Breakfast"
                    },
                    StartDate = new DateTime(2017, 11, 27, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 27, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Swimming Lessons for the youth"
                    },
                    StartDate = new DateTime(2017, 11, 28, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 28, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Swimming Exercise for parents"
                    },
                    StartDate = new DateTime(2017, 11, 28, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 28, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Bingo Tournament"
                    },
                    StartDate = new DateTime(2017, 11, 29, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 29, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "BBQ Lunch"
                    },
                    StartDate = new DateTime(2017, 11, 28, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 28, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Garage Sale"
                    },
                    StartDate = new DateTime(2017, 11, 27, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 27, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Senior’s Golf Tournament"
                    },
                    StartDate = new DateTime(2017, 11, 30, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 30, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Leadership General Assembly Meeting"
                    },
                    StartDate = new DateTime(2017, 11, 28, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 28, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Youth Bowling Tournament"
                    },
                    StartDate = new DateTime(2017, 11, 29, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 29, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Young ladies cooking lessons"
                    },
                    StartDate = new DateTime(2017, 11, 28, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 28, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Youth craft lessons"
                    },
                    StartDate = new DateTime(2017, 11, 30, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 30, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Youth choir practice"
                    },
                    StartDate = new DateTime(2017, 11, 28, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 28, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Lunch Sunday"
                    },
                    StartDate = new DateTime(2017, 11, 28, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 28, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Pancake Breakfast"
                    },
                    StartDate = new DateTime(2017, 11, 28, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 28, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Swimming Lessons for the youth"
                    },
                    StartDate = new DateTime(2017, 11, 29, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 29, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Swimming Exercise for parents"
                    },
                    StartDate = new DateTime(2017, 11, 27, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 27, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Bingo Tournament"
                    },
                    StartDate = new DateTime(2017, 11, 27, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 27, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "BBQ Lunch"
                    },
                    StartDate = new DateTime(2017, 11, 29, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 29, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Garage Sale"
                    },
                    StartDate = new DateTime(2017, 11, 30, 12, 00, 0),
                    EndDate = new DateTime(2017, 11, 30, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },


            };
            //context.SaveChanges();
            return events;
        }

        public static List<Activity> GetActivities()
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
