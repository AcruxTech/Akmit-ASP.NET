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
    }
}
