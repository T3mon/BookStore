using AutoMapper;
using BLL;
using BLL.Infrastructure;
using BLL.Infrastructure.Provider;
using BLL.MaperConfigs;
using BLL.Service;
using BLL.Service.Interfaces;
using Core.Context;
using Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore
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

            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo() { Title = "swagger api", Version = "v1" });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            var option = new SendGridOptions();
            Configuration.GetSection("SendGridOptions").Bind(option);
            services.AddTransient<SendGridOptions>(x => option);

            services.AddDbContext<StoreContext>(
    options =>
        options.UseSqlServer(
            Configuration.GetConnectionString("defCon"),
            x => x.MigrationsAssembly("Core"))
        );
            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IBookService, UserBookService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<EmailConfirmationProviderOption>(op => op.TokenLifespan = TimeSpan.FromDays(20));

            services.AddControllersWithViews();
            services.AddTransient(typeof(UserBookService));
            services.AddAuthentication().AddCookie(op => op.LoginPath = "/Login");
            BllConfiguration.Configuration(services, Configuration.GetConnectionString("defCon"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
