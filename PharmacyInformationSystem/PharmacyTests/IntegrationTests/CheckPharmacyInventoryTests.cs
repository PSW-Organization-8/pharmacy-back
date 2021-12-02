using Moq;
using PharmacyAPI.Controllers;
using PharmacyAPI.Dto;
using PharmacyClassLib;
using PharmacyClassLib.Repository;
using PharmacyClassLib.Repository.IngredientMedicationRepository;
using PharmacyClassLib.Repository.InventoryLogRepository;
using PharmacyClassLib.Repository.MedicationIngredientRepository;
using PharmacyClassLib.Repository.MedicationIngredientsRepository;
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
    public class CheckPharmacyInventoryTests
    {

        [Fact]
        public void Medication_is_available_in_one_pharmacy() 
        {
            InventoryController controller = GetInventoryController();

            List<PharmacyWithInventoryDTO> retVal = controller.CheckQuantity("Ventolin", 25);

            retVal.Count.ShouldBe(1);
        }

        [Fact]
        public void Medication_is_available_in_two_pharmacies()
        {
            InventoryController controller = GetInventoryController();

            List<PharmacyWithInventoryDTO> retVal = controller.CheckQuantity("Synthroid", 15);

            retVal.Count.ShouldBe(2);
        }

        [Fact]
        public void Medication_is_available_in_three_pharmacies()
        {
            InventoryController controller = GetInventoryController();

            List<PharmacyWithInventoryDTO> retVal = controller.CheckQuantity("Synthroid", 5);

            retVal.Count.ShouldBe(3);
        }

        [Fact]
        public void Medication_is_not_available()
        {
            InventoryController controller = GetInventoryController();

            List<PharmacyWithInventoryDTO> retVal = controller.CheckQuantity("Ventolin", 100);

            retVal.Count.ShouldBe(0);
        }

        [Fact]
        public void Medication_does_not_exist()
        {
            InventoryController controller = GetInventoryController();

            List<PharmacyWithInventoryDTO> retVal = controller.CheckQuantity("Brufen", 100);

            retVal.Count.ShouldBe(0);
        }

        [Fact]
        public void Multiple_medications_available()
        {
            InventoryController controller = GetInventoryController();

            List<PharmacyWithInventoryDTO> retVal = controller.CheckQuantity("i", 5);
            PharmacyWithInventoryDTO pharmacy = GetPharmacyWithInventoryById(retVal, 1);
            List<AvailableMedicineDTO> availableMedicines = pharmacy.Medications;

            availableMedicines.Count.ShouldBe(2);
        }

        [Fact]
        public void Medication_is_available()
        {
            InventoryController controller = GetInventoryController();

            bool retVal = controller.CheckIfMedicationExists("Synthroid", 5);

            retVal.ShouldBe(true);
        }

        [Fact]
        public void Medication_is_not_available_in_pharmacy()
        {
            InventoryController controller = GetInventoryController();

            bool retVal = controller.CheckIfMedicationExists("Ventolin", 100);

            retVal.ShouldBe(false);
        }


        private PharmacyWithInventoryDTO GetPharmacyWithInventoryById(List<PharmacyWithInventoryDTO> list, long id) {
            foreach (PharmacyWithInventoryDTO p in list) {
                if (p.Pharmacy.Id == id) {
                    return p;
                }
            }
            return null;
        }

        private InventoryController GetInventoryController()
        {
            MyDbContext dbContext = new MyDbContext();
            IMedicationRepository medicationRepository = new MedicationRepository(dbContext);
            IPharmacyRepository pharmacyRepository = new PharmacyRepository(dbContext);
            IInventoryLogRepository inventoryLogRepository = new InventoryLogRepository(dbContext);
            IMedicationIngredientRepository medicationIngredientRepository = new MedicationIngredientRepository(dbContext);
            IIngredientsInMedicationRepository ingredientsInMedicationRepository = new IngredientsInMedicationRepository(dbContext);
            IIngredientInMedicationService ingredientInMedicationService = new IngredientInMedicationService(ingredientsInMedicationRepository, medicationRepository, medicationIngredientRepository);
            IMedicationIngredientService medicationIngredientService = new MedicationIngredientService(medicationIngredientRepository, ingredientInMedicationService);
            IMedicationService medicationService = new MedicationService(medicationRepository, medicationIngredientService, ingredientInMedicationService);
            IPharmacyService pharmacyService = new PharmacyService(pharmacyRepository);
            IInventoryLogService inventoryLogService = new InventoryLogService(inventoryLogRepository, medicationService, pharmacyService);
            InventoryController controller = new InventoryController(pharmacyService, inventoryLogService, medicationService);
            return controller;
        }
    }
}
