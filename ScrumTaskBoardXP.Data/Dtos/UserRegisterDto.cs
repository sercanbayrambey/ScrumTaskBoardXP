using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumTaskBoardXP.Data.Dtos
{
    public class UserRegisterDto : UserLoginDto
    {
        public string Name { get; set; }
    }
}
