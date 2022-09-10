// See https://aka.ms/new-console-template for more information

using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://yezufczr:2HVNGCOOSmA-RvngqRExiMAg1sarftye@toad.rmq.cloudamqp.com/yezufczr");

using var connection = factory.CreateConnection();

var channel = connection.CreateModel();

channel.ExchangeDeclare("logs-fanout", durable: true, type: ExchangeType.Fanout);

Enumerable.Range(1, 50).ToList().ForEach(x =>
{

    string message = $"log {x}";

    var messageBody = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish("logs-fanout", "", null, messageBody);

    Console.WriteLine($"Mesaj gönderilmiştir : {message}");

});



Console.ReadLine();
