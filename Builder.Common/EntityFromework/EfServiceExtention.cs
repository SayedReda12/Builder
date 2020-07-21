using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Common.EntityFromework
{
    public static class EfServiceExtention
    {
        public static IServiceCollection AddBuilderDbContext<TContext>(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction = null) where TContext :DbContext
        {
            services.AddDbContext<TContext>(optionsAction);

            services.AddScoped<DbContext, TContext>();

            return services;
        }
    }
}
