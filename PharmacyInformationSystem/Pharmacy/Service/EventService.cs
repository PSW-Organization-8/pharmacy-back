using PharmacyClassLib.Model;
using PharmacyClassLib.Repository.EventRepository;
using PharmacyClassLib.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLib.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public Event Create(Event @event)
        {
            return this.eventRepository.Create(@event);
        }

        public List<Event> GetAll()
        {
            return this.eventRepository.GetAll();
        }
    }
}
