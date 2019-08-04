using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BionicProcurment.Api.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BionicProcurment.Api {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            JwtSettings settings;
            settings = GetJwtSettings ();

            services.AddSingleton<JwtSettings> (settings);
            services.AddScoped<IBionicShipmentDatabaseService, BionicShipmentDatabaseService> ();
            services.AddDbContext<BionicShipmentDatabaseService> ();

            services.AddScoped<IBionicShipmentDatabaseService, BionicShipmentDatabaseService> ();
            services.AddDbContext<BionicShipmentDatabaseService> ();

            // Customise default API behavour
            services.Configure<ApiBehaviorOptions> (options => {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddAuthentication (options => {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer ("JwtBearer", jwtBearerOptions => {
                jwtBearerOptions.TokenValidationParameters =
                new TokenValidationParameters {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey (
                Encoding.UTF8.GetBytes (settings.Key)),
                ValidateIssuer = true,
                ValidIssuer = settings.Issuer,
                ValidateAudience = true,
                ValidAudience = settings.Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes (settings.MinutesToExpiration)
                    };
            });

            services.AddIdentityCore<ApplicationUser> (options => { });
            new IdentityBuilder (typeof (ApplicationUser), typeof (ApplicationRole), services)
                .AddRoleManager<RoleManager<ApplicationRole>> ()
                .AddSignInManager<SignInManager<ApplicationUser>> ()
                .AddEntityFrameworkStores<BionicShipmentDatabaseService> ();

            services.AddSwaggerDocument (config => {
                config.PostProcess = document => {
                    document.Info.Version = "v1";
                    document.Info.Title = "Bionic Rent API";
                    document.Info.Description = "API responsible for Rent System";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.SwaggerContact {
                        Name = "Mikael Araya",
                        Email = "Mikaelaraya12@gmail.com",
                        Url = string.Empty
                    };
                    document.Info.License = new NSwag.SwaggerLicense {
                        Name = "Use under LICX",
                        Url = "https://appdiv.com/license"
                    };
                };
            });
            services.AddMediatR (typeof (CreateDriverCommandHandler).GetTypeInfo ().Assembly);

            services.AddTransient (typeof (IPipelineBehavior<,>), typeof (RequestPreProcessorBehavior<,>));
            services.AddTransient (typeof (IPipelineBehavior<,>), typeof (RequestPerformanceBehaviour<,>));
            services.AddTransient (typeof (IPipelineBehavior<,>), typeof (RequestValidationBehavior<,>));

            services.AddCors (options => {
                options.AddPolicy ("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin ().AllowAnyMethod ().AllowAnyHeader ());
            });

            services.AddMvc (
                    options => {

                        /* options.ModelBinderProviders.Insert (0, new CustomModelBinderProvider ()); */
                        options.Filters.Add (typeof (CustomExceptionFilterAttribute));
                        options.OutputFormatters.Clear (); // Disables recurrsive reference of entity framework get requests
                        options.OutputFormatters.Add (new JsonOutputFormatter (new JsonSerializerSettings () {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        }, ArrayPool<char>.Shared));
                    }
                )
                .AddJsonOptions (options => options.SerializerSettings.ContractResolver = new DefaultContractResolver ())
                .SetCompatibilityVersion (CompatibilityVersion.Version_2_2);

            services.Configure<ApiBehaviorOptions> (options => {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.Configure<IdentityOptions> (options => {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 0;
                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes (5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }

            app.UseHttpsRedirection ();
            app.UseMvc ();
        }

        public JwtSettings GetJwtSettings () {
            JwtSettings settings = new JwtSettings ();

            settings.Key = Configuration["JwtSettings:key"];
            settings.Audience = Configuration["JwtSettings:audience"];
            settings.Issuer = Configuration["JwtSettings:issuer"];
            settings.MinutesToExpiration = Convert.ToInt32 (Configuration["JwtSettings:minutesToExpiration"]);

            return settings;
        }

    }

}