using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SCM.RuleEngine.Core;
using SCM.Service;
using SCM.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.RuleEngine.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IPackagingService, PackagingService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentRuleEvaluator, PaymentRuleEvaluator>();
            services.AddScoped<IPaymentRule, ActivateMembershipRule>();
            services.AddScoped<IPaymentRule, GeneratePackagingSlipRule>();
            services.AddScoped<IPaymentRule, GenerateDuplicateSlipForRoyaltyDepartmentRule>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
