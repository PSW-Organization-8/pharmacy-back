using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PharmacyClassLib.Repository;
using PharmacyClassLib.Service;
using PharmacyClassLib;
using Microsoft.EntityFrameworkCore;
using PharmacyClassLib.Model;
using PharmacyClassLib.Repository.MedicationIngredientRepository;
using PharmacyClassLib.Repository.MedicationIngredientsRepository;
using PharmacyClassLib.Repository.RegistratedHospitalRepository;
using PharmacyClassLib.Repository.ObjectionRepository;
using PharmacyClassLib.Repository.IngredientMedicationRepository;
using PharmacyClassLib.Repository.ResponseRepository;
using PharmacyClassLib.Repository.InventoryLogRepository;
using PharmacyClassLib.Repository.NewsRepository;
using PharmacyClassLib.Service.Interface;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace WebApplication1
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

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddMvc();

            services.AddDbContext<MyDbContext>(options => options.UseNpgsql(x => x.MigrationsAssembly("PharmacyAPI")));

            services.AddTransient<IPharmacyRepository, PharmacyRepository>();
            services.AddTransient<IMedicationIngredientRepository, MedicationIngredientRepository>();
            services.AddTransient<IMedicationRepository, MedicationRepository>();
            services.AddTransient<IRegisteredHospitalRepository, RegisteredHospitalRepository>();
            services.AddTransient<IObjectionRepository, ObjectionRepository>();
            services.AddTransient<IResponseRepository, ResponseRepository>();
            services.AddTransient<IIngredientsInMedicationRepository, IngredientsInMedicationRepository>();
            services.AddTransient<IInventoryLogRepository, InventoryLogRepository>();
            services.AddTransient<INewsRepository, NewsRepository>();

            services.AddScoped<IIngredientInMedicationService, IngredientInMedicationService>();
            services.AddScoped<IMedicationService, MedicationService>();
            services.AddScoped<IPharmacyService, PharmacyService>();
            services.AddScoped<IHospitalRegistrationService, HospitalRegistrationService>();
            services.AddScoped<IMedicationIngredientService, MedicationIngredientService>();
            services.AddScoped<IInventoryLogService, InventoryLogService>();       
            services.AddScoped<IObjectionService, ObjectionService>();
            services.AddScoped<IResponseService, ResponseService>();
            services.AddScoped<IActionsAndNewsService, ActionsAndNewsService>();
            services.AddScoped<ISendingNewsService, SendingNewsRabbitMQService>();
            services.AddScoped<MedicationConsumptionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<MyDbContext>())
            {
                

                RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>();

                try
                {
                    context.Database.Migrate();
                }
                catch (Exception)
                {
                    Console.WriteLine("Failed to execute migration");
                }
                
               
            }
            app.UseRouting();

            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
