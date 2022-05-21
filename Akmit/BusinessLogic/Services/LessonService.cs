using Akmit.BusinessLogic.Interfaces;
using Akmit.BusinessLogic.Models;
using Akmit.DataAccess.Interfaces;
using AutoMapper;
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

        public Task<bool> Add(string token, LessonInformationBlo lessonInformationBlo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string token, string dayTitle, int number)
        {
            throw new NotImplementedException();
        }

        public Task<LessonInformationBlo> Get(string token, string dayTitle, int number)
        {
            throw new NotImplementedException();
        }

        public Task<List<LessonInformationBlo>> GetDayLessons(string token, string dayTitle)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(string token, LessonUpdateBlo lessonUpdateBlo)
        {
            throw new NotImplementedException();
        }
    }
}
