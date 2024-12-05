using Microsoft.AspNetCore.Mvc;
using DatabaseAmusementParkProject.Data;
using DatabaseAmusementParkProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAmusementParkProject.Service
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public bool UserLogin(string username, string password)
        {
            var userLoginInfo = _context.Users.Where(u => u.UserName == username).FirstOrDefault();

            if (username == userLoginInfo.UserName && password == userLoginInfo.Password)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public async Task<User> CreateUserIfUniqueAsync(string username)
        {
            // Check if the username already exists in the database
            var existingUser = await _context.Users
                                             .Where(u => u.UserName == username)
                                             .FirstOrDefaultAsync();

            if (existingUser != null)
            {
                // If user exists, return the existing user
                return existingUser;
            }

            // If username is unique, create a new user
            var newUser = new User
            {
                Id = Guid.NewGuid(),  // Generate new UUID for user
                UserName = username,
                Password = GenerateRandomPassword()  // Generate a random password
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser; // Return the newly created user
        }

        // Helper method to generate a random password
        private string GenerateRandomPassword(int length = 12)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+[]{}|;:,.<>?";
            var random = new Random();
            var password = new StringBuilder();
            
            for (int i = 0; i < length; i++)
            {
                var index = random.Next(validChars.Length);
                password.Append(validChars[index]);
            }

            return password.ToString();
        }
    }
}
