using PharmacyClassLib.Model;
using PharmacyClassLib.Repository.NotificationRepository;
using PharmacyClassLib.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service
{
    public class NotificationService : INotificationService 
    {
        private readonly INotificationRepository notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            this.notificationRepository = notificationRepository;
        }

        public Notification Add(Notification notification)
        {
            return notificationRepository.Create(notification);
        }
        public List<Notification> GetAll()
        {
            return notificationRepository.GetAll();
        }

        public int GetNumberNotification()
        {
            int number = 0;
            List<Notification> notifications=notificationRepository.GetAll();
            foreach(Notification notification in notifications)
            {
                if (!notification.Read) number++;
            }
            return number;
        }
        public Notification ReadNotification(Notification notification)
        {
            notification.Read = true;
            return notificationRepository.Update(notification);
        }
    }
}
