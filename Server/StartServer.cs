using System;
using System.Net.Sockets;
using System.Threading;
using Networking;
using Persistence;
using Service;

namespace Server
{
    internal class StartServer
    {
        public static void Main(string[] args)
        {
            UtilizatorRepo utilizatorRepo = new UtilizatorDb();
            ParticipantRepo participantRepo = new ParticipantDb();
            ProbaRepo probaRepo = new ProbaDb();
            InscriereRepo inscriereRepo = new InscriereDb();
            
            IServices service = new AppService(utilizatorRepo, probaRepo, participantRepo, inscriereRepo);
            
            SerialServer server = new SerialServer("127.0.0.1", 55555, service);
            server.Start();
            Console.WriteLine("Server started ...");
            //Console.WriteLine("Press <enter> to exit...");
            Console.ReadLine();
        }
    }
    
    
    public class SerialServer: ConcurrentServer 
    {
        private IServices server;
        private ClientWorker worker;
        public SerialServer(string host, int port, IServices server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("SerialServer...");
        }
        protected override Thread createWorker(TcpClient client)
        {
            worker = new ClientWorker(server, client);
            return new Thread(new ThreadStart(worker.run));
        }
    }
}