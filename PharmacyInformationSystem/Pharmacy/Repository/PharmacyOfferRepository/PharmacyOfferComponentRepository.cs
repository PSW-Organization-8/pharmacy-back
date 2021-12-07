using PharmacyClassLib.Model.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Repository.PharmacyOfferRepository
{
    public class PharmacyOfferComponentRepository : AbstractSqlRepository<PharmacyOfferComponent, long>, IPharmacyOfferComponentRepository
    {
        public PharmacyOfferComponentRepository(MyDbContext dbContext) : base(dbContext)
        {

        }

        protected override long GetId(PharmacyOfferComponent entity)
        {
            return entity.Id;
        }
    }
}
