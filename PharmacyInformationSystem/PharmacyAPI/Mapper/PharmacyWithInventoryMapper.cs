using PharmacyAPI.Dto;
using PharmacyClassLib.Model;
using PharmacyClassLib.Model.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Mapper
{
    public class PharmacyWithInventoryMapper
    {
        
        public static PharmacyWithInventoryDTO PharmacyAndInventoryToPharmacyWithInventory(DataForMapperDTO dataForMapper) {
            List<AvailableMedicineDTO> availableMedication = new List<AvailableMedicineDTO>();
            foreach (Medication medication in dataForMapper.Medications) {
                if (CheckIfMedicationIsAvailable(medication.Id, dataForMapper.InventoryLogs)) {
                    AvailableMedicineDTO medicationForCheck = new AvailableMedicineDTO(medication.Name, medication.Id);
                    availableMedication.Add(medicationForCheck);
                }
            }
            if (availableMedication.Count != 0) {
                return new PharmacyWithInventoryDTO(dataForMapper.Pharmacy, availableMedication);
            }
            return null;
        }

        private static bool CheckIfMedicationIsAvailable(long id, List<InventoryLog> inventoryLogs)
        {
            foreach (InventoryLog inventoryLog in inventoryLogs){
                if (inventoryLog.MedicationID == id) {
                    return true;
                }
            }
            return false;
        }



    }
}
