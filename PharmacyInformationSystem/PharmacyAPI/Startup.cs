using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PharmacyClassLib.Repository;
using PharmacyClassLib.Service;
using PharmacyClassLib;
using Microsoft.EntityFrameworkCore;
using PharmacyClassLib.Repository.MedicationIngredientRepository;
using PharmacyClassLib.Repository.MedicationIngredientsRepository;
using PharmacyClassLib.Repository.RegistratedHospitalRepository;
using PharmacyClassLib.Repository.ObjectionRepository;
using PharmacyClassLib.Repository.IngredientMedicationRepository;
using PharmacyClassLib.Repository.ResponseRepository;
using PharmacyClassLib.Repository.InventoryLogRepository;
using PharmacyClassLib.Service.Interface;

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

            services.AddDbContext<MyDbContext>(options => options.UseNpgsql(x => x.MigrationsAssembly("PharmacyAPI")));

            services.AddTransient<IPharmacyRepository, PharmacyRepository>();
            services.AddTransient<IMedicationIngredientRepository, MedicationIngredientRepository>();
            services.AddTransient<IMedicationRepository, MedicationRepository>();
            services.AddTransient<IRegistratedHospitalRepository, RegistratedHospitalRepository>();
            services.AddTransient<IObjectionRepository, ObjectionRepository>();
            services.AddTransient<IResponseRepository, ResponseRepository>();
            services.AddTransient<IIngredientsInMediactionRepository, IngredientsInMediactionRepository>();
            services.AddTransient<IInventoryLogRepository, InventoryLogRepository>();

            services.AddScoped<IIngredientInMedicationService, IngredientInMedicationService>();
            services.AddScoped<IMedicationService, MedicationService>();
            services.AddScoped<IPharmacyService, PharmacyService>();
            services.AddScoped<IHospitalRegistrationService, HospitalRegistrationService>();
            services.AddScoped<IMedicationIngredientService, MedicationIngredientService>();
            services.AddScoped<IInventoryLogService, InventoryLogService>();
            

            services.AddScoped<ObjectionService>();
            services.AddScoped<ResponseService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
