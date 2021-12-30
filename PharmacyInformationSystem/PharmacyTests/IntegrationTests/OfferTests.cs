using PharmacyAPI.Controllers;
using PharmacyAPI.Dto;
using PharmacyClassLib;
using PharmacyClassLib.Model;
using PharmacyClassLib.Repository;
using PharmacyClassLib.Repository.IngredientMedicationRepository;
using PharmacyClassLib.Repository.InventoryLogRepository;
using PharmacyClassLib.Repository.MedicationIngredientRepository;
using PharmacyClassLib.Repository.MedicationIngredientsRepository;
using PharmacyClassLib.Repository.PharmacyOfferRepository;
using PharmacyClassLib.Repository.RegistratedHospitalRepository;
using PharmacyClassLib.Service;
using PharmacyClassLib.Service.Interface;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PharmacyTests.IntegrationTests
{
    public class OfferTests
    {
        /*(private PharmacyOfferController GetOfferController()
        {
            MyDbContext dbContext = new MyDbContext();

            IPharmacyRepository pharmacyRepository = new PharmacyRepository(dbContext);
            IPharmacyOfferRepository pharmacyOfferRepository = new PharmacyOfferRepository(dbContext);
            IPharmacyOfferComponentRepository pharmacyOfferComponentRepository = new PharmacyOfferComponentRepository(dbContext);
            IMedicationRepository medicationRepository = new MedicationRepository(dbContext);
            IRegisteredHospitalRepository regHospitalRepository = new RegisteredHospitalRepository(dbContext);
            IMedicationIngredientRepository ingredientRepository = new MedicationIngredientRepository(dbContext);
            IIngredientsInMedicationRepository ingredientsInMedicationRepository = new IngredientsInMedicationRepository(dbContext);
            IInventoryLogRepository logRepository = new InventoryLogRepository(dbContext);

            IIngredientInMedicationService ingredientInMedicationService = new IngredientInMedicationService(ingredientsInMedicationRepository, medicationRepository, ingredientRepository);
            ISendingNewsService sendingNewsService = new SendingNewsRabbitMQService();

            IMedicationService medicationService = new MedicationService(medicationRepository, ingredientInMedicationService, pharmacyOfferComponentRepository);
            IPharmacyService pharmacyService = new PharmacyService(pharmacyRepository);
            IHospitalRegistrationService hospitalService = new HospitalRegistrationService(regHospitalRepository, sendingNewsService);
            IInventoryLogService inventoryLogService = new InventoryLogService(logRepository, medicationService, pharmacyService);

            IPharmacyOfferService pharmacyOfferService = new PharmacyOfferService(pharmacyOfferRepository, pharmacyOfferComponentRepository, medicationService, pharmacyService, hospitalService, inventoryLogService);
            
            PharmacyOfferController controller = new PharmacyOfferController(pharmacyOfferService, pharmacyService);
            return controller;
        }

        [Fact]
        public void Offer_does_not_exist()
        {
            PharmacyOfferController controller = GetOfferController();

            PharmacyOfferViewDTO retVal = controller.Get(999);

            retVal.ShouldBe(null);
        }

        [Fact]
        public void Offer_does_exist()
        {
            PharmacyOfferController controller = GetOfferController();

            PharmacyOfferViewDTO retVal = controller.Get(1);

            retVal.ShouldNotBe(null);
        }

        [Fact]
        public void Cant_create_offer()
        {
            PharmacyOfferController controller = GetOfferController();
            PharmacyOfferDTO dto = new PharmacyOfferDTO
            {
                OfferIdentification = 1,
                PharmacyId = 999,
                Price = 40,
                IsChosen = false,
                HospitalName = "bolnica55"
            };

            PharmacyOffer retVal = controller.Create(dto);

            retVal.ShouldBe(null);
        } */


    }
}
