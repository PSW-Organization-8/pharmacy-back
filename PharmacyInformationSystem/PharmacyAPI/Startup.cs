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
using Grpc.Core;
using PharmacyAPI.Protos;
using PharmacyAPI;
using PharmacyAPI.Controllers;
using PharmacyAPI.Filters;

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

        private Server server;

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            MyDbContext dbContext = new MyDbContext();
            IPharmacyService pharmacyService = new PharmacyService(new PharmacyRepository(dbContext));
            IMedicationService medicationService = new MedicationService(new MedicationRepository(dbContext), new MedicationIngredientService(new MedicationIngredientRepository(dbContext), new IngredientInMedicationService(new IngredientsInMedicationRepository(dbContext), new MedicationRepository(dbContext), new MedicationIngredientRepository(dbContext))), new IngredientInMedicationService(new IngredientsInMedicationRepository(dbContext), new MedicationRepository(dbContext), new MedicationIngredientRepository(dbContext)));
            IInventoryLogService inventoryLogService = new InventoryLogService(new InventoryLogRepository(dbContext), medicationService, pharmacyService);
            GrpcApiKeyFilter grpcApiKeyFilter = new GrpcApiKeyFilter(new RegisteredHospitalRepository(dbContext));
            server = new Server
            {
                Services = { MedicationGrpcService.BindService(new MedicationGrpcController(pharmacyService, inventoryLogService, medicationService, grpcApiKeyFilter)) },
                Ports = { new ServerPort("localhost", 4111, ServerCredentials.Insecure) }
            };
            server.Start();

            applicationLifetime.ApplicationStopping.Register(OnShutDown);
        }

        private void OnShutDown()
        {
            if(server != null)
            {
                server.ShutdownAsync().Wait();
            }
        }
    }
}
