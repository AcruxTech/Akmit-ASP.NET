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
    public class LessonService : ILessonService
    {
        private readonly IAkmitContext _context;
        private readonly IMapper _mapper;

        public LessonService(IAkmitContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Add(int classRtoId, string dayTitle, LessonInformationBlo lessonInformationBlo)
        {
            DayRto day = await _context.Days.FirstOrDefaultAsync(h => h.ClassRtoId == classRtoId && h.Title == dayTitle);
            if (day == null) throw new BadRequest("Не найдено дня по текущим данным");

            LessonRto lesson = new LessonRto()
            {
                Number = lessonInformationBlo.Number,
                Lesson = lessonInformationBlo.Lesson,
                Homework = lessonInformationBlo.Homework,
                Cabinet = lessonInformationBlo.Cabinet,
                DayRtoId = day.Id
            };

            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int classRtoId, string dayTitle, int number)
        {
            DayRto day = await _context.Days.FirstOrDefaultAsync(h => h.ClassRtoId == classRtoId && h.Title == dayTitle);
            if (day == null) throw new BadRequest("Не найдено дня по текущим данным");

            LessonRto lesson = await _context.Lessons.FirstOrDefaultAsync(h => h.DayRtoId == day.Id && h.Number == number);
            if (lesson == null) throw new BadRequest("Не найдено урока по текущим данным");

            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<LessonInformationBlo>> GetDayLessons(int classRtoId, string dayTitle)
        {
            DayRto day = await _context.Days.FirstOrDefaultAsync(h => h.ClassRtoId == classRtoId && h.Title == dayTitle);
            if (day == null) throw new BadRequest("Не найдено дня по текущим данным");

            List<LessonRto> lessonsRto = await _context.Lessons.Where(h => h.DayRtoId == day.Id).ToListAsync();
            if (lessonsRto.Count == 0) return null;

            List<LessonInformationBlo> lessons = new List<LessonInformationBlo>();
            for (int i = 0; i < lessonsRto.Count; i++)
            {
                lessons.Add(_mapper.Map<LessonInformationBlo>(lessonsRto[i]));
            }

            return lessons;
        }

        public async Task<bool> Update(int classRtoId, string dayTitle, int number, LessonUpdateBlo lessonUpdateBlo)
        {
            DayRto day = await _context.Days.FirstOrDefaultAsync(h => h.ClassRtoId == classRtoId && h.Title == dayTitle);
            if (day == null) throw new BadRequest("Не найдено дня по текущим данным");

            LessonRto lesson = await _context.Lessons.FirstOrDefaultAsync(h => h.DayRtoId == day.Id && h.Number == number);
            if (lesson == null) throw new BadRequest("Не найдено урока по текущим данным");

            lesson.Number = lessonUpdateBlo.NewNumber;
            lesson.Lesson = lessonUpdateBlo.NewLesson;
            lesson.Homework = lessonUpdateBlo.NewHomework;
            lesson.Cabinet = lessonUpdateBlo.NewCabinet;

            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
