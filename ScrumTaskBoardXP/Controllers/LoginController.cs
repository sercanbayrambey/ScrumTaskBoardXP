using Microsoft.AspNetCore.Mvc;
using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Web.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return View(new UserLoginDto());
            else
                return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");

            await _userService.Logout();
            SuccessAlert("Çıkış başarılı.");
            return RedirectToAction("Index", "Home");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var loginResult = await _userService.Login(userLoginDto);
            if (!loginResult.Success)
            {
                ErrorAlert(loginResult.Message);
                return View("Index", userLoginDto);
            }
            else
            {
                SuccessAlert(loginResult.Message);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
