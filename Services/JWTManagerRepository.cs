

using CRUD.Common;
using CRUD.Interfaces;
using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private readonly EDMSContext _context;
        int UserId = 0;
        private readonly IConfiguration iconfiguration;
        public JWTManagerRepository(IConfiguration iconfiguration, EDMSContext context)
        {
            this.iconfiguration = iconfiguration;
            _context = context;
        }
        public Tokens Authenticate(AppUser users)
        {
            if (!_context.AppUser.Any(x => x.UserName == users.UserName && x.Password == users.Password))
            {
                return null;
            }

            var objUser = _context.AppUser.FirstOrDefault(x => x.UserName == users.UserName && x.Password == users.Password);
            // if not found will generate new token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
        new Claim("UserId", users.UserId.ToString())
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token), UserId = objUser != null ? objUser.UserId : 0 };

        }
    }
}
