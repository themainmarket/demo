using E_BookLibrary.Model;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using E_BookLibrary.Data.DataContext;

namespace E_BookLibrary.Data.PreSeederData
{
    public static class PreSeeder
    {
        public async static Task Seeder(UserManager<User> userMgr, RoleManager<IdentityRole> roleManager,AppDbContext ctx)
        {
            ctx.Database.EnsureCreated();

            var listOfRoles = new List<string> { "Admin", "Regular" };

            if (!roleManager.Roles.Any())
            {
               for(int i = 0; i < listOfRoles.Count; i++)
                {
                    var role = new IdentityRole(listOfRoles[i]);
                    await roleManager.CreateAsync(role);
                }
            }
           

            if (!ctx.Users.Any())
            {
                var userDataReader = new StreamReader("./Data/PreSeederData/UserData.json");
                var userData = await userDataReader.ReadToEndAsync();
                var userInfo = JsonConvert.DeserializeObject<IEnumerable<User>>(userData);

                int counter = 1;
                string userType;

                foreach (var user in userInfo)
                {
                    if (counter < 2)
                    {
                        userType = "Admin";
                       await  userMgr.CreateAsync(user, "P@@sword12");
                        await userMgr.AddToRoleAsync(user, userType);
                        counter += 1;
                    }

                    else
                    {
                        userType = "Regular";
                        await userMgr.CreateAsync(user, "P@@sword12");
                        await userMgr.AddToRoleAsync(user, userType);
                    }
                }
               
            }

            if (!ctx.CategoryTbl.Any())
            {
                var categoryDataReader = new StreamReader(@"./Data/PreSeederData/CategoryData.json");
                var categoryData = await categoryDataReader.ReadToEndAsync();
                var categoryInfo = JsonConvert.DeserializeObject<IEnumerable<Category>>(categoryData);

                foreach(var category in categoryInfo)
                {
                    await ctx.CategoryTbl.AddAsync(category);
                    await ctx.SaveChangesAsync();
                }

            }

            if (!ctx.BookTbl.Any())
            {
                var BookDataReader = new StreamReader(@"./Data/PreSeederData/BookData.json");
                var BookData = await BookDataReader.ReadToEndAsync();
                var BookInfo = JsonConvert.DeserializeObject<IEnumerable<Book>>(BookData);

                foreach (var book in BookInfo)
                {
                    await ctx.BookTbl.AddAsync(book);
                    await ctx.SaveChangesAsync();

                }

            }

            if (!ctx.ReviewTbl.Any())
            {
                var ReviewDataReader = new StreamReader(@"./Data/PreSeederData/ReviewData.json");
                var ReviewData = await ReviewDataReader.ReadToEndAsync();
                var ReviewInfo = JsonConvert.DeserializeObject<IEnumerable<Review>>(ReviewData);

                var books = ctx.BookTbl.ToList();
                var users = ctx.Users.ToList();
                

                foreach (var Review in ReviewInfo)
                {
                    foreach (var book in books)
                    {
                        Review.BookId = book.Id;
                    }

                    foreach (var user in users)
                    {
                        Review.UserId = user.Id;
                    }
                    await ctx.ReviewTbl.AddAsync(Review);
                    await ctx.SaveChangesAsync();

                }

            }

            if (!ctx.RatingTbl.Any())
            {
                var RatingReader = new StreamReader(@"./Data/PreSeederData/RatingData.json");
                var RatingData = await RatingReader.ReadToEndAsync();
                var RatingInfo = JsonConvert.DeserializeObject<IEnumerable<Rating>>(RatingData);

                var books = ctx.BookTbl.ToList();

                var users = ctx.Users.ToList();

                var count = 0;

                foreach (var Rating in RatingInfo)
                {
                    Rating.BookId = books[count].Id;
                    Rating.UserId = users[count].Id;

                    await ctx.RatingTbl.AddAsync(Rating);
                    await ctx.SaveChangesAsync();

                    count++;

                    if(count >= 8)
                    {
                        break;
                    }

                }

            }
        }
    }
}
