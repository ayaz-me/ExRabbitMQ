using System;
using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory();

factory.Uri = new Uri("amqps://kqrijscj:ekQcnDbu67XtUacb28LLNsRfjCdwFbQ0@roedeer.rmq.cloudamqp.com/kqrijscj");

using var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.QueueDeclare("hello-queue", true, false, false);

string message = "hello world!";

var messageBody = Encoding.UTF8.GetBytes(message);

for (int i = 0; i < 10; i++)
{
    channel.BasicPublish(String.Empty, "hello-queue", null, messageBody);
    Console.WriteLine($"Sended: {message}");
    Thread.Sleep(2000);
}