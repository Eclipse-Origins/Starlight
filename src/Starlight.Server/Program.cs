using System;

namespace Starlight.Server
{
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine("Starlight Server");

            // create and start the server
            Telepathy.Server server = new Telepathy.Server();
            server.Start(1337);

            var isRunning = true;
            while (isRunning)
            {

                // Update loop
                Telepathy.Message msg;
                while (server.GetNextMessage(out msg))
                {
                    switch (msg.eventType)
                    {
                        case Telepathy.EventType.Connected:
                            Console.WriteLine(msg.connectionId + " Connected");
                            break;
                        case Telepathy.EventType.Data:
                            Console.WriteLine(msg.connectionId + " Data: " + BitConverter.ToString(msg.data));
                            break;
                        case Telepathy.EventType.Disconnected:
                            Console.WriteLine(msg.connectionId + " Disconnected");
                            break;
                    }
                }

            }
            


        } // main

    }
}
