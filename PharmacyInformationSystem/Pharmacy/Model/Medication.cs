using PharmacyClassLib.Model.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyClassLib.Model
{
    public class Medication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public MedicineApprovalStatus Status { get; set; }
        public int Quantity { get; set; }
        public string Usage { get; set; }
        public string Precautions { get; set; }
        public string PotentialDangers { get; set; }
        public List<MedicationIngredient> MedicationIngredients { get; set; }

        public Medication(long id, string name, string manufacturer,
            MedicineApprovalStatus status, int quantity, string usage, string precautions, string potentialDangers)
        {
            Id = id;
            Name = name;
            Manufacturer = manufacturer;
            Status = status;
            Quantity = quantity;
            Usage = usage;
            Precautions = precautions;
            PotentialDangers = potentialDangers;
        }

    }
}
