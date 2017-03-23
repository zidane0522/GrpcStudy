using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grpc
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:50051",ChannelCredentials.Insecure);
            var client =new HelloWorld.GrpcLib.GrpcLibClient(channel);
            //Code goes here
            HelloWorld.HelloReply rply= client.SayHello(new HelloWorld.HelloRequest { Name = "Zidane0522" });
            AsyncUnaryCall<HelloWorld.HelloReply> rlly= client.SayHelloAsync(new HelloWorld.HelloRequest { Name = "Zidane0522" });
            Console.WriteLine(rply.Message);
            Console.WriteLine("From async"+ rlly.ResponseAsync.Result.Message); 
            Console.ReadKey();
            //await client.SayHelloAsync(new HelloWorld.HelloRequest { Name = "Zidane0522" });
            channel.ShutdownAsync().Wait();
        }
    }
}
