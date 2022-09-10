// See https://aka.ms/new-console-template for more information

using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory();
factory.Uri = new Uri("");

using var connection = factory.CreateConnection();

var channel = connection.CreateModel();

channel.QueueDeclare("hello-queue", true, false, false);

foreach (var x in Enumerable.Range(1, 50))
{
    string message = "hello world";

    var messageBody = Encoding.UTF8.GetBytes(message);
    channel.BasicPublish(string.Empty, "hello-queue", false, null, messageBody);

    Console.WriteLine($"{x}. Mesaj gönderilmiştir.");
}
