

namespace SparrowCore
{
    internal class Sparrow
    {
        public static void Main(string[] args)
        {
            var queryConfig = new QueryConfig("localhost", 10011, 1, "tsbot_test", "sBzYsqog");
            var queryManager = new QueryManager(queryConfig);

            queryManager.Connect().Wait();
        }
    }
}