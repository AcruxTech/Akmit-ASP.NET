using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Akmit.BusinessLogic.Interfaces;
using Akmit.BusinessLogic.Models;
using Akmit.DataAccess.Interfaces;
using Akmit.DataAccess.Models;
using Akmit.Shared.Configurations;
using Akmit.Shared.Exceptions;
using Akmit.Shared.Roles;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Akmit.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public UserService(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> Register(UserIdentityBlo userIdentityBlo)
        {
            if (await IsExist(userIdentityBlo.Email, userIdentityBlo.Login))
                throw new BadRequest("Пользователь с такими данными уже существует");

            string token = GenerateToken(userIdentityBlo.Login, Roles.User);
            UserRto user = new UserRto()
            {
                Login = userIdentityBlo.Login,
                Email = userIdentityBlo.Email,
                Password = userIdentityBlo.Password,
                Role = Roles.User,
                Token = token,
                ClassRtoId = null
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return token;
        }

        public async Task<string> Auth(UserIdentityBlo userIdentityBlo)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(h => h.Login == userIdentityBlo.Login && 
                h.Password == userIdentityBlo.Password);

            if (user == null)
                throw new BadRequest("Пользователя с такими данными не существует");

            return GenerateToken(user.Login, user.Role);
        }

        public Task<bool> IsExist(string email, string login)
        {
            return _context.Users.AnyAsync(h => h.Login == login || h.Email == email);
        }

        public async Task<UserInformationBlo> GetByToken(string token)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(h => h.Token == token);

            if (user == null) throw new NotFound("Пользователя с таким токеном нет");

            return _mapper.Map<UserInformationBlo>(user);
        }

        public async Task<UserInformationShortBlo> GetById(int id)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(h => h.Id == id);

            if (user == null) throw new NotFound("Пользователя с таким id нет");

            return _mapper.Map<UserInformationShortBlo>(user);
        }

        public async Task<UserInformationBlo> Change(string token, UserUpdateBlo userUpdateBlo)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(h => h.Token == token);

            if (user == null) throw new NotFound("Пользователя с таким токеном нет");

            user.Login = userUpdateBlo.Login;
            user.Email = userUpdateBlo.Email;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserInformationBlo>(user);
        }

        public async Task<UserInformationBlo> ChangePass(string token, string pass, string newPass)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(h => h.Token == token && h.Password == pass);

            if (user == null) throw new NotFound("Пользователя с таким токеном нет");

            user.Password = newPass;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserInformationBlo>(user);
        }

        public async Task<bool> Delete(string token)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(h => h.Token == token);

            if (user == null) throw new NotFound("Пользователя с таким токеном нет");

            user.Role = Roles.Deleted;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }
           
        private string GenerateToken(string login, string role)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
                };

            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claimsIdentity.Claims,
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}
