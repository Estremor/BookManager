using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookManager.DI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace BookManager
{
    /// <summary>
    /// Configuration Class project
    /// </summary>
    public class Startup
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// Propiedad Para binding
        /// </summary>
        private const string _DbSetting = "DbSetting";
        #endregion
        #region C'tor
        /// <summary>
        /// Inicia la configuracion
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion


        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123456789101112131415161718192021222324252627282930")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddControllers();

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
                });
            });

            // Cargamos AutoMapper
            services.AddAutoMapper(typeof(Startup));


            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            /*Cargamos la Configuracion de Conexion del JSON*/
            var dbSettings = new DataPersistence.DbSettings();
            Configuration.Bind(_DbSetting, dbSettings);
            services.AddSingleton(dbSettings);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "BookManager", Version = "v1" });
            });

            DependencyInjectionProfile.RegisterProfile(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseRouting();

            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "BookManager");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
