using PharmacyClassLib.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Dto
{
    public class MedicationDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public MedicineApprovalStatus Status { get; set; }
        public int Quantity { get; set; }
        public string Usage { get; set; }
        public string Precautions { get; set; }
        public string PotntialDangers { get; set; }
        public ICollection<String> MedicationIngredients { get; set; }

        public MedicationDto() { }

        public MedicationDto(long id, string name, string manufacturer, MedicineApprovalStatus status, int quantity, string usage, string precautions, string potntialDangers, ICollection<string> medicationIngredients)
        {
            Id = id;
            Name = name;
            Manufacturer = manufacturer;
            Status = status;
            Quantity = quantity;
            Usage = usage;
            Precautions = precautions;
            PotntialDangers = potntialDangers;
            MedicationIngredients = medicationIngredients;
        }
    }


}
