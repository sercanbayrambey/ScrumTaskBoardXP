using System.Collections.Generic;

namespace ScrumTaskBoardXP.Entites.Concrete
{
    public class UserEntity : EntityBase<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordSha1 { get; set; }
        public ICollection<TaskEntity> Tasks { get; set; }
        public int HourlyWorkRate { get; set; }

    }
}
