using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace PryRabbitColas1
{


    class PryRabbitColas1
    {
        static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare("TestTopic", ExchangeType.Topic);

                string message = "Mensaje de notificación para notificacionesMail";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "TestTopic",
                                     routingKey: "notificaciones",
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine("Mensaje enviado a notificacionesMail: {0}", message);
            }

            Console.WriteLine("Presiona cualquier tecla para salir.");
            Console.ReadKey();
        }
    }
}
