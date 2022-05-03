using Akmit.Api.Models;
using Akmit.BusinessLogic.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Akmit.Api.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(UserIdentityDto userIdentityDto) 
        {
            return await _userService.Register(userIdentityDto.Login, userIdentityDto.Email, userIdentityDto.Password);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserIdentityDto userIdentityDto)
        {
            return await _userService.Auth(userIdentityDto.Login, userIdentityDto.Password);
        }

        [HttpGet("get-id/{id}")]
        public async Task<ActionResult<UserInformationShortDto>> GetById(int id)
        {
            UserInformationShortDto userInformationShortDto =
                _mapper.Map<UserInformationShortDto>(await _userService.GetById(id));

            return Ok(userInformationShortDto);        
        }
    }
}
