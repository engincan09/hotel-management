using HotelManagement.Bll.EntityCore.Abstract.Systems;
using HotelManagement.Bll.EntityCore.Abstract.Users;
using HotelManagement.Bll.EntityCore.Concrete.Systems;
using HotelManagement.Bll.EntityCore.Concrete.Users;
using HotelManagement.Core.Helpers.Handlers;
using HotelManagement.Core.Middleware;
using HotelManagement.Dal.EfCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace HotelManagement.Api
{
    public class Startup
    {
        /// <summary>
        /// Confirations
        /// </summary>
        public IConfiguration _configuration { get; }

        /// <summary>
        /// Starter
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration) => _configuration = configuration;


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HotelManagementContext>(options =>
               options.UseNpgsql(_configuration.GetConnectionString("Default")));


            services.AddHttpContextAccessor();
            services.AddResponseCompression();
            _addServices(ref services);

            services.AddHttpClient();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
              options.RequireHttpsMetadata = false;
              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuer = false,
                  ValidateAudience = false,
                  ValidateLifetime = true, 
                  ValidateIssuerSigningKey = true, 
                  ValidIssuer = _configuration["Jwt:Issuer"],
                  ValidAudience = _configuration["Jwt:Issuer"],
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
              };

              options.Events = new JwtBearerEvents
              {
                  OnMessageReceived = context =>
                  {
                      var accessToken = context.Request.Query["access_token"];

                      var path = context.HttpContext.Request.Path;
                      if (!string.IsNullOrEmpty(accessToken)
                          && (path.StartsWithSegments("/hub")))
                      {
                          context.Token = accessToken;
                      }
                      return Task.CompletedTask;
                  }
              };
          });

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            }).AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            })
           .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddMemoryCache();
            services.AddResponseCaching();

            services.AddCors(options =>
            {
                options.AddPolicy("ApiCorsPolicy",
                    p => p.WithOrigins(_configuration.GetSection("Host:AllowedOrigins").Get<string[]>()).
                    AllowAnyMethod().
                    AllowAnyHeader().
                    AllowCredentials());
            });

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });

            services.AddSwaggerGen(
                options =>
                {
                    options.OperationFilter<SwaggerDefaultValues>();
                    options.CustomSchemaIds(type => type.ToString() + type.GetHashCode());
                    options.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml"));
                });



            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp";
            });
        }

        /// <summary>
        /// Server configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            env.CreateContentFolders();

            var cultureInfo = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            app.UseAuthentication();
            app.UseCors("ApiCorsPolicy");

            // FOR LINUX PROXYING
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseResponseCaching();
            app.UseMiddleware<ErrorHandler>();
            app.Use(next => context => { context.Request.EnableRewind(); return next(context); });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                        name: "default",
                        template: "{controller}/{action=Index}/{id?}");
            });

            if (!env.IsDevelopment())
                app.UseSpa(spa =>
                {
                    spa.Options.SourcePath = "ClientApp";
                });

            app.UseSwagger();
        }

        private static void _addServices(ref IServiceCollection services)
        {
            #region Systems
            services.AddScoped<ICustomHttpContextAccessor, CustomHttpContextAccessor>();
            services.AddScoped<ILookupRepository, LookupRepository>();
            services.AddScoped<ILookupTypeRepository, LookupTypeRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<IPagePermissionRepository, PagePermissionRepository>();
            #endregion

            #region User
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            #endregion
        }
    }
}
