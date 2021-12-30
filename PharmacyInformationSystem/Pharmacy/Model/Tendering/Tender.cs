using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLib.Model
{
    public class Tender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }

        public string HospitalName { get; set; }

        public long IdInHospital { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual List<TenderMedication> TenderMedications { get; set; }

        public Tender() { }

        
    }
}
