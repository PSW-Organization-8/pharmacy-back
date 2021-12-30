using PharmacyAPI.Dto;
using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Mapper
{
    public class NotificationMapper
    {
        public Notification NotificationDTOToNotification(NotificationDTO dto)
        {
            return new Notification(dto.Id,dto.Title,dto.Read,dto.ContentNotification,dto.FileName);
        }
    }
}
