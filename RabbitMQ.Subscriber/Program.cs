using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://yezufczr:2HVNGCOOSmA-RvngqRExiMAg1sarftye@toad.rmq.cloudamqp.com/yezufczr");

using var connection = factory.CreateConnection();

var channel = connection.CreateModel();

//channel.QueueDeclare("hello-queue", true, false, false);

var consumer = new EventingBasicConsumer(channel);

channel.BasicConsume("hello-queue", true, consumer);

consumer.Received += (sender, e) =>
{
    var message = Encoding.UTF8.GetString(e.Body.ToArray());

    Console.WriteLine(message);
};

Console.ReadLine();