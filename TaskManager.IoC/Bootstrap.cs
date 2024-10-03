using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Services;
using TaskManager.Data.AppData;
using TaskManager.Data.Repositories;
using TaskManager.Domain.Interfaces;

namespace TaskManager.IoC
{
    public static class Bootstrap
    {
        public static void Start(IServiceCollection services, IConfiguration configuration)
        {
            // Configurar o DbContext para usar Oracle e especificar o assembly de migrações
            services.AddDbContext<ApplicationContext>(x =>
            {
                x.UseOracle(configuration["ConnectionStrings:Oracle"],
                b => b.MigrationsAssembly("TaskManager.Data")); // Especifica que as migrações estão no TaskManager.Data
            });

            // Registrar outros serviços
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<ITaskService, TaskApplicationService>();
        }
    }

}
