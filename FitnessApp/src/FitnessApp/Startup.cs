using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FitnessApp.Data;
using FitnessApp.Models;
using FitnessApp.Services;
using FitnessApp.Logic;
using FitnessApp.Repository;
using FitnessApp.IRepository;

namespace FitnessApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            var connection = @"Server=localhost\SQLEXPRESS;Database=FITNESS_APP;Integrated Security=True;MultipleActiveResultSets=True;";
            services.AddDbContext<FitnessAppDbContext>(options => options.UseSqlServer(connection));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<FitnessAppDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            //Repository Services
            services.AddTransient<IFitnessClassRepository, FitnessClassRepository>();
            services.AddTransient<IFitnessClassTypeRepository, FitnessClassTypeRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IRegistrationRecordRepository, RegistrationRecordRepository>();

            //Logic services
            services.AddTransient<IFitnessClassLogic, FitnessClassLogic>();
            services.AddTransient<IFitnessClassTypeLogic, FitnessClassTypeLogic>();
            services.AddTransient<IInstructorLogic, InstructorLogic>();
            services.AddTransient<ILocationLogic, LocationLogic>();
            services.AddTransient<IRegistrationRecordLogic, RegistrationRecordLogic>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=FitnessClasses}/{action=Index}/{id?}");
            });
        }
    }
}
