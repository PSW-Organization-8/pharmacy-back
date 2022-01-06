using PharmacyAPI.Controllers;
using PharmacyClassLib;
using PharmacyClassLib.Model;
using PharmacyClassLib.Repository.EventRepository;
using PharmacyClassLib.Service;
using PharmacyClassLib.Service.Interface;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PharmacyTests.IntegrationTests
{
    public class EventTests
    {
        [Fact]
        public void Events_do_exist()
        {
            EventController controller = GetEventController();
            List<Event> retVal = controller.GetAll();
            retVal.Count.ShouldNotBe(0);
        }

        private EventController GetEventController()
        {
            EventsDbContext dbContext = new EventsDbContext();
            IEventRepository eventRepository = new EventRepository(dbContext);
            IEventService eventService = new EventService(eventRepository);
            EventController eventController = new EventController(eventService);

            return eventController;
        }

    }
}
