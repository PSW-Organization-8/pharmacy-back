using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyClassLib.Model
{
    public class TenderMedication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string MedicationName { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Tender")]
        public long TenderId { get; set; }

        public TenderMedication() { }

        public TenderMedication(string medicationName, int quantity)
        {
            this.MedicationName = medicationName;
            this.Quantity = quantity;
        }

        public TenderMedication(long id, string medicationName, int quantity){
            this.Id = id;
            this.MedicationName=medicationName;
            this.Quantity = quantity;
        }
    }
}