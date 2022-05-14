using Akmit.Api.Models;
using Akmit.BusinessLogic.Interfaces;
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

        [HttpPost("create")]
        public async Task<ActionResult<ClassInformationDto>> Create(ClassIdentityDto classIdentityDto)
        {
            return _mapper.Map<ClassInformationDto>(await _classService.Create(classIdentityDto.Token, classIdentityDto.Title));
        }
    }
}
