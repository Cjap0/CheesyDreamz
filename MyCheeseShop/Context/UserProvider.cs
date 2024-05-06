﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;

namespace MyCheeseShop.Context
{
    public class UserProvider
    {
        private readonly DatabaseContext _context;
        public User? GetUserByUsername(string? username)
        {
            // Return the user with the specified username
            return _context.Users.FirstOrDefault(User => User.UserName == username);
        }
    }
}
