using Akmit.BusinessLogic.Interfaces;
using Akmit.BusinessLogic.Models;
using Akmit.DataAccess.Interfaces;
using Akmit.DataAccess.Models;
using Akmit.Shared.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.BusinessLogic.Services
{
    public class ClassService : IClassService
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public ClassService(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ClassInformationBlo> Create(string token, ClassInformationBlo classInformationBlo)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(h => h.Token == token);

            if (user == null) throw new BadRequest("Пользователя с таким токеном нет");

            ClassRto newClass = new ClassRto()
            {
                Title = classInformationBlo.Title,
                SecretCode = new Random().Next(100, 1000)
            };

            _context.Classes.Add(newClass);
            await _context.SaveChangesAsync();

            return _mapper.Map<ClassInformationBlo>(newClass);
        }

        public async Task<bool> Join(string token, ClassInformationBlo classInformationBlo)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(h => h.Token == token);

            if (user == null) throw new BadRequest("Пользователя с таким токеном нет");

            ClassRto fClass = await _context.Classes.FirstOrDefaultAsync(h => h.Title == classInformationBlo.Title &&
                h.SecretCode == classInformationBlo.SecretCode);

            if (fClass == null) throw new BadRequest("Такого класса нет");

            user.ClassRtoId = fClass.Id;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Leave(string token)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(h => h.Token == token);

            if (user == null) throw new BadRequest("Пользователя с таким токеном нет");

            if (user.ClassRtoId == 0) return false;

            user.ClassRtoId = 0;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<int> RefreshCode(string token)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(h => h.Token == token);

            if (user == null) throw new BadRequest("Пользователя с таким токеном нет");

            ClassRto fClass = await _context.Classes.FirstOrDefaultAsync(h => h.Id == user.ClassRtoId);

            if (fClass == null) throw new BadRequest("Этот пользователь не состоит в классе");

            fClass.SecretCode = new Random().Next(100, 1000);

            _context.Classes.Update(fClass);
            await _context.SaveChangesAsync();

            return fClass.SecretCode;
        }
    }
}
