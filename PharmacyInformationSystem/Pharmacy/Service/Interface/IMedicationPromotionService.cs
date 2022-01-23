using PharmacyClassLib.Model.Commercials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLib.Service.Interface
{
    public interface IMedicationPromotionService
    {
        List<MedicationPromotion> Get();

        long AddMedicationPromotion(MedicationPromotion medicationPromotion);

        bool DeletePromotion(long id);
    }
}
