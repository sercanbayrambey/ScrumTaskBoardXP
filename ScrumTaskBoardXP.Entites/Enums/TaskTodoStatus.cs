using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScrumTaskBoardXP.Entites.Enums
{
    public enum TaskTodoStatus
    {
        [Display(Name = "Yapılacak")]
        Todo = 0,
        [Display(Name = "Yapılıyor")]
        InProgress,

        [Display(Name = "Değerlendirme Aşamasında")]
        InReview,

        [Display(Name = "Yapıldı")]
        Done
    }
}
