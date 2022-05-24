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

        public DayController(IDayService dayService)
        {
            _dayService = dayService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(DayIdentityDto dayIdentityDto)
        {
            try
            {
                await _dayService.Add(dayIdentityDto.Token, dayIdentityDto.Title, dayIdentityDto.Pavilion);
                return Ok();
            }
            catch (BadRequest e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("get_all/{classRtoId}")]
        public async Task<ActionResult<List<DayInformationBlo>>> GetAll(int classRtoId)
        {
            return await _dayService.GetAll(classRtoId);
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
                return await _dayService.Delete(dayDeleteDto.ClassRtoId, dayDeleteDto.Title);
            }
            catch (BadRequest e)
            {
                return BadRequest(e);
            }
        }
    }
}
