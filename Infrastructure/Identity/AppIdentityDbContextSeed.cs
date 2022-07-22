using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async  Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName="Ahmed Amin",
                    Email="Ahmed@Amin.com",
                    UserName= "Ahmed@Amin.com",
                    Address = new List<Address>()
                    {
                         new Address()
                {
                    FirstName = "Naser",
                    LastName = "city",
                    Street = "9 st Amin Rehany",
                    State = "Cairo",
                    ZipCode = "71236"

                }
            }


                };

               

                await userManager.CreateAsync(user, "123Pa$$word!");
            }
        }
    }
}
