using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace MQServer
{
    /// <summary>
    /// 接收端，即消费者，用来接收生产者发出的消息
    /// 可以运行此程序多个示例来测试
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "guest";
            factory.Password = "guest";

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("ShangbaoQueue", false, false, false, null);

                    var consumer = new QueueingBasicConsumer(channel);
                    //noAck参数表示是否直接响应，如果直接响应的话，服务端将直接删除已经发出的消息，这样可能的情况是，消息服务发送出消息，
                    //一个客户端可能处理挂掉，但服务端认为消息已经发出并且是noAck=true，就会删除消息，
                    //为了保证每一条消息能够发出并且被正确处理完成，我们可以设置noAck=false，但这样一定要在消息处理完成后，
                    //手动向服务端Ack，否则就会内存溢出
                    //channel.BasicConsume("ShangbaoQueue", false, consumer);//设置不直接Ack
                    //channel.BasicAck(ea.DeliveryTag, false);//处理完一定要手动Ack
                    channel.BasicConsume("ShangbaoQueue", true, consumer);

                    Console.WriteLine(" waiting for message.");
                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Thread.Sleep(2 * 1000);//模拟消息处理等待时间
                        //TODO 业务处理在此写
                        Console.WriteLine("Received {0}", message);

                    }
                }
            }
        }
    }
}