using PharmacyClassLib.Model.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmacyClassLib.Repository.InventoryLogRepository
{
    public class InventoryLogRepository : AbstractSqlRepository<InventoryLog, long>, IInventoryLogRepository
    {
        public InventoryLogRepository(MyDbContext dbContext) : base(dbContext)
        {

        }

        public List<InventoryLog> GetLogsByPharmacyWithQuantity(long pharmacyId, int quantity)
        {
            var inventoryLog = context.InventoryLogs.Where(s => s.PharmacyID.Equals(pharmacyId) && s.Quantity >= quantity).ToList();
            return inventoryLog;
        }

        protected override long GetId(InventoryLog entity)
        {
            return entity.Id;
        }
    }
}
