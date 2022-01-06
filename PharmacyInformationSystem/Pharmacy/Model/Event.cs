using PharmacyClassLib.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLib.Model
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        // Store user's id (as a string), username, or email address
        public String UserId { get; set; }
        public DateTime TimeStamp { get; set; }
        public ApplicationName EventApplicationName { get; set; }
        public EventClass EventClass { get; set; }
        public Double OptionalEventNumInfo { get; set; }
        public Double OptionalEventNumInfo2 { get; set; }
        public String OptionalEventStrInfo { get; set; }

        public Event()
        {
            this.TimeStamp = DateTime.Now;
            this.EventClass = EventClass.Other;
            this.EventApplicationName = ApplicationName.PharmacyApp;
        }

        public Event(long id, string userId, ApplicationName eventApplicationName, EventClass eventClass, double optionalEventNumInfo, double optionalEventNumInfo2, string optionalEventStrInfo)
        {
            Id = id;
            TimeStamp = DateTime.Now;
            UserId = userId;
            EventApplicationName = eventApplicationName;
            EventClass = eventClass;
            OptionalEventNumInfo = optionalEventNumInfo;
            OptionalEventNumInfo2 = optionalEventNumInfo2;
            OptionalEventStrInfo = optionalEventStrInfo;
        }

        public Event(long id, string userId, ApplicationName eventApplicationName, EventClass eventClass)
        {
            Id = id;
            TimeStamp = DateTime.Now;
            UserId = userId;
            EventApplicationName = eventApplicationName;
            EventClass = eventClass;
        }
    }
}
