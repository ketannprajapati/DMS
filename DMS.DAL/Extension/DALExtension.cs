using DMS.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.DAL.Extension
{
    public static class DALExtension
    {
        public static void AddDALResolver(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DMSContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<UserFileRepository>();
        }
    }
}
