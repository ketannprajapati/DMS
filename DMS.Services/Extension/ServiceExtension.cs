using DMS.DAL.Context;
using DMS.DAL.Extension;
using DMS.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Extension
{
    public static class ServiceExtension
    {
        public static void AddServiceResolver(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserFileService, UserFileService>();
            services.AddDALResolver(configuration);
        }
    }
}
