using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyClassLib.Model;
using PharmacyClassLib.Repository.RegistratedHospitalRepository;
using PharmacyClassLib.Service.Interface;
using RabbitMQ.Client;

namespace PharmacyClassLib.Service
{
    public class RabbitMQChannelsForCommunication : IChannelsForCommunication
    {
        private IRegisteredHospitalRepository registeredHospitalRepository;
        private readonly string _hostName = Environment.GetEnvironmentVariable("RabbitHostName") ?? "localhost";

        public RabbitMQChannelsForCommunication(IRegisteredHospitalRepository registeredHospitalRepository)
        {
            this.registeredHospitalRepository = registeredHospitalRepository;
        }

        public void CreateChannelsForHospital(RegisteredHospital hospital)
        {
            CreateChannelForSendingActionsAndNews(hospital);
            CreateChannelForSendingTenderOffers(hospital);
        }

        public void CreateAllChannels()
        {
            CreateAllChannelsWithAllHospitals();
        }

        private void CreateAllChannelsWithAllHospitals()
        {
            foreach (RegisteredHospital hospital in registeredHospitalRepository.GetAll())
            {
                CreateChannelsForHospital(hospital);
            }
        }

        private void CreateChannelForSendingActionsAndNews(RegisteredHospital hospital)
        {
            var factory = new ConnectionFactory() { HostName = _hostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "newsExchange", type: ExchangeType.Fanout);

                channel.QueueDeclare(queue: hospital.Name,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                channel.QueueBind(queue: hospital.Name,
                    exchange: "newsExchange",
                    routingKey: "");
            }
        }

        private void CreateChannelForSendingTenderOffers(RegisteredHospital hospital)
        {
            var factory = new ConnectionFactory() { HostName = _hostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "tenderOfferExchange", type: ExchangeType.Fanout);

                channel.QueueDeclare(queue: hospital.Name + "TenderOffer",
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                channel.QueueBind(queue: hospital.Name + "TenderOffer",
                    exchange: "tenderOfferExchange",
                    routingKey: "");
            }
        }
    }
}
