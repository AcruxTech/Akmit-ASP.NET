using Akmit.Api.Models;
using Akmit.BusinessLogic.Interfaces;
using Akmit.BusinessLogic.Models;
using Akmit.Shared.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        /// <summary>
        /// Создает нового пользователя
        /// </summary>
        /// <param name="userIdentityDto">Информация о пользователе</param>
        /// <returns>Токен</returns>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(UserIdentityDto userIdentityDto) 
        {
            try {
                return await _userService.Register(userIdentityDto.Email, userIdentityDto.Login, userIdentityDto.Password);
            }
            catch (BadRequest e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Авторизует пользователя по логину и паролю
        /// </summary>
        /// <param name="userIdentityDto">Информация о пользователе</param>
        /// <returns>Токен</returns>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpPost("auth")]
        public async Task<ActionResult<string>> Login(UserIdentityDto userIdentityDto)
        {
            try
            {
                return await _userService.Auth(userIdentityDto.Login, userIdentityDto.Password);
            }
            catch (BadRequest e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Проверяет, существует ли пользователь с данной почтой и логином
        /// </summary>
        /// <param name="email">Почта</param>
        /// <param name="login">Логин</param>
        /// <returns>true или false</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("isExist/{email}/{login}")]
        public async Task<ActionResult> IsExist(string email, string login)
        {
            return Ok(await _userService.IsExist(email, login));
        }

        /// <summary>
        /// Возвращает полную информацию о пользователя по токену
        /// </summary>
        /// <param name="token">Токен</param>
        /// <returns>Полная информация о пользователе</returns>
        [ProducesResponseType(typeof(UserInformationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [HttpPost("getByToken")]
        public async Task<ActionResult<UserInformationDto>> GetByToken(Token token)
        {
            try
            {
                UserInformationDto userInformationDto =
                    _mapper.Map<UserInformationDto>(await _userService.GetByToken(token.Body));

                return Ok(userInformationDto);
            }
            catch (NotFound e)
            {
                return NotFound(e);
            }
        }

        /// <summary>
        /// Получает краткую информацию о пользователе по ID
        /// </summary>
        /// <param name="id">ID пользователя</param>
        /// <returns>Краткая информация о пользователе</returns>
        [ProducesResponseType(typeof(UserInformationShortDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [HttpGet("getById/{id}")]
        public async Task<ActionResult<UserInformationShortDto>> GetById(int id)
        {
            try
            {
                UserInformationShortDto userInformationShortDto =
                    _mapper.Map<UserInformationShortDto>(await _userService.GetById(id));

                return Ok(userInformationShortDto);
            }
            catch (NotFound e)
            {
                return NotFound(e);
            }
        }

        /// <summary>
        /// Возвращает краткую информацию о пользователях, состоящих в классе с данным ClassID
        /// </summary>
        /// <param name="id">ID класса</param>
        /// <returns>Список пользователей, сотсоящих в классе с данным ClassID</returns>
        [ProducesResponseType(typeof(List<UserInformationShortDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [HttpGet("getByClassId/{id}")]
        public async Task<ActionResult<List<UserInformationShortDto>>> GetByClassId(int id)
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
            catch (NotFound e)
            {
                return NotFound(e);
            }
        }

        /// <summary>
        /// Запрашивает токен S3-API для дальнейшей работы с изображением профиля 
        /// </summary>
        /// <returns>Токен S3-API</returns>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [HttpGet("getTokenS3")]
        public async Task<ActionResult<string>> GetTokenS3()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Auth-User", "209703_Akmit");
            client.DefaultRequestHeaders.Add("X-Auth-Key", "m[3w#hZdCv");
            HttpResponseMessage response = await client.GetAsync("https://api.selcdn.ru/auth/v1.0");
            if (response.StatusCode != HttpStatusCode.NoContent) 
                return BadRequest("Сервер в настоящий момент недоступен");
            return Ok(response.Headers);
        }

        /// <summary>
        /// Изменяет пользователя по новым данным
        /// </summary>
        /// <param name="userUpdateDto">Информация о пользователе для обновления</param>
        /// <returns>Статус-код 200</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [HttpPut("change")]
        public async Task<ActionResult> Change(UserUpdateDto userUpdateDto)
        {
            try
            {
                await _userService.Change(userUpdateDto.Token, userUpdateDto.NewLogin, userUpdateDto.NewEmail, userUpdateDto.NewUrl);
                return Ok();
            }
            catch(NotFound e)
            {
                return NotFound(e);
            }
        }
    }
}
