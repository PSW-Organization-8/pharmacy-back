using PharmacyAPI.Dto;
using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Mapper
{
    public class MedicationMapper
    {
        public static Medication DtoToMedication(MedicationDto dto)
        {
            return new Medication(dto.Id, dto.Name, dto.Manufacturer, dto.Status, dto.Quantity, dto.Usage, dto.Precautions, dto.PotntialDangers);
        }

        public static MedicationDto MedicationToDto(
            Medication medication)
        {
            List<string> medicationIngredients = new List<string>();
            foreach (MedicationIngredient ingredient in medication.MedicationIngredients)
            {
                medicationIngredients.Add(ingredient.Name);
            }
            return new MedicationDto(medication.Id, medication.Name, medication.Manufacturer, medication.Status, medication.Quantity, medication.Usage, medication.Precautions, 
                medication.PotentialDangers, medicationIngredients);
        }
    }
}
