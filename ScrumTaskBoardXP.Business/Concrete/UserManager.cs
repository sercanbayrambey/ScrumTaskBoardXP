using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Data.Abstract;
using ScrumTaskBoardXP.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumTaskBoardXP.Business.Concrete
{
    public class UserManager : GenericManager<UserEntity>, IUserService
    {
        private readonly IUserDAL _userDAL;
        public UserManager(IUserDAL userDAL) : base(userDAL)
        {
            _userDAL = userDAL;
        }
    }
}
