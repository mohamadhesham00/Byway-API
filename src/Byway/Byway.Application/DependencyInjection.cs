using Byway.Application.Interfaces;
using Byway.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Byway.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Services
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInstructorService, InstructorService>();

            return services;
        }
    }
}
