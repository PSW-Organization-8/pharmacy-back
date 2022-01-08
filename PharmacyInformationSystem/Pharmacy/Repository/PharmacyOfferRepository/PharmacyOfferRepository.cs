using Microsoft.EntityFrameworkCore;
using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmacyClassLib.Repository.PharmacyOfferRepository
{
    public class PharmacyOfferRepository : AbstractSqlRepository<PharmacyOffer, long>, IPharmacyOfferRepository
    {
        public PharmacyOfferRepository(MyDbContext dbContext) : base(dbContext)
        {

        }

        public PharmacyOffer GetOfferWithComponents(long id)
        {
            return context.PharmacyOffers.Include(offer => offer.Components).Where(s => s.Id == id).First();
        }

        protected override long GetId(PharmacyOffer entity)
        {
            return entity.Id;
        }
    }
}
