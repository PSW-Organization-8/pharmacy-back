using PharmacyClassLib.Model.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Repository.InventoryLogRepository
{
    public class InventoryLogRepository : AbstractSqlRepository<InventoryLog, long>, IInventoryLogRepository
    {
        public InventoryLogRepository(MyDbContext dbContext) : base(dbContext)
        {

        }

        protected override long GetId(InventoryLog entity)
        {
            return entity.Id;
        }
    }
}
