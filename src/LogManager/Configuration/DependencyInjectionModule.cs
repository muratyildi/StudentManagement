using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogManager.Configuration
{
    public static class DependencyInjectionModule
    {
        public static void AddLogManager(this IServiceCollection services)
        {
            services.AddScoped<ILogService, LogService>();
        }
    }
}
