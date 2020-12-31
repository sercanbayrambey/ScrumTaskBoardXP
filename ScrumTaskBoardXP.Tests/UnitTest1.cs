using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Business.Concrete;
using ScrumTaskBoardXP.Business.Results;
using ScrumTaskBoardXP.Business.Validations;
using ScrumTaskBoardXP.Data.Concrete;
using ScrumTaskBoardXP.Data.Dtos;
using ScrumTaskBoardXP.Entites.Concrete;
using ScrumTaskBoardXP.Web.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {

        }


        [TestMethod]
        public void Validate_Register_Model()
        {
            var userLoginDto = new UserRegisterDto { Email = "sercanbayrambeyy@gmail.com", Password = "123",Name="Sercan Bayrambey",Remember = false };
            var result = FluentValidationTool.Validate<UserRegisterDto>(new UserRegisterDtoValidator(), userLoginDto);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Validate_New_Project_Model()
        {
            var dto = new ProjectDto { Name = "PROJE", Description = "aciklama", UserId = 5 };
            var result = FluentValidationTool.Validate(new TaskDtoValidator(), dto);
            Assert.IsTrue(result);
        }



        [TestMethod]
        public void Validate_New_Task_Model()
        {
            var dto = new TaskTodosDto { Name = "Task", Description = "aciklama", TaskId = 5 };
            var result = FluentValidationTool.Validate(new TaskTodoDtoValidator(), dto);
            Assert.IsTrue(result);
        }
    }
}
