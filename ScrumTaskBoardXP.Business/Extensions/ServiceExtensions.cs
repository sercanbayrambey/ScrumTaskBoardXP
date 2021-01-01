using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ScrumTaskBoardXP.Business.Abstract;
using ScrumTaskBoardXP.Business.Concrete;
using ScrumTaskBoardXP.Business.Mapping;
using ScrumTaskBoardXP.Business.Validations;
using ScrumTaskBoardXP.Data;
using ScrumTaskBoardXP.Data.Abstract;
using ScrumTaskBoardXP.Data.Concrete;
using ScrumTaskBoardXP.Data.Dtos;

namespace ScrumTaskBoardXP.Business.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddDIScopes(this IServiceCollection services)
        {
            services.AddScoped<ScrumTaskBoardXPDBContext>();

            services.AddScoped<ITaskDAL, ProjectRepository>();
            services.AddScoped<ITaskTodosDAL, TaskTodoRepository>();
            services.AddScoped<IUserDAL, UserRepository>();

            services.AddScoped<IProjectService, ProjectManager>();
            services.AddScoped<ITaskTodosService, TaskTodosManager>();
            services.AddScoped<IUserService, UserManager>();

            services.AddTransient<IValidator<ProjectDto>, ProjectDtoValidator>();
            services.AddTransient<IValidator<TaskTodosDto>, TaskTodoDtoValidator>();
            services.AddTransient<IValidator<UserRegisterDto>, UserRegisterDtoValidator>();
        }

        public static IServiceCollection AddAutomapperConfiguration(this IServiceCollection services)
        {
            return services.AddAutoMapper(conf => conf.AddProfile(new MapProfile()));
        }

    }
}
