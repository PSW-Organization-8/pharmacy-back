using PharmacyAPI.Dto;
using PharmacyAPI.Protos;
using PharmacyClassLib.Model;
using PharmacyClassLib.Model.Relations;
using System.Collections.Generic;
using System.Linq;

namespace PharmacyAPI.Mapper
{
    public class PharmacyWithInventoryMapper
    {

        public static PharmacyWithInventoryDTO PharmacyAndInventoryToPharmacyWithInventory(DataForMapperDTO dataForMapper)
        {
            List<AvailableMedicineDTO> availableMedication = new List<AvailableMedicineDTO>();
            foreach (Medication medication in dataForMapper.Medications)
            {
                if (CheckIfMedicationIsAvailable(medication.Id, dataForMapper.InventoryLogs))
                {
                    AvailableMedicineDTO medicationForCheck = new AvailableMedicineDTO(medication.Name, medication.Id);
                    availableMedication.Add(medicationForCheck);
                }
            }
            if (availableMedication.Count != 0)
            {
                return new PharmacyWithInventoryDTO(dataForMapper.Pharmacy, availableMedication);
            }
            return null;
        }

        private static bool CheckIfMedicationIsAvailable(long id, List<InventoryLog> inventoryLogs)
        {
            foreach (InventoryLog inventoryLog in inventoryLogs)
            {
                if (inventoryLog.MedicationID == id)
                {
                    return true;
                }
            }
            return false;
        }

        public static MedicationAvailabilityProto PharmacyAndInventoryToPharmacyWithInventoryGrpc(DataForMapperDTO dataForMapper)
        {
            MedicationAvailabilityProto retVal = new MedicationAvailabilityProto() { Pharmacy = new PharmacyProto { Id = dataForMapper.Pharmacy.Id, Name = dataForMapper.Pharmacy.Name, Adress = dataForMapper.Pharmacy.Adress, AdressNumber = dataForMapper.Pharmacy.AdressNumber, City = dataForMapper.Pharmacy.City } };
            
            foreach (Medication medication in dataForMapper.Medications)
            {
                if (CheckIfMedicationIsAvailable(medication.Id, dataForMapper.InventoryLogs))
                {
                    AvailableMedicineProto medicationForCheck = new AvailableMedicineProto() { Name=medication.Name,Id=medication.Id };
                    retVal.Medications.Add(medicationForCheck);
                }
            }
            if (retVal.Medications.Count != 0)
            {
                return retVal;
            }
            return null;
        }
    }
}
