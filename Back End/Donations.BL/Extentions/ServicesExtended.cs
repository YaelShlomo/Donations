using Donations.BL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesExtended
    {
        public static IServiceCollection AddDonationsServices(this IServiceCollection services)
        {
            services.AddScoped<IDonationService, DonationService>();

            return services;
        }
    }
}