using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AcnurContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("MyDbContext")
                    ?? throw new InvalidOperationException("Connection string 'MyDbContext' not found.")
                ));

            return services;
        }
    }
}
