using System;
using System.Threading.Tasks;

namespace SparrowCore
{
    public class WhoAmIParser
    {
        public static Task<WhoAmI> CreateWhoAmIReport(Task<string> sendRequest)
        {
            return new Task<WhoAmI>(() => new WhoAmI());
        }
    }
}