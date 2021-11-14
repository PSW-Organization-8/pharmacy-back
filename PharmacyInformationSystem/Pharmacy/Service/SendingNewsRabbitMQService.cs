using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using PharmacyClassLib.Model;
using PharmacyClassLib.Service.Interface;
using RabbitMQ.Client;

namespace PharmacyClassLib.Service
{
    public class SendingNewsRabbitMQService : ISendingNewsService
    {
        public void SendNews(News newNews)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "newsExchange", type: ExchangeType.Fanout);

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(newNews));
                channel.BasicPublish(exchange: "newsExchange",
                    routingKey: "",
                    basicProperties: null,
                    body: body);
            }
        }
    }
}
