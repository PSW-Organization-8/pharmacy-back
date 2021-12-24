using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PharmacyClassLib.Model;

namespace PharmacyClassLib.Service
{
    public class TenderCommunicationRabbitMQ
    {
        private readonly string _hostName = Environment.GetEnvironmentVariable("RabbitHostName") ?? "localhost";
        private readonly string _pharmacyName = "Apoteka1";

        public List<Tender> ReceiveNewTenders()
        {
            List<Tender> receivedTenders = new List<Tender>();
            var factory = new ConnectionFactory() { HostName = _hostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "newTendersExchange", type: ExchangeType.Fanout);

                Tender newTender = null;
                do
                {
                    var basicGetResult = channel.BasicGet(_pharmacyName, true);
                    if (basicGetResult == null)
                    {
                        newTender = null;
                        continue;
                    }
                    var body = basicGetResult.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Tender arrivedTender = JsonConvert.DeserializeObject<Tender>(message);

                    newTender = new Tender()
                    {
                        Name = arrivedTender.Name,
                        HospitalName = arrivedTender.HospitalName,
                        IdInHospital = arrivedTender.Id,
                        StartDate = arrivedTender.StartDate,
                        EndDate = arrivedTender.EndDate,
                        TenderMedications = CreateTenderMedications(arrivedTender)
                    };

                    receivedTenders.Add(newTender);
                    System.Diagnostics.Debug.WriteLine(newTender);
                } while (newTender != null);
            }

            return receivedTenders;
        }

        public void SendTenderOfferToAppropriateHospital(PharmacyOffer pharmacyOffer)
        {
            var factory = new ConnectionFactory() { HostName = _hostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "tenderOfferExchange", type: ExchangeType.Fanout);

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(pharmacyOffer));
                channel.BasicPublish(exchange: "tenderOfferExchange",
                    routingKey: pharmacyOffer.HospitalName + "TenderOffer",
                    basicProperties: null,
                    body: body);
            }
        }

        private static List<TenderMedication> CreateTenderMedications(Tender arrivedTender)
        {
            List<TenderMedication> tenderMedications = new();
            foreach (TenderMedication medication in arrivedTender.TenderMedications)
            {
                TenderMedication tenderMedication = new TenderMedication(medication.MedicationName, medication.Quantity);
                tenderMedications.Add(tenderMedication);
            }

            return tenderMedications;
        }
    }
}
