using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
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

            _client = new Client(Config.QueryHost, Config.QueryPort, new CancellationToken());

            Console.WriteLine("Connected to " + Config.QueryHost + ":" + Config.QueryPort);

            if (!_client.IsConnected)
            {
                throw new IOException("Could not connect to " + Config.QueryHost + ":" + Config.QueryPort);
            }

            Console.WriteLine("Logging in...");

            var response = SendRequest("login " + Config.QueryUsername + " " + Config.QueryPassword);

            Console.WriteLine("Login state: " + response);

            response = SendRequest("use " + Config.VirtualServerId);

            Console.WriteLine("Selected virtual server: " + response);

            response = SendRequest("whoami");
            
            Console.WriteLine("Current status: " + response);

            Console.WriteLine(UserList());
        }

        public Task<string> SendRequest(string request)
        {
            return SendRequest(request, 5);
        }
        
        public Task<string> SendRequest(string request, int timeOutSeconds)
        {
            return SendRequest(request, TimeSpan.FromSeconds(timeOutSeconds));
        }
        
        public async Task<string> SendRequest(string request, TimeSpan timeout)
        {
            _client.WriteLine(request).Wait();
            return await _client.ReadAsync(timeout);
        }
        
        public string UserList()
        {
            return SendRequest("clientlist").Result;
        }
        
        public void Disconnect()
        {
            throw new System.NotImplementedException();
        }
    }
}