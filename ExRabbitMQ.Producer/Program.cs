using System;
using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory();

factory.Uri = new Uri("amqps://kqrijscj:ekQcnDbu67XtUacb28LLNsRfjCdwFbQ0@roedeer.rmq.cloudamqp.com/kqrijscj");

using var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.QueueDeclare("numbers", true, false, false);

Enumerable.Range(1, 50).ToList().ForEach(i =>
{
    string message = $"Message: {i}";
    var messageBody = Encoding.UTF8.GetBytes(message);
    channel.BasicPublish(String.Empty, "numbers", null, messageBody);
    Console.WriteLine($"Sended: {message}");
    Thread.Sleep(1000);
}); 

Console.ReadKey();