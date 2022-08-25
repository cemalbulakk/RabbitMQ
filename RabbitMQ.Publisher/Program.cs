// See https://aka.ms/new-console-template for more information

using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://yezufczr:2HVNGCOOSmA-RvngqRExiMAg1sarftye@toad.rmq.cloudamqp.com/yezufczr");

using var connection = factory.CreateConnection();

var channel = connection.CreateModel();

channel.QueueDeclare("hello-queue", true, false, false);

string message = "hello world";

var messageBody = Encoding.UTF8.GetBytes(message);

for (int i = 1; i <= 5; i++)
{
    channel.BasicPublish(string.Empty, "hello-queue", false, null, messageBody);

    Console.WriteLine($"{i}. Mesaj gönderilmiştir.");
    Console.ReadLine();
}