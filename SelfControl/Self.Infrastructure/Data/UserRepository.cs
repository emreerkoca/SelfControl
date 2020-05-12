using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Self.Core.Entities;
using Self.Core.Interfaces;
using Self.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Self.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly AppSettings _appSettings;

        public UserRepository(AppDbContext appDbContext, IOptions<AppSettings> appSettings)
        {
            _appDbContext = appDbContext;
            _appSettings = appSettings.Value;
        }

        public User AddNewUser(User user)
        {
            var existingUsers = _appDbContext.User.FirstOrDefault(x => x.EMail == user.EMail);

            if (existingUsers != null)
            {
                return null;
            }

            AuthenticationData authenticationData = new AuthenticationData();

            authenticationData = GeneratePassword(user.Password);

            user.Salt = authenticationData.Salt;
            user.Password = authenticationData.HashedPassword;

            _appDbContext.User.Add(user);

            return user;
        }

        public User Authenticate(string username, string password)
        {
            var userForSalt = _appDbContext.User.FirstOrDefault(x => x.EMail == username);

            if (userForSalt == null)
            {
                return null;
            }

            //var salt = _appDbContext.User.FirstOrDefault(x => x.EMail == username);
            var hashedPassword = GetSaltedAndHashedPassword(userForSalt.Salt, password);
            var user = _appDbContext.User.SingleOrDefault(x => x.EMail == username && x.Password == hashedPassword);

            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            user.Token = tokenHandler.WriteToken(token);
            user.Password = null;

            return user;
        }

        private AuthenticationData GeneratePassword(string password)
        {
            AuthenticationData authenticationData = new AuthenticationData();
            byte[] salt = new byte[128 / 8];

            using (var rndNumberGenerator = RandomNumberGenerator.Create())
            {
                rndNumberGenerator.GetBytes(salt);
            }

            string hashedPassword = GenerateHashedPassword(salt, password);

            authenticationData.HashedPassword = hashedPassword;
            authenticationData.Salt = Convert.ToBase64String(salt);

            return authenticationData;
        }

        private string GenerateHashedPassword(byte[] salt, string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }

        private string GetSaltedAndHashedPassword(string salt, string password)
        {
            return GenerateHashedPassword(Convert.FromBase64String(salt), password);
        }
    }
}
