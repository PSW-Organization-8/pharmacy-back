using System;
using Moq;
using PharmacyClassLib;
using PharmacyClassLib.Model;
using PharmacyClassLib.Repository.NewsRepository;
using PharmacyClassLib.Service;
using PharmacyClassLib.Service.Interface;
using Shouldly;
using Xunit;

namespace PharmacyTests.IntegrationTests
{
    public class SendingActionToHospitalsTests
    {
        [Fact]
        public void Sending_news_to_registrated_hospitals()
        {
            INewsRepository newsRepository = new NewsRepository(new MyDbContext());
            var mockSendNews = new Mock<ISendingNewsService>();
            IActionsAndNewsService actionsAndNewsService = new ActionsAndNewsService(newsRepository, mockSendNews.Object);
            DateTime start = new DateTime(2021, 11, 18);
            DateTime end = new DateTime(2021, 11, 29);
            News newNews = new News("Neki naslov", "Mnogo dobra akcija, -50% na sve lekove", start, end);
            
            News createdNews = actionsAndNewsService.CreateAndSendNewsToAllSubscribedHospitals(newNews);

            mockSendNews.Verify(n => n.SendNews(createdNews), Times.Once);
            IsNewsPersistedCorrectly(newsRepository, createdNews).ShouldBeTrue();
            newsRepository.Delete(createdNews.Id);
        }

        private bool IsNewsPersistedCorrectly(INewsRepository newsRepository, News createdNews)
        {
            News newsFromDb = newsRepository.Get(createdNews.Id);
            if (newsFromDb == null)
            {
                return false;
            }
            if (!(newsFromDb.Id.Equals(createdNews.Id) && newsFromDb.Title.Equals(createdNews.Title) &&
                  newsFromDb.Text.Equals(createdNews.Text)))
            {
                return false;
            }

            return true;
        }
    }
}
