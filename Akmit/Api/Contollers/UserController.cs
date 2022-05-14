using Akmit.Api.Models;
using Akmit.BusinessLogic.Interfaces;
using Akmit.BusinessLogic.Models;
using Akmit.Shared.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
                return await _userService.Register(userIdentityDto.Email, userIdentityDto.Login, userIdentityDto.Password);
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

        [HttpPost("getByToken")]
        public async Task<ActionResult<UserInformationDto>> GetByToken(Token token)
        {
            try
            {
                UserInformationDto userInformationDto =
                    _mapper.Map<UserInformationDto>(await _userService.GetByToken(token.Body));

                return Ok(userInformationDto);
            }
            catch (NotFound)
            {
                return NotFound();
            }
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

        [HttpGet("getByClassId/{id}")]
        public async Task<ActionResult<UserInformationDto>> GetByClassId(int id)
        {
            try
            {
                List<UserInformationShortBlo> usersBlo = await _userService.GetByClassId(id);
                List<UserInformationShortDto> usersDto = new List<UserInformationShortDto>();

                for (int i = 0; i < usersBlo.Count; i++)
                {
                    usersDto.Add(_mapper.Map<UserInformationShortDto>(usersBlo[i]));
                }

                return Ok(usersDto);
            }
            catch (NotFound)
            {
                return NotFound();
            }
        }

        [HttpGet("getTokenS3")]
        public async Task<ActionResult<HttpResponseHeaders>> GetTokenS3(string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Auth-User", "209703_Akmit");
            client.DefaultRequestHeaders.Add("X-Auth-Key", "m[3w#hZdCv");
            HttpResponseMessage response = await client.GetAsync("https://api.selcdn.ru/auth/v1.0");
            if (response.StatusCode != HttpStatusCode.NoContent) 
                return BadRequest("Сервер в настоящий момент недоступен");
            return response.Headers;
        }


        [HttpPut("change")]
        public async Task<ActionResult> Change(UserUpdateDto userUpdateDto)
        {
            try
            {
                await _userService.Change(userUpdateDto.Token, userUpdateDto.NewLogin, userUpdateDto.NewEmail, userUpdateDto.NewUrl);
                return Ok();
            }
            catch(NotFound)
            {
                return NotFound();
            }
        }
    }
}
