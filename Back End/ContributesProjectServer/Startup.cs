using Donations.DAL.Data;
using Donations.BL.Services;
using Donations.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using AutoMapper;

namespace Donations
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddControllers();
            services.AddHttpClient();
            services.AddDonationsServices();
            services.AddDALServices();

            services.AddControllers().AddJsonOptions(x =>
            {
                // serialize enums as strings in api responses (e.g. Role)
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

                // ignore omitted parameters on models to enable optional params (e.g. User update)
                x.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddDbContext<DonationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DonationsDatabase")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));
            //services.AddScoped<IDonationService, DonationService>();
            //services.AddScoped<IDonationRepository, DonationRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
                });
            }


            // Configure middleware and routing here
            app.UseHttpsRedirection(); // Use this if you want to enable HTTPS redirection
            app.UseStaticFiles(); // Use this if you want to serve static files
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Add this if you're using controllers
                // Configure routing for your application
            });
        }
    }
}
