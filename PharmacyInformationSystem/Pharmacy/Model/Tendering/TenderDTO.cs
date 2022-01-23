using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLib.Model.Tendering
{
    public class TenderDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string HospitalName { get; set; }

        public long IdInHospital { get; set; }

        public DateRange DateRange { get; set; }

        public virtual List<TenderMedication> TenderMedications { get; set; }

        public TenderDTO() { }
    }
}
