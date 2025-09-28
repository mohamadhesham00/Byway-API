using Byway.Application.Interfaces;
using Byway.Domain.Interfaces;
using Byway.Infrastructure.Persistence;
using Byway.Infrastructure.Repositories;
using Byway.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Byway.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<BywayDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            // JWT
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            // Repos
            services.AddScoped<ICourseRepo, CourseRepo>();
            services.AddScoped<IInstructorRepo, InstructorRepo>();
            services.AddScoped<CategoryRepo, CategoryRepo>();
            services.AddScoped<ICourseContentRepo, CourseContentRepo>();

            return services;
        }
    }
}
