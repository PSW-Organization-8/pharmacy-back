using PharmacyClassLib.Model.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Repository.InventoryLogRepository
{
    public interface IInventoryLogRepository : IGenericRepository<InventoryLog, long>
    {
        List<InventoryLog> GetLogsByPharmacyWithQuantity(long pharmacyId, int quantity);

        List<InventoryLog> GetLogsByMedicationWithQuantity(long medicationId, int quantity);
    }
}
