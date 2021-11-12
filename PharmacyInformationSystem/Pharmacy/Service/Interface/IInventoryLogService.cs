using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service.Interface
{
    public interface IInventoryLogService
    {
        public List<InventoryItem> GetPharmacyInventory(long id);

        public List<MedicationDistribution> GetMedicationDistribution(long id);

        public void RemoveMedicineReferences(long id);

        public void RemovePharmacyReferences(long id);

        public bool AddMedication(long pharmacyID, long medicationID, long quantity);

        public bool RemoveMedication(long pharmacyID, long medicationID, long quantity);
    }
}
