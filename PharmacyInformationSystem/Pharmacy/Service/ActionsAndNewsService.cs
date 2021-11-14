using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Text;
using PharmacyClassLib.Repository.NewsRepository;
using PharmacyClassLib.Repository.RegistratedHospitalRepository;
using PharmacyClassLib.Service.Interface;

namespace PharmacyClassLib.Service
{
    public class ActionsAndNewsService : IActionsAndNewsService
    {
        private readonly INewsRepository newsRepository;
        private readonly ISendingNewsService sendingNewsService;

        public ActionsAndNewsService(INewsRepository newsRepository, ISendingNewsService sendingNewsService)
        {
            this.newsRepository = newsRepository;
            this.sendingNewsService = sendingNewsService;
        }

        public News CreateAndSendNewsToAllSubscribedHospitals(News newNews)
        {
            News cretedNews = newsRepository.Create(newNews);
            sendingNewsService.SendNews(cretedNews);
            return cretedNews;
        }
    }
}
