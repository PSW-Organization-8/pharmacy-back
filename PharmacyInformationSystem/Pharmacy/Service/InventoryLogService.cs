using PharmacyClassLib.Model;
using PharmacyClassLib.Model.Relations;
using PharmacyClassLib.Repository.InventoryLogRepository;
using PharmacyClassLib.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service
{
    public class InventoryLogService : IInventoryLogService
    {
        private readonly IInventoryLogRepository logRepository;
        private readonly IMedicationService medicationService;
        private readonly IPharmacyService pharmacyService;

        public InventoryLogService(IInventoryLogRepository logRepository, IMedicationService medicationService, IPharmacyService pharmacyService)
        {
            this.logRepository = logRepository;
            this.medicationService = medicationService;
            this.pharmacyService = pharmacyService;
        }

        public bool AddMedication(long pharmacyID, long medicationID, long quantity)
        {
            bool success = false;
            Medication medication = medicationService.Get(medicationID);
            Pharmacy pharmacy = pharmacyService.Get(pharmacyID);

            if (medication != null && pharmacy != null)
            {
                success = true;
                InventoryLog log = GetLogByPharmacyAndMedication(pharmacyID, medicationID);
                if (log == null)
                {
                    log = new InventoryLog(0, pharmacyID, medicationID, quantity);
                    logRepository.Create(log);
                } else
                {
                    log.Quantity += quantity;
                    logRepository.Update(log);
                }

            }

            return success;
        }

        private InventoryLog GetLogByPharmacyAndMedication(long pharmacyID, long medicationID)
        {
            InventoryLog log = null;
            foreach (InventoryLog currentLog in logRepository.GetAll())
            {
                if (currentLog.MedicationID == medicationID && currentLog.PharmacyID == pharmacyID)
                {
                    log = currentLog;
                    break;
                }
            }

            return log;
        }


        public bool RemoveMedication(long pharmacyID, long medicationID, long quantity)
        {
            bool success = false;
            Medication medication = medicationService.Get(medicationID);
            Pharmacy pharmacy = pharmacyService.Get(pharmacyID);

            if (medication != null && pharmacy != null)
            {
                InventoryLog log = GetLogByPharmacyAndMedication(pharmacyID, medicationID);
                if (log != null && log.Quantity >= quantity)
                {
                    success = true;
                    log.Quantity -= quantity;
                    logRepository.Update(log);
                }
            }

            return success;
        }

        public List<MedicationDistribution> GetMedicationDistribution(long id)
        {
            List<MedicationDistribution> distribution = new List<MedicationDistribution>();
            foreach (InventoryLog log in logRepository.GetAll())
            {
                if (log.MedicationID == id)
                {
                    Pharmacy pharmacy = pharmacyService.Get(log.MedicationID);
                    distribution.Add(new MedicationDistribution(pharmacy, log.Quantity));
                }
            }
            return distribution;
        }

        public List<InventoryItem> GetPharmacyInventory(long id)
        {
            List<InventoryItem> inventory = new List<InventoryItem>();
            foreach (InventoryLog log in logRepository.GetAll())
            {
                if (log.PharmacyID == id)
                {
                    Medication medication = medicationService.Get(log.MedicationID);
                    inventory.Add(new InventoryItem(medication, log.Quantity));
                }
            }
            return inventory;
        }

        public void RemoveMedicineReferences(long id)
        {
            foreach (InventoryLog entity in logRepository.GetAll())
            {
                if (entity.MedicationID == id)
                {
                    logRepository.Delete(entity.Id);
                }
            }
        }

        public void RemovePharmacyReferences(long id)
        {
            foreach (InventoryLog entity in logRepository.GetAll())
            {
                if (entity.PharmacyID == id)
                {
                    logRepository.Delete(entity.Id);
                }
            }
        }
    }
}
