using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumTaskBoardXP.Data.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordSha1 { get; set; }
        public ICollection<TaskDto> Tasks { get; set; }
    }
}
