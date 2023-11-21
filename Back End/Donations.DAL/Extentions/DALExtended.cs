using Donations.DAL.Data;
using Donations.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DALExtended
    {
        public static IServiceCollection AddDALServices(this IServiceCollection services)
        {
            services.AddScoped<IDonationRepository, DonationRepository>();

            return services;
        }
    }
}
