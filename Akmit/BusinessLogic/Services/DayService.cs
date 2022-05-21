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
    public class DayService : IDayService
    {
        private readonly IAkmitContext _context;
        private readonly IMapper _mapper;

        public DayService(IAkmitContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Add(string token, string title, string pavilion)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(h => h.Token == token);

            if (user == null || user.ClassRtoId == 0) throw new BadRequest("Пользователя с таким токеном нет");

            ClassRto fClass = await _context.Classes.FirstOrDefaultAsync(h => h.Id == user.ClassRtoId);

            if (fClass == null) throw new BadRequest("Пользователь не состоит в классе");

            DayRto day = new DayRto()
            {
                Title = title,
                Pavilion = pavilion,
                ClassRtoId = fClass.Id
            };

            _context.Days.Add(day);
            await _context.SaveChangesAsync();  

            return true;
        }

        public async Task<bool> Delete(string token, string title)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(h => h.Token == token);

            if (user == null || user.ClassRtoId == 0) throw new BadRequest("Пользователя с таким токеном нет");

            ClassRto fClass = await _context.Classes.FirstOrDefaultAsync(h => h.Id == user.ClassRtoId);

            if (fClass == null) throw new BadRequest("Пользователь не состоит в классе");

            DayRto day = await _context.Days.FirstOrDefaultAsync(h => h.Id == user.ClassRtoId && h.Title == title);

            _context.Days.Remove(day);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<DayInformationBlo>> GetAll(string token)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(h => h.Token == token);
            if (user == null) throw new BadRequest("Пользователя с таким токеном нет");

            ClassRto fClass = await _context.Classes.FirstOrDefaultAsync(h => h.Id == user.ClassRtoId);
            if (fClass == null) throw new BadRequest("Пользователь не состоит в классе");

            List<DayRto> daysRto = await _context.Days.Where(h => h.ClassRtoId == fClass.Id).ToListAsync();
            if (daysRto.Count == 0) throw new NotFound("Дней нет");

            List<DayInformationBlo> days = new List<DayInformationBlo>();
            for (int i = 0; i < daysRto.Count; i++)
            {
                days.Append(_mapper.Map<DayInformationBlo>(daysRto[i]));
            }

            return days;
        }

        public async Task<bool> Update(string token, string title, string newTitle, string newPavilion)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(h => h.Token == token);

            if (user == null || user.ClassRtoId == 0) throw new BadRequest("Пользователя с таким токеном нет");

            ClassRto fClass = await _context.Classes.FirstOrDefaultAsync(h => h.Id == user.ClassRtoId);

            if (fClass == null) throw new BadRequest("Пользователь не состоит в классе");

            DayRto day = await _context.Days.FirstOrDefaultAsync(h => h.Id == user.ClassRtoId && h.Title == title);

            day.Title = newTitle;
            day.Pavilion = newPavilion;

            _context.Days.Update(day);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}