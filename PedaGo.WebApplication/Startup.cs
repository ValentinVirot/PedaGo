//-----------------------------------------------------------------------
// <copyright file="Startup.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.WebApplication
{
    using System;
    using System.Text;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.Tokens;
    using PedaGo.Business;
    using PedaGo.Business.Contracts;
    using PedaGo.EntityContext;
    using PedaGo.Repository;
    using PedaGo.Repository.Contracts;

    /// <summary>
    /// Configuration part of our WebApplication
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration interface
        /// </summary>
        private IConfiguration config;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="configuration">Configuration interface</param>
        public Startup(IConfiguration configuration)
        {
            this.config = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit MSDN
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("PedaGoPolicy", p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });

            services.AddControllers();
            services.AddSpaStaticFiles(options => options.RootPath = "smartcity2020/dist");
            services.AddSingleton<ITrialBusiness, TrialBusiness>();
            services.AddSingleton<ITrialRepository, DbTrialRepository>();
            services.AddSingleton<IMissionRepository, DbMissionRepository>();
            services.AddSingleton<IMissionBusiness, MissionBusiness>();
            services.AddSingleton<IPlayerRepository, DbPlayerRepository>();
            services.AddSingleton<IPlayerBusiness, PlayerBusiness>();
            services.AddSingleton<IStepBusiness, StepBusiness>();
            services.AddSingleton<IStepRepository, DbStepRepository>();
            services.AddSingleton<IRouteBusiness, RouteBusiness>();
            services.AddSingleton<IRouteRepository, DbRouteRepository>();
            services.AddSingleton<IOrganizerRepository, DbOrganizerRepository>();
            services.AddSingleton<IOrganizerBusiness, OrganizerBusiness>();
            services.AddSingleton<IGameBusiness, GameBusiness>();
            services.AddSingleton<IGameRepository, DbGameRepository>();
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(this.config["ConnectionStrings:SQLServer"]));

            // JWT Auth
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Issuer"],
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
                };
            });

            services.AddMvc();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Defines a class that provides the mechanisms to configure an application's request pipeline.</param>
        /// <param name="env">Provides information about the web hosting environment an application is running in.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors("PedaGoPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpaStaticFiles();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "dist";
                spa.Options.StartupTimeout = TimeSpan.FromSeconds(200);
            });
        }
    }
}
