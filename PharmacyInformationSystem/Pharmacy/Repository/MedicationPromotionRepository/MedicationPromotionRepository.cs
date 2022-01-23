using PharmacyClassLib.Model.Commercials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLib.Repository.MedicationPromotionRepository
{
    class MedicationPromotionRepository : AbstractSqlRepository<MedicationPromotion, long>, IMedicationPromotionRepository
    {

        public MedicationPromotionRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
        protected override long GetId(MedicationPromotion entity)
        {
            return entity.Id;
        }
    }
}
