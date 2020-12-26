using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Business.Abstract
{
    public interface IUserService :IGenericService<UserEntity>
    {
        Task Login(UserLoginDto loginDto);
        Task Register(UserRegisterDto registerDto);
        Task Logout();
        Task<UserDto> GetLoggedInUserInfo();
   
    }
}
