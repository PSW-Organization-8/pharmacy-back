using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyClassLib.Model.Relations
{
    public class IngredientInMedication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long MedicationID { get; set; }
        public long IngredientID { get; set; }

        public IngredientInMedication(long id, long medicationID, long ingredientID)
        {
            Id = id;
            MedicationID = medicationID;
            IngredientID = ingredientID;
        }
    }
}
