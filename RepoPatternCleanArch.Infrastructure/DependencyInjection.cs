using Microsoft.Extensions.DependencyInjection;
using RepoPatternCleanArch.Domain.Abstractions;
using RepoPatternCleanArch.Domain.Repositories;
using RepoPatternCleanArch.Infrastructure.Data;
using RepoPatternCleanArch.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternCleanArch.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
