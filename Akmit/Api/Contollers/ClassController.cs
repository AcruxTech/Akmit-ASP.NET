using Akmit.Api.Models;
using Akmit.BusinessLogic.Interfaces;
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
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        private readonly IMapper _mapper;

        public ClassController(IClassService classService, IMapper mapper)
        {
            _classService = classService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassInformationDto>> Get(int id)
        {
            return _mapper.Map<ClassInformationDto>(await _classService.Get(id));
        }

        [HttpPost("create")]
        public async Task<ActionResult<ClassInformationDto>> Create(ClassIdentityDto classIdentityDto)
        {
            return _mapper.Map<ClassInformationDto>(await _classService.Create(classIdentityDto.Token, classIdentityDto.Title));
        }

        [HttpPost("join")]
        public async Task<ActionResult<bool>> Join(ClassIdentityDto classIdentityDto)
        {
            try
            {
                return await _classService.Join(classIdentityDto.Token, classIdentityDto.Title, classIdentityDto.SecretCode);
            }
            catch (BadRequest)
            {
                return BadRequest();
            }
        }

        [HttpPost("leave")]
        public async Task<ActionResult<bool>> Leave(Token token)
        {
            return await _classService.Leave(token.Body);
        }
    }
}
