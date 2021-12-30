using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service.Interface
{
    public interface INotificationService
    {
        Notification Add(Notification notification);
        List<Notification> GetAll();
        int GetNumberNotification();
        Notification ReadNotification(Notification p);
    }
}
