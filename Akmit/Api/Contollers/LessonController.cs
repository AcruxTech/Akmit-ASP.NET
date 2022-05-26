using Akmit.Api.Models;
using Akmit.BusinessLogic.Interfaces;
using Akmit.BusinessLogic.Models;
using Akmit.Shared.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.Api.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;

        public LessonController(ILessonService lessonService, IMapper mapper)
        {
            _lessonService = lessonService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(LessonIdentityDto lessonIdentityDto)
        {
            try
            {
                await _lessonService.Add(lessonIdentityDto.ClassRtoId, lessonIdentityDto.DayTitle, 
                    _mapper.Map<LessonInformationBlo>(lessonIdentityDto));
                return Ok();
            }
            catch (BadRequest e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(LessonDeleteDto lessonDeleteDto)
        {
            try
            {
                await _lessonService.Delete(lessonDeleteDto.ClassRtoId, lessonDeleteDto.DayTitle, lessonDeleteDto.Number);
                return Ok();
            }
            catch (BadRequest e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{classRtoId}/{dayTitle}")]
        public async Task<ActionResult<List<LessonInformationDto>>> GetDayLessons(int classRtoId, string dayTitle)
        {
            try
            {
                List<LessonInformationDto> lessons = new List<LessonInformationDto>();
                List<LessonInformationBlo> lessonsBlo = await _lessonService.GetDayLessons(classRtoId, dayTitle);
                if (lessonsBlo == null) return null; 

                for (int i = 0; i < lessonsBlo.Count; i++)
                {
                    lessons.Add(_mapper.Map<LessonInformationDto>(lessonsBlo[i]));
                }

                return lessons;
            }
            catch (BadRequest e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut()]
        public async Task<ActionResult> Update(LessonUpdateDto lessonUpdateDto)
        {
            try
            {
                await _lessonService.Update(lessonUpdateDto.ClassRtoId, lessonUpdateDto.DayTitle, lessonUpdateDto.NewNumber,
                    _mapper.Map<LessonUpdateBlo>(lessonUpdateDto));
                return Ok();
            }
            catch (BadRequest e)
            {
                return BadRequest(e);
            }
        }
    }
}
