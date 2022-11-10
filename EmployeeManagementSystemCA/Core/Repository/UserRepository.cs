using EmployeeManagementSystemCA.Core.IRepository;
using EmployeeManagementSystemCA.Data;
using EmployeeManagementSystemCA.DTO;
using EmployeeManagementSystemCA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace EmployeeManagementSystemCA.Core.Repository
{
    public class UserRepository:IUser
    {
        private readonly EmployeeDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public UserRepository(EmployeeDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<string> Login(UserLoginDto loginDto)
        {
            try
            {

                User user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email.Equals(loginDto.Email));
                if (user == null)
                {
                    return "1";
                }
                else if (!VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
                {
                    return "2";
                }
                else
                {
                    var token = CreateToken(user);
                    UserDetails(loginDto.Email);
                    return token;
                }

            }
            catch
            {
                return "error";
            }
        }

        public async Task<int> RegisterUser(UserRegisterDto registerDto)
        {
            try
            {

                var existingemail = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == registerDto.Email);
                if (existingemail == null)
                {
                    User user = new User();
                    CreatePasswordHash(registerDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                    user.FirstName = registerDto.FirstName;
                    user.Lastname = registerDto.Lastname;
                    user.Email = registerDto.Email;
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    if (user != null)
                    {
                        _dbContext.Users.Add(user);
                        _dbContext.SaveChanges();
                        return 1;

                    }
                    else
                    {
                        return 2;
                    }
                }
                else
                {
                    return 3;
                }
            }
            catch
            {
                return 4;
            }

        }

        public UserDetailsDto UserDetails(string email)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == email);
            UserDetailsDto userDetailsDto = new UserDetailsDto();
            userDetailsDto.emailId = user.Email;
            userDetailsDto.FirstName = user.FirstName;
            return userDetailsDto;
        }

        public bool VerifyPasswordHash(string password, byte[] passwordhash, byte[] passwordSalt)
        {
            try
            {
                using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
                {
                    var computehash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    for (int i = 0; i < computehash.Length; i++)
                    {
                        if (computehash[i] != passwordhash[i])
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            catch
            {
                throw;
            }
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            try
            {
                using (var hmac = new System.Security.Cryptography.HMACSHA512())
                {
                    passwordSalt = hmac.Key;
                    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                }
            }
            catch
            {
                throw;
            }
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Email, user.Email)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value.ToString()));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(10),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
