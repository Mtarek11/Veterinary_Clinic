using Application.Repositories.Admins;
using Application.Repositories.Files;
using Application.Repositories.Customers;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories.Admins;
using Persistence.Repositories.Files;
using Persistence.Repositories.Customers;
using Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Materials;
using Persistence.Repositories.Materials;
using Application.Repositories.MaterialSupplings;
using Persistence.Repositories.MaterialSupplings;
using Application.Repositories.Treatments;
using Persistence.Repositories.Treatments;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<Context>(opt => opt.UseSqlServer(Configuration.GetConnectionString("OmarElHadyDB")));

            //Admins
            services.AddScoped<IAdminCommandRepository, AdminCommandRepository>();
            services.AddScoped<IAdminQueryRepository, AdminQueryRepository>();
            services.AddScoped<IUserService, UserService>();

            //File
            services.AddScoped<IFileCommandRepository, FileCommandRepository>();
            services.AddScoped<IFileQueryRepository, FileQueryRepository>();

            //Auth
            services.AddScoped<IAuthService, AuthService>();

            //Customer
            services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
            services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();

            //Material
            services.AddScoped<IMaterialCommandRepository, MaterialCommandRepository>();
            services.AddScoped<IMaterialQueryRepository, MaterialQueryRepository>();

            //Material suppling
            services.AddScoped<IMaterialSupplingCommandRepository, MaterialSupplingCommandRepository>();
            services.AddScoped<IMaterialSupplingQueryRepository, MaterialSupplingQueryRepository>();

            //Treatment
            services.AddScoped<ITreatmentCommandRepository, TreatmentCommandRepository>();
            services.AddScoped<ITreatmentQueryRepository, TreatmentQueryRepository>();
        }
    }
}
