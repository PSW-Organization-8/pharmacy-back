using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Dto
{
    public class MedicationSearchFilterDto
    {
        public string Text { get; set; }
        public List<String> Ingredients { get; set; }

        public MedicationSearchFilterDto() 
        {         
        }

        public MedicationSearchFilterDto(string text, List<string> ingredients)
        {
            Text = text;
            Ingredients = ingredients;
        }
    }
}
