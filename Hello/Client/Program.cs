﻿using Grpc.Core;
using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            const string Host = "localhost";
            const int Port = 16842;

            var channel = new Channel($"{Host}:{Port}", ChannelCredentials.Insecure);
            var client = new Generated.HelloResponse.HelloResponseClient(channel);
            var response = client.SayHello(new Generated.HelloRequest{
                Name = Console.ReadLine(),
            });

            // Shutdown
            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}


