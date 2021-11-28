using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

var factory = new ConnectionFactory();

factory.Uri = new Uri("amqps://kqrijscj:ekQcnDbu67XtUacb28LLNsRfjCdwFbQ0@roedeer.rmq.cloudamqp.com/kqrijscj");

using var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

var consumer = new EventingBasicConsumer(channel);

channel.BasicConsume("numbers", true, consumer);

consumer.Received += (object sender, BasicDeliverEventArgs e) =>
{
    var message = Encoding.UTF8.GetString(e.Body.ToArray());
    Console.WriteLine($"Received: {message}");
};
