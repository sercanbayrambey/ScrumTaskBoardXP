using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Business.Results;
using ScrumTaskBoardXP.Business.Utilities;
using ScrumTaskBoardXP.Data.Abstract;
using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Business.Concrete
{
    public class UserManager : GenericManager<UserEntity>, IUserService
    {
        private readonly IUserDAL _userDAL;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public UserManager(IUserDAL userDAL, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(userDAL)
        {
            _userDAL = userDAL;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        private async Task Login(UserEntity user)
        {
            var claims = new List<Claim>  {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim("FullName", user.Name),
                    new Claim(ClaimTypes.Role, "User"),
                    new Claim("UserId", user.Id.ToString())
              };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));;
        }

        public async Task<IResult> Login(UserLoginDto loginDto)
        {
            var user = await _userDAL.GetUser(loginDto.Email, SHA1.Generate(loginDto.Password));

            if (user == null)
                return new ErrorResult("Yanlış kullanıcı adı veya şifre");

            await Login(user);

            return new Result("Giriş başarılı.");
        }

        public async Task<IResult> Register(UserRegisterDto registerDto)
        {
            var user = await _userDAL.GetByEmail(registerDto.Email);

            if (user != null)
                return new ErrorResult("Bu E-Mail kullanılıyor.");

            user = new UserEntity()
            {
                Email = registerDto.Email,
                Name = registerDto.Name,
                PasswordSha1 = SHA1.Generate(registerDto.Password)
            };
            _userDAL.Add(user);

            await Login(user);

            return new Result("Kayıt başarılı.");
        }

        public async Task<UserDto> GetLoggedInUserInfo()
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated == false)
                return null;

            var email = _httpContextAccessor.HttpContext.User.Identity.Name;

            var user = await _userDAL.GetByEmail(email);
            if (user == null)
                return null;

            var userDto = _mapper.Map<UserEntity, UserDto>(user);

            return userDto;
        }

        public async Task Logout()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
