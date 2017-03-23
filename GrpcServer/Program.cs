using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using HelloWorld;
using System.Diagnostics;

namespace GrpcServer
{
    class Program
    {
        const int port = 50051;
       

        static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { HelloWorld.GrpcLib.BindService(new Myserver()) },
                Ports = { new ServerPort("127.0.0.1",port,ServerCredentials.Insecure) }
            };
            server.Start();
            Console.ReadKey();
            server.ShutdownAsync().Wait();
        }
    }

    class Myserver : HelloWorld.GrpcLib.GrpcLibBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
        }

        public override async Task SayHelloAgain(HelloRequest request, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            await responseStream.WriteAsync(new HelloReply { Message = "Hello " + request.Name });
        }

        public override async Task<HelloReply> SayHelloThree(IAsyncStreamReader<HelloRequest> requestStream, ServerCallContext context)
        {
            var stopwatch = new Stopwatch();
            string name = "";
            stopwatch.Start();
           
            while (await requestStream.MoveNext())
            {
                //get client msg
                var request = requestStream.Current;
                name = request.Name;
            }
            stopwatch.Stop();
            return new HelloReply { Message = "Hello " + name };
        }

        public override Task SayHelloFour(IAsyncStreamReader<HelloRequest> requestStream, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            return base.SayHelloFour(requestStream, responseStream, context);
        }
    }
}
