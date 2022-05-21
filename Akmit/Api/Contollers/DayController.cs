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
    public class DayController : ControllerBase
    {
        private readonly IDayService _dayService;
        private readonly IMapper _mapper;

        public DayController(IDayService dayService, IMapper mapper)
        {
            _dayService = dayService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<ActionResult<DayInformationDto>> Add(DayIdentityDto dayIdentityDto)
        {
            try
            {
                return _mapper.Map<DayInformationDto>(await _dayService.Add(dayIdentityDto.Token, dayIdentityDto.Title, dayIdentityDto.Pavilion));
            }
            catch (BadRequest e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("get_all")]
        public async Task<ActionResult<List<DayInformationDto>>> GetAll(Token token)
        {
            try
            {
                List<DayInformationBlo> daysBlo = await _dayService.GetAll(token.Body);
                List<DayInformationDto> days = new List<DayInformationDto>();

                for (int i = 0; i < daysBlo.Count; i++)
                {
                    days.Append(_mapper.Map<DayInformationDto>(daysBlo[i]));
                }

                return days;
            }
            catch (NotFound e)
            {
                return NotFound(e);
            }
            catch (BadRequest e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut()]
        public async Task<ActionResult<bool>> Update(DayUpdateDto dayUpdateDto)
        {
            try
            {
                return await _dayService.Update(dayUpdateDto.Token, dayUpdateDto.Title, dayUpdateDto.NewTitle, dayUpdateDto.NewPavilion);
            }
            catch (BadRequest e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("delete")]
        public async Task<ActionResult<bool>> Delete(DayDeleteDto dayDeleteDto)
        {
            try
            {
                return await _dayService.Delete(dayDeleteDto.Token, dayDeleteDto.Title);
            }
            catch (BadRequest e)
            {
                return BadRequest(e);
            }
        }
    }
}
