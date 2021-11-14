using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service.Interface
{
    public interface IInventoryLogService
    {
        List<InventoryItem> GetPharmacyInventory(long id);

        List<MedicationDistribution> GetMedicationDistribution(long id);

        void RemoveMedicineReferences(long id);

        void RemovePharmacyReferences(long id);

        bool AddMedication(long pharmacyID, long medicationID, long quantity);

        bool RemoveMedication(long pharmacyID, long medicationID, long quantity);
    }
}
