using ScrumTaskBoardXP.Business.Results;
using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Business.Abstract
{
    public interface IUserService : IGenericService<UserEntity>
    {
        Task<IResult> Login(UserLoginDto loginDto);
        Task<IResult> Register(UserRegisterDto registerDto);
        Task Logout();
        Task<UserDto> GetLoggedInUserInfo();

    }
}
