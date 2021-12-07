using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Repository.PharmacyOfferRepository
{
    public class PharmacyOfferRepository : AbstractSqlRepository<PharmacyOffer, long>, IPharmacyOfferRepository
    {
        public PharmacyOfferRepository(MyDbContext dbContext) : base(dbContext)
        {

        }

        protected override long GetId(PharmacyOffer entity)
        {
            return entity.Id;
        }
    }
}
