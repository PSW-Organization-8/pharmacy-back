using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLib.Repository.EventRepository
{
    public interface IEventRepository : IGenericRepository<Event, long>
    {
    }
}
