using PharmacyClassLib.Model;
using PharmacyClassLib.Repository.TenderingRepository;
using PharmacyClassLib.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLib.Service
{
    public class TenderingService : ITenderingService
    {
        private readonly ITenderingRepository tenderingRepository;
        private readonly TenderCommunicationRabbitMQ rabbitMQ;

        public TenderingService(ITenderingRepository tenderingRepository, TenderCommunicationRabbitMQ rabbitMQ)
        {
            this.tenderingRepository = tenderingRepository;
            this.rabbitMQ = rabbitMQ;
        }
        public Tender Create(Tender tender)
        {
           return this.tenderingRepository.Create(tender);
        }

        public Tender Get(long id)
        {
            return this.tenderingRepository.Get(id);
        }

        public List<Tender> GetAll()
        {
            ReceiveTenders();
            return this.tenderingRepository.GetAll();
        }

        private void ReceiveTenders() {
            List<Tender> tenders = rabbitMQ.ReceiveNewTenders();
            foreach (Tender tender in tenders) {
                Create(tender);
            }
        }
        
        public bool Remove(Tender tender)
        {
            return this.tenderingRepository.Delete(tender.Id);
        }

        public Tender Update(Tender tender)
        {
            return this.tenderingRepository.Update(tender);
        }

        public List<Tender> GetAllWithMedication()
        {
            ReceiveTenders();
            return this.tenderingRepository.GetAllWithMedications();
        }
    }
}
