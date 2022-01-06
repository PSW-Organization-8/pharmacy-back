using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLib.Service.Interface
{
    public interface IEventService
    {
        List<Event> GetAll();

        Event Create(Event @event);
    
    }
}
