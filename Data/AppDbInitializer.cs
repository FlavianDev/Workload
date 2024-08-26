using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkloadApp.Data.Static;
using WorkloadApp.Models;

namespace WorkloadApp.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                if (!context.Cities.Any())
                {
                    context.Cities.AddRange(new List<City>()
                    {
                        new City()
                        {
                            CityName = "Alba"
                        },
                        new City()
                        {
                            CityName = "Arad"
                        },
                        new City()
                        {
                            CityName = "Arges"
                        },
                        new City()
                        {
                            CityName = "Bacau"
                        },
                        new City()
                        {
                            CityName = "Bihor"
                        },
                        new City()
                        {
                            CityName = "Bistrita-Nasaud"
                        },
                        new City()
                        {
                            CityName = "Botosani"
                        },
                        new City()
                        {
                            CityName = "Brasov"
                        },
                        new City()
                        {
                            CityName = "Braila"
                        },
                        new City()
                        {
                            CityName = "Bucuresti"
                        },
                        new City()
                        {
                            CityName = "Buzau"
                        },
                        new City()
                        {
                            CityName = "Caras-Severin"
                        },
                        new City()
                        {
                            CityName = "Cluj"
                        },
                        new City()
                        {
                            CityName = "Constanta"
                        },
                        new City()
                        {
                            CityName = "Covasna"
                        },
                        new City()
                        {
                            CityName = "Calarasi"
                        },
                        new City()
                        {
                            CityName = "Dolj"
                        },
                        new City()
                        {
                            CityName = "Dambovita"
                        },
                        new City()
                        {
                            CityName = "Galati"
                        },
                        new City()
                        {
                            CityName = "Giurgiu"
                        },
                        new City()
                        {
                            CityName = "Gorj"
                        },
                        new City()
                        {
                            CityName = "Harghita"
                        },
                        new City()
                        {
                            CityName = "Hunedoara"
                        },
                        new City()
                        {
                            CityName = "Ialomita"
                        },
                        new City()
                        {
                            CityName = "Iasi"
                        },
                        new City()
                        {
                            CityName = "Ilfov"
                        },
                        new City()
                        {
                            CityName = "Maramures"
                        },
                        new City()
                        {
                            CityName = "Mehedinti"
                        },
                        new City()
                        {
                            CityName = "Mures"
                        },
                        new City()
                        {
                            CityName = "Neamt"
                        },
                        new City()
                        {
                            CityName = "Olt"
                        },
                        new City()
                        {
                            CityName = "Prahova"
                        },
                        new City()
                        {
                            CityName = "Satu Mare"
                        },
                        new City()
                        {
                            CityName = "Sibiu"
                        },
                        new City()
                        {
                            CityName = "Suceava"
                        },
                        new City()
                        {
                            CityName = "Salaj"
                        },
                        new City()
                        {
                            CityName = "Teleorman"
                        },
                        new City()
                        {
                            CityName = "Timis"
                        },
                        new City()
                        {
                            CityName = "Tulcea"
                        },
                        new City()
                        {
                            CityName = "Vaslui"
                        },
                        new City()
                        {
                            CityName = "Vrancea"
                        },
                        new City()
                        {
                            CityName = "Valcea"
                        }
                    });
                    context.SaveChanges();
                }
                /*if (!context.Users.Any())
                {
                    context.Users.AddRange(new List<User>()
                    {
                        new User()
                        {
                            UserId = "0",
                            UserEmail = "test@email.com",
                            PassHash = "1234"
                        },
                        new User()
                        {
                            UserId = "1",
                            UserEmail = "test1@email.com",
                            PassHash = "1234"
                        },
                        new User()
                        {
                            UserId = "2",
                            UserEmail = "test2@email.com",
                            PassHash = "1234"
                        }
                    });
                    context.SaveChanges();
                }*/
                /*if (!context.Freelancers.Any())
                {
                    context.Freelancers.AddRange(new List<Freelancer>()
                    {
                        new Freelancer()
                        {
                            FreelancerName = "Freelancer 1",
                            FreelancerBio= "Test description for freelancer"
                        },
                        new Freelancer()
                        {
                            FreelancerName = "Freelancer 2",
                            FreelancerBio= "Test description for freelancer"
                        }
                    });
                    context.SaveChanges();
                }*/
                /*if (!context.Services.Any())
                {
                    context.Services.AddRange(new List<Service>()
                    {
                        new Service()
                        {
                            FreelancerId = 2,
                            ServicePicURL = "",
                            ServiceName = "Service 1",
                            ServiceDescription = "Test description for service"
                        },
                        new Service()
                        {
                            FreelancerId = 2,
                            ServicePicURL = "",
                            ServiceName = "Service 2",
                            ServiceDescription = "Test description for service"
                        }
                    });
                    context.SaveChanges();
                }*/
                /*if (!context.Cities_Services.Any())
                {
                    context.Cities_Services.AddRange(new List<City_Service>()
                    {
                        new City_Service()
                        {
                            CityId = 1,
                            ServiceId = 1
                        },
                        new City_Service()
                        {
                            CityId = 2,
                            ServiceId = 2
                        },
                        new City_Service()
                        {
                            CityId = 2,
                            ServiceId = 1
                        }
                    });
                    context.SaveChanges();
                }*/
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }

                if (!await roleManager.RoleExistsAsync(UserRoles.Freelancer))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Freelancer));
                }

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminEmail = "admin@workload.com";
                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                if (adminUser == null)
                {
                    var newAdmin = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin",
                        Email = adminEmail,
                        EmailConfirmed = true
                    };
                    var result = await userManager.CreateAsync(newAdmin, "Coding@1234?");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(newAdmin, UserRoles.Admin);
                    }
                }

                string userEmail = "testuser@workload.com";
                var testUser = await userManager.FindByEmailAsync(userEmail);
                if (testUser == null)
                {
                    var newUser = new ApplicationUser()
                    {
                        FullName = "Test User",
                        UserName = "testuser",
                        Email = userEmail,
                        EmailConfirmed = true
                    };
                    var result = await userManager.CreateAsync(newUser, "Coding@5678?");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(newUser, UserRoles.User);
                    }
                }
            }
        }
    }
}
