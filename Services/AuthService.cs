using System.Linq;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using WAD_WorkAndTravel.Models;
using Microsoft.AspNetCore.Identity;

namespace WAD_WorkAndTravel.Services
{
    public class AuthService
    {
        private readonly WAT_Context _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthService(WAT_Context context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        public User AuthenticateUser(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.username == username);

            if (user == null)
                return null; // User not found

            var result = _passwordHasher.VerifyHashedPassword(user, user.passwordHash, password);

            return result == PasswordVerificationResult.Success ? user : null;
        }

        // Password hashing function (PBKDF2)
        public static string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32);

            return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
        }

        // Password verification function
        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            var parts = storedPassword.Split(':');
            if (parts.Length != 2) return false;

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] storedHash = Convert.FromBase64String(parts[1]);

            byte[] enteredHash = KeyDerivation.Pbkdf2(
                password: enteredPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32);

            return storedHash.SequenceEqual(enteredHash);
        }
    }
}
