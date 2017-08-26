namespace SparrowCore
{
    public class QueryConfig : IQueryConfig
    {
        public string QueryHost { get; }
        public int QueryPort { get; }
        public int VirtualServerId { get; }
        public string QueryUsername { get; }
        public string QueryPassword { get; }

        public QueryConfig(string queryHost, int queryPort, int virtualServerId, string queryUsername, string queryPassword)
        {
            QueryHost = queryHost;
            QueryPort = queryPort;
            VirtualServerId = virtualServerId;
            QueryUsername = queryUsername;
            QueryPassword = queryPassword;
        }
    }
}