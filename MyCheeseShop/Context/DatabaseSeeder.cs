﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;

namespace MyCheeseShop.Context
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task Seed()
        {
            await _context.Database.MigrateAsync();

            if (!_context.Users.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));

                var adminEmail = "admin@cheese.com";
                var adminPassword = "Cheese123!";

                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                    Address = "123 Admin Street",
                    City = "Adminville",
                    PostCode = "AD12 MIN",
                };

                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRoleAsync(admin, "Admin");
            }

            if (!_context.Cheeses.Any())
            {
                var cheeses = GetCheeses();
                _context.Cheeses.AddRange(cheeses);
                await _context.SaveChangesAsync();
            }
        }
        private List<Cheese> GetCheeses()
        {
            // Create a list to store Cheese objects
            return
            [
                // Create 20 instances of Cheese using object initializers
                new Cheese { Name = "Cheddar", Type = "Hard", Description = "Sharp and tangy", Strength = "Medium", Price = 7.99m, ImageUrl="Cheddar.png"},
                new Cheese { Name = "Brie", Type = "Soft", Description = "Creamy and mild", Strength = "Mild", Price = 9.99m, ImageUrl="Brie.png" },
                new Cheese { Name = "Gouda", Type = "Semi-hard", Description = "Smooth and nutty", Strength = "Medium", Price = 8.49m, ImageUrl="Gouda.png" },
                new Cheese { Name = "Blue Cheese", Type = "Semi-soft", Description = "Pungent and creamy", Strength = "Strong", Price = 10.99m, ImageUrl="Blue Cheese.png" },
                new Cheese { Name = "Mozzarella", Type = "Soft", Description = "Mild and stringy", Strength = "Mild", Price = 6.99m, ImageUrl="Mozzarella.png" },
                new Cheese { Name = "Parmesan", Type = "Hard", Description = "Salty and granular", Strength = "Strong", Price = 12.99m, ImageUrl="Parmesan.png" },
                new Cheese { Name = "Gorgonzola", Type = "Semi-soft", Description = "Sharp and tangy with blue mold", Strength = "Strong", Price = 11.49m, ImageUrl="Gorgonzola.png" },
                new Cheese { Name = "Feta", Type = "Soft", Description = "Tangy and crumbly", Strength = "Medium", Price = 8.99m, ImageUrl="Feta.png" },
                new Cheese { Name = "Swiss", Type = "Hard", Description = "Nutty and sweet", Strength = "Medium", Price = 9.49m, ImageUrl="Swiss.png" },
                new Cheese { Name = "Provolone", Type = "Semi-hard", Description = "Sharp and savory", Strength = "Medium", Price = 8.99m, ImageUrl="Provolone.png" },
                new Cheese { Name = "Roquefort", Type = "Semi-soft", Description = "Sharp and tangy with blue mold", Strength = "Strong", Price = 13.99m, ImageUrl="Roquefort.png" },
                new Cheese { Name = "Camembert", Type = "Soft", Description = "Rich and creamy", Strength = "Mild", Price = 10.49m, ImageUrl="Camembert.png" },
                new Cheese { Name = "Manchego", Type = "Hard", Description = "Nutty and buttery", Strength = "Medium", Price = 11.99m, ImageUrl="Manchego.png" },
                new Cheese { Name = "Havarti", Type = "Semi-soft", Description = "Buttery and mild", Strength = "Mild", Price = 9.49m, ImageUrl="Havarti.png" },
                new Cheese { Name = "Colby", Type = "Semi-hard", Description = "Mild and creamy", Strength = "Mild", Price = 7.99m, ImageUrl="Colby.jfif" },
                new Cheese { Name = "Pepper Jack", Type = "Semi-soft", Description = "Mild with spicy peppers", Strength = "Medium", Price = 8.99m, ImageUrl="Pepper Jack.jfif" },
                new Cheese { Name = "Asiago", Type = "Hard", Description = "Sharp and nutty", Strength = "Medium", Price = 10.99m, ImageUrl="Asiago.jfif" },
                new Cheese { Name = "Monterey Jack", Type = "Semi-hard", Description = "Mild and creamy", Strength = "Mild", Price = 8.49m, ImageUrl="Monterey Jack.jfif" },
                new Cheese { Name = "Edam", Type = "Semi-hard", Description = "Mild and nutty", Strength = "Mild", Price = 8.99m, ImageUrl="Edam.jfif" },
                new Cheese { Name = "Ricotta", Type = "Soft", Description = "Creamy and slightly sweet", Strength = "Mild", Price = 7.49m, ImageUrl="Ricotta.jfif" },
            ];
        }


    }
}
