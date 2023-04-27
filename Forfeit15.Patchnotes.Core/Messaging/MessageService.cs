using System.Text;
using System.Text.Json;
using Forfeit15.Patchnotes.Core.Messaging.Contracts;
using RabbitMQ.Client;

namespace Forfeit15.Patchnotes.Core.Messaging;

public class MessageService
{
    private readonly string _connectionString;
    private readonly string _exchangeName;

    public MessageService(string connectionString, string exchangeName)
    {
        _connectionString = connectionString;
        _exchangeName = exchangeName;
    }

    public void SendMessage(UpdateMessage message)
    {
        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

        var factory = new ConnectionFactory() { Uri = new Uri(_connectionString) };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.ExchangeDeclare(_exchangeName, ExchangeType.Fanout);

        var queueName = "forfeit15";
        channel.QueueDeclare(queueName, durable: false, exclusive: false, autoDelete: false);
        channel.QueueBind(queueName, _exchangeName, routingKey: "");
        
        channel.BasicPublish(exchange: _exchangeName,
            routingKey: "",
            basicProperties: null,
            body: body);
    }
}