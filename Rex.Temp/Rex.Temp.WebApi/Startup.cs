using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Rex.Temp.EF.Repository;
using Rex.Temp.IService;
using Rex.Temp.Service;
using Swashbuckle.AspNetCore.Swagger;

namespace Rex.Temp.WebApi
{
    public class Startup
    {
        private const string _dataBaseKeyStr = "RexTemp";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //add .net core version 2.2
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            
            //add db context
            services.AddDbContext<RexTempDbContext>(opt =>
               opt.UseSqlServer(Configuration.GetConnectionString(_dataBaseKeyStr)));

            //inject service
            ConfigInterfaces(services);

            //add swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "DemoAPI", Version = "v1" });
            });

            //add hangfire
            services.AddHangfire(x =>
            {
                x.UseSqlServerStorage(Configuration.GetConnectionString(_dataBaseKeyStr));
                x.UseColouredConsoleLogProvider();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoAPI V1");
            });

            app.UseHangfireServer(new BackgroundJobServerOptions
            {
                ServerName = "Test",
                WorkerCount = 20,
                ShutdownTimeout = TimeSpan.FromMinutes(1),
                SchedulePollingInterval = TimeSpan.FromSeconds(3),
            });
            app.UseHangfireDashboard();
        }

        private void ConfigInterfaces(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
