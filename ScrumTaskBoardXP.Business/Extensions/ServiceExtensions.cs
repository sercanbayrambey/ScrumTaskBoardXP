﻿using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Business.Concrete;
using ScrumTaskBoardXP.Business.Mapping;
using ScrumTaskBoardXP.Business.Validations;
using ScrumTaskBoardXP.Data;
using ScrumTaskBoardXP.Data.Abstract;
using ScrumTaskBoardXP.Data.Concrete;
using ScrumTaskBoardXP.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumTaskBoardXP.Business.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddDIScopes(this IServiceCollection services)
        {
            services.AddScoped<ScrumTaskBoardXPDBContext>();

            services.AddScoped<ITaskDAL, TaskRepository>();
            services.AddScoped<ITaskTodosDAL, TaskTodoRepository>();
            services.AddScoped<IUserDAL, UserRepository>();

            services.AddScoped<ITaskService, TaskManager>();
            services.AddScoped<ITaskTodosService, TaskTodosManager>();
            services.AddScoped<IUserService, UserManager>();
            
            services.AddTransient<IValidator<TaskDto>, TaskDtoValidator>();
            services.AddTransient<IValidator<TaskTodosDto>, TaskTodoDtoValidator>();
            services.AddTransient<IValidator<UserRegisterDto>, UserRegisterDtoValidator>();
        }

        public static IServiceCollection AddAutomapperConfiguration(this IServiceCollection services)
        {
            return services.AddAutoMapper(conf => conf.AddProfile(new MapProfile()));
        }

    }
}
