using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Business.Concrete;
using ScrumTaskBoardXP.Business.Mapping;
using ScrumTaskBoardXP.Data.Abstract;
using ScrumTaskBoardXP.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumTaskBoardXP.Business.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddDIScopes(this IServiceCollection services)
        {
            services.AddScoped<ITaskDAL, TaskRepository>();
            services.AddScoped<ITaskTodosDAL, TaskTodoRepository>();
            services.AddScoped<IUserDAL, UserRepository>();

            services.AddScoped<ITaskService, TaskManager>();
            services.AddScoped<ITaskTodosService, TaskTodosManager>();
            services.AddScoped<IUserService, UserManager>();
        }

        public static IServiceCollection AddAutomapperConfiguration(this IServiceCollection services)
        {
            return services.AddAutoMapper(conf => conf.AddProfile(new MapProfile()));
        }

    }
}
