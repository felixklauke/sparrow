using System;
using System.Threading.Tasks;

namespace SparrowCore
{
    public class WhoAmIParser
    {
        public static Task<WhoAmI> CreateWhoAmIReport(Task<string> sendRequest)
        {
            return new Task<WhoAmI>(() =>
            {
                var result = sendRequest.Result;
                Console.WriteLine("RESULT: " + result);
                return new WhoAmI();
            });
        }
    }
}