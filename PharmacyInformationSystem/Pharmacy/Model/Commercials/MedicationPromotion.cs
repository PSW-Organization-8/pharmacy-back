using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLib.Model.Commercials
{
    public class MedicationPromotion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public String Title { get; set; }
        public String Description {get;set;}
        public virtual List<Medication> PromotedMedications { get; set; }
        public DateRange PromotionPeriod { get; set; }


        public MedicationPromotion()
        {

        }

        public MedicationPromotion(long id,String title,String description,List<Medication> medications,DateTime startDate,DateTime endDate)
        {
            Id = id;
            Title = title;
            Description = description;
            PromotedMedications = medications;
            PromotionPeriod = new DateRange(startDate, endDate);
        }
    }
}
