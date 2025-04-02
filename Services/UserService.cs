using Microsoft.AspNetCore.Identity;
using WAD_WorkAndTravel.Models;

namespace WAD_WorkAndTravel.Services
{
    public class UserService
    {
        private readonly WAT_Context _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserService(WAT_Context context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        // Create user and hash the password
        public void CreateUser(string username, string password)
        {
            // Check if user already exists
            if (_context.Users.Any(u => u.username == username))
            {
                throw new Exception("User already exists!");
            }

            // Hash the password
            var user = new User
            {
                username = username,
                passwordHash = _passwordHasher.HashPassword(null, password)
            };

            // Add user to the database
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // Validate user credentials
        public bool ValidateUser(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.username == username);
            if (user == null) return false;

            var result = _passwordHasher.VerifyHashedPassword(user, user.passwordHash, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
