using Akmit.Api.Models;
using Akmit.BusinessLogic.Interfaces;
using Akmit.Shared.Exceptions;
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
            try {
                return await _userService.Register(userIdentityDto.Login, userIdentityDto.Email, userIdentityDto.Password);
            }
            catch (BadRequest)
            {
                return BadRequest();
            }
        }

        [HttpPost("auth")]
        public async Task<ActionResult<string>> Login(UserIdentityDto userIdentityDto)
        {
            try
            {
                return await _userService.Auth(userIdentityDto.Login, userIdentityDto.Password);
            }
            catch (BadRequest)
            {
                return BadRequest();
            }
        }

        [HttpGet("isExist/{email}/{login}")]
        public async Task<ActionResult> IsExist(string email, string login)
        {
            return Ok(await _userService.IsExist(email, login));
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<UserInformationShortDto>> GetById(int id)
        {
            try
            {
                UserInformationShortDto userInformationShortDto =
                    _mapper.Map<UserInformationShortDto>(await _userService.GetById(id));

                return Ok(userInformationShortDto);
            }
            catch (NotFound)
            {
                return NotFound();
            }
        }

        [HttpGet("getByToken/{token}")]
        public async Task<ActionResult<UserInformationShortDto>> GetBytoken(string token)
        {
            try
            {
                UserInformationShortDto userInformationShortDto =
                    _mapper.Map<UserInformationShortDto>(await _userService.GetByToken(token));

                return Ok(userInformationShortDto);
            }
            catch (NotFound)
            {
                return NotFound();
            }
        }

        //[HttpPut("change")]
        //public async Task<ActionResult<UserInformationShortDto>> Change(string token)
        //{
        //    try
        //    {
        //        UserInformationShortDto userInformationShortDto =
        //            _mapper.Map<UserInformationShortDto>(await _userService.GetByToken(token));

        //        return Ok(userInformationShortDto);
        //    }
        //    catch (NotFound)
        //    {
        //        return NotFound();
        //    }
        //}
    }
}
