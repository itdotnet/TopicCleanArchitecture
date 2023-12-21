using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicCleanArchitecture.Application.Contracts.Persistence;
using TopicCleanArchitecture.Persistence.DatabaseContext;
using TopicCleanArchitecture.Persistence.Repositories;

namespace TopicCleanArchitecture.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<TopicDatabaseContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("TopicDatabaseConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();

            return services;
        }
    }
}
