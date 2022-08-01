using AppointmentScheduler.DataAccess;
using AppointmentScheduler.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduler
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            if (_env.IsDevelopment())
            {
                services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("default")));
            }
            else
            {
                services.AddDbContext<AppDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PostGreSql")));
            }
            services.AddScoped<UserRepository>();
            services.AddScoped<AppointmentRepository>();
            services.AddCors(options => options.AddDefaultPolicy(
                    builder => builder.AllowAnyOrigin()
                ));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AppointmentScheduler", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext database)
        {
            
            
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AppointmentScheduler v1"));
            

            app.UseHttpsRedirection();

            
            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            database.Database.EnsureCreated();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
