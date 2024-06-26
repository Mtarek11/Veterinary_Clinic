﻿using Application.Abstract.Storages;
using Application.Services;
using Infrastructure.Services;
using Infrastructure.Storages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<ITokenHandlerService, TokenHandlerService>();
            services.AddScoped(typeof(IPaginationService<>), typeof(PaginationService<>));
        }
        public static void AddStorage<TStorage>(this IServiceCollection services) where TStorage : Storage, IStorage
        {
            services.AddScoped<IStorage, TStorage>();
        }
    }
}
