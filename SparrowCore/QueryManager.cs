using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using PrimS.Telnet;

namespace SparrowCore
{
    public class QueryManager : IQueryManager
    {
        public IQueryConfig Config { get; }

        private Client _client;
        
        public QueryManager(IQueryConfig queryConfig)
        {
            Config = queryConfig;
        }


        public async Task Connect()
        {
            Console.WriteLine("Connecting to " + Config.QueryHost + ":" + Config.QueryPort);

            using (_client = new Client(Config.QueryHost, Config.QueryPort, new CancellationToken()))
            {

                Console.WriteLine("Connected to " + Config.QueryHost + ":" + Config.QueryPort);

                if (!_client.IsConnected)
                {
                    throw new IOException("Could not connect to " + Config.QueryHost + ":" + Config.QueryPort);
                }

                Console.WriteLine("Logging in...");

                _client.WriteLine("login " + Config.QueryUsername + " " + Config.QueryPassword).Wait();
                var response = await _client.ReadAsync(TimeSpan.FromSeconds(3));

                Console.WriteLine("Login state: " + response);

                _client.WriteLine("use " + Config.VirtualServerId).Wait();
                response = await _client.ReadAsync(TimeSpan.FromSeconds(3));
                
                Console.WriteLine("Selected virtual server: " + response);
            }
        }

        public void Disconnect()
        {
            throw new System.NotImplementedException();
        }
    }
}