using Microsoft.AspNetCore.Mvc;
using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Web.Controllers
{
    public class RegisterController : BaseController
    {
        private readonly IUserService _userService;
        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return View(new UserRegisterDto());
            else
                return RedirectToAction("Index", "Home");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            var registerResult = await _userService.Register(userRegisterDto);
            if (registerResult.Success)
            {
                SuccessAlert("Kayıt başarılı.");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ErrorAlert(registerResult.Message);
                return View("Index", userRegisterDto);
            }
        }
    }
}
