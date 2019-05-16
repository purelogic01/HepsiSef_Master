using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HepsiSef.DAL;
using HepsiSef.Repository.App.Interface;
using HepsiSef.Repository.App.Repository;
using HepsiSef.Repository.Definition.Interface;
using HepsiSef.Repository.Definition.Repository;
using HepsiSef.Repository.SystemUser.Interface;
using HepsiSef.Repository.SystemUser.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace HepsiSef.API
{
    namespace HepsiSef.API
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
                services.AddDbContext<ApplicationContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

                var key = Encoding.ASCII.GetBytes("this is my custom Secret key for authnetication");
                services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("CoreSwagger", new Info
                    {
                        Title = "Swagger on ASP.NET Core",
                        Version = "1.0.0",
                        Description = "Try Swagger on (ASP.NET Core 2.1)",
                        Contact = new Contact()
                        {
                            Name = "Swagger Implementation Bora kasmer",
                            Url = "http://borakasmer.com",
                            Email = "bora@borakasmer.com"
                        },
                        TermsOfService = "http://swagger.io/terms/"
                    });
                    c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                });

                    c.AddSecurityDefinition("Bearer", new ApiKeyScheme()

                    {
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                        Name = "Authorization",
                        In = "header",
                        Type = "apiKey",
                    });
                });

                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

                
                services.AddScoped<IUserRepository, UserRepository>();
                services.AddScoped<ICategoryRepository, CategoryRepository>();
                services.AddScoped<IRecipeRepository, RecipeRepository>();
                services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();
                services.AddScoped<IStepRepository, StepRepository>();
                services.AddScoped<IRecipeImageRepository, RecipeImageRepository>();
                services.AddScoped<IRecipeCategoryRepository, RecipeCategoryRepository>();
                services.AddScoped<IBookmarkRepository, BookmarkRepository>();
                services.AddScoped<IRecipeRateRepository, RecipeRateRepository>();
                services.AddScoped<IForgatPasswordRepository, ForgatPasswordRepository>();
                services.AddScoped<IContactRepository, ContactRepository>();
                services.AddScoped<IExternalLoginRepository, ExternalLoginRepository>();
                services.AddScoped<INewsletterRepository, NewsletterRepository>();

                services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());

                });

                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                });

                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_0);
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationContext>();
                    context.Database.Migrate();
                }

                app.UseCors("CorsPolicy");
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");


                });

                app.UseStaticFiles();

                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(
                        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
                    RequestPath = "/wwwroot"
                });

                app.UseAuthentication();

                app.UseMvc(routes =>
                {

                    routes.MapRoute(
                        name: "default",
                        template: "{controller}/{action}",
                        defaults: new { controller = "Login", action = "SignIn" });

                });
            }
        }
    }
}
