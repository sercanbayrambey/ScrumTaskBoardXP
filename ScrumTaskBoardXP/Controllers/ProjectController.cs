using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;
using ScrumTaskBoardXP.Entites.Enums;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Web.Controllers
{
    [Authorize]
    public class ProjectController : BaseController
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _mapper = mapper;
            _projectService = projectService;
        }

        [HttpPost]
        public IActionResult Add(ProjectDto taskDto)
        {
            var taskEntity = _mapper.Map<ProjectEntity>(taskDto);
            _projectService.Add(taskEntity);
            SuccessAlert("Ekleme işlemi başarılı.");
            return RedirectToAction("Update", new { id = taskEntity.Id });

        }

        public IActionResult Update(int id)
        {
            var task = _projectService.GetById(id);
            if (task == null)
                return NotFound();
            var taskDto = _mapper.Map<ProjectDto>(task);
            return View(taskDto);
        }


        [HttpPost]
        public IActionResult Update(ProjectDto taskDto)
        {
            if (taskDto == null)
                return NotFound();
            if (ModelState.IsValid)
            {
                var taskToUpdate = _projectService.GetById(taskDto.Id);
                if (taskToUpdate == null)
                    return NotFound();
                _projectService.Update(_mapper.Map(taskDto, taskToUpdate));
                SuccessAlert("Güncelleme işlemi başarılı.");
                return RedirectToAction("Update", new { id = taskDto.Id });
            }
            else
                return View(taskDto);
        }



        public async Task<IActionResult> Delete(int id)
        {
            var taskToDelete = _projectService.GetById(id);
            if (taskToDelete == null)
                return BadRequest();
            _projectService.Delete(taskToDelete);
            SuccessAlert("Silme işlemi başarılı.");
            return RedirectToAction("Index", "Home");
        }
    }
}
