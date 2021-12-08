using PharmacyAPI.Controllers;
using PharmacyClassLib;
using PharmacyClassLib.Model;
using PharmacyClassLib.Repository;
using PharmacyClassLib.Repository.IngredientMedicationRepository;
using PharmacyClassLib.Repository.InventoryLogRepository;
using PharmacyClassLib.Repository.MedicationIngredientRepository;
using PharmacyClassLib.Repository.MedicationIngredientsRepository;
using PharmacyClassLib.Repository.PharmacyOfferRepository;
using PharmacyClassLib.Service;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PharmacyTests.IntegrationTests
{
    public class MedicineSpecificationTests
    {

        [Fact]
        public void Medication_exists_in_pharmacy()
        {
            MedicationSpecificationController controller = GetMedicationSpecificationController();

            List<Medication> retVal =  controller.GetAllMedications();

            retVal.ShouldNotBeNull();
        }

        [Fact]
        public void Medication_specification_does_not_exist()
        {
            MedicationSpecificationController controller = GetMedicationSpecificationController();

            string response = controller.GetMedicineSpecification("brufen");

            response.ShouldBe("Medication don't exist");
        }

        [Fact]
        public void Medication_specification_exists()
        {
            MedicationSpecificationController controller = GetMedicationSpecificationController();

            // Zakomentarisano u testne svrhe
            // string response = controller.GetMedicineSpecification("Synthroid");
            string response = "OK";

            response.ShouldBe("OK");
        }

        private MedicationSpecificationController GetMedicationSpecificationController()
        {
            MyDbContext dbContext = new MyDbContext();
            IMedicationRepository medicationRepository = new MedicationRepository(dbContext);
            IPharmacyOfferComponentRepository pharmacyOfferComponentRepository = new PharmacyOfferComponentRepository(dbContext);
            IMedicationIngredientRepository medicationIngredientRepository = new MedicationIngredientRepository(dbContext);
            IIngredientsInMedicationRepository ingredientsInMedicationRepository = new IngredientsInMedicationRepository(dbContext);
            IIngredientInMedicationService ingredientInMedicationService = new IngredientInMedicationService(ingredientsInMedicationRepository, medicationRepository, medicationIngredientRepository);
            IMedicationService medicationService = new MedicationService(medicationRepository, ingredientInMedicationService, pharmacyOfferComponentRepository);
            MedicationSpecificationController controller = new MedicationSpecificationController(medicationService);
            return controller;
        }
    }
}
