using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using todo_api.DB;
using Microsoft.EntityFrameworkCore;
using todo_api.Application.Interfaces;
using MediatR;
using System.Reflection;
using todo_api.Application.Mapping.Common;
using Newtonsoft.Json;

namespace todo_api.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                cfg.AddProfile(new AssemblyMappingProfile(typeof(INotesDbContext).Assembly));
            });

            services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddControllers().AddNewtonsoftJson();

            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            var connectingString = configuration.GetConnectionString("DbConnection");
            services.AddDbContext<NotesDbContext>(options =>
            {
                options.UseSqlite(connectingString);
            });

            services.AddScoped<INotesDbContext>(provider =>
                provider.GetService<NotesDbContext>());


            return services;
        }
    }
}
