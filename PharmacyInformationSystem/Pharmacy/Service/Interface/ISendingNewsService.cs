using System;
using System.Collections.Generic;
using System.Text;
using PharmacyClassLib.Model;

namespace PharmacyClassLib.Service.Interface
{
    public interface ISendingNewsService
    {
        void SendNews(News newNews);
    }
}
