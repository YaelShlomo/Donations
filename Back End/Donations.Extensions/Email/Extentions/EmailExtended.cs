using Donations.Common.Email.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EmailExtended
    {
        public static IServiceCollection AddEmailServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}