using System;
using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory();

factory.Uri = new Uri("amqps://kqrijscj:ekQcnDbu67XtUacb28LLNsRfjCdwFbQ0@roedeer.rmq.cloudamqp.com/kqrijscj");

using var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.QueueDeclare("numbers", true, false, false);

var random = new Random();;

for (int i = 0; i < 10; i++)
{
    string message = random.Next(0, 100).ToString();
    var messageBody = Encoding.UTF8.GetBytes(message);
    channel.BasicPublish(String.Empty, "numbers", null, messageBody);
    Console.WriteLine($"Sended: {message}");
    Thread.Sleep(2000);
}