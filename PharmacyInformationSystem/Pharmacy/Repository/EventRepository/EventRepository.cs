using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLib.Repository.EventRepository
{
    public class EventRepository : AbstractSqlEventRepository<Event, long>, IEventRepository
    {
        public EventRepository(EventsDbContext dbContext) : base(dbContext)
        {

        }

        protected override long GetId(Event entity)
        {
            return entity.Id;
        }
    }
}
