using PharmacyClassLib.Model;
using PharmacyClassLib.Model.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Dto
{
    public class DataForMapperDTO
    {
        public List<Medication> Medications { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public List<InventoryLog> InventoryLogs { get; set; }

        public DataForMapperDTO() { }

        public DataForMapperDTO(List<Medication> medications, Pharmacy pharmacy, List<InventoryLog> inventoryLogs)
        {
            this.Medications = medications;
            this.Pharmacy = pharmacy;
            this.InventoryLogs = inventoryLogs;
        } 
    }
}
