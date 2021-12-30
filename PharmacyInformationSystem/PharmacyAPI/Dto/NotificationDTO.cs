using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Dto
{
    public class NotificationDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool Read { get; set; }
        public string ContentNotification { get; set; }
        public string FileName { get; set; }

        public NotificationDTO() { }

        public NotificationDTO(string title, bool read, string contents, string files)
        {
          
            Title = title;
            Read = read;
            ContentNotification = contents;
            FileName = files;
        }
        public NotificationDTO(long id,string title, bool read, string contents, string files)
        {
            Id = id;
            Title = title;
            Read = read;
            ContentNotification = contents;
            FileName = files;
        }

    }
}
