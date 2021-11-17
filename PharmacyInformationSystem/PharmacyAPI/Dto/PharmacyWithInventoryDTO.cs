using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Dto
{
    public class PharmacyWithInventoryDTO
    {
        public Pharmacy Pharmacy { get; set; }
        public List<AvailableMedicineDTO> Medications { get; set;}

        public PharmacyWithInventoryDTO() { }
        public PharmacyWithInventoryDTO(Pharmacy pharmacy, List<AvailableMedicineDTO> medications) {
            this.Pharmacy = pharmacy;
            this.Medications = medications;
        }
    }
}
