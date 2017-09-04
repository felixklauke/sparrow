using System;
using System.Threading.Tasks;

namespace SparrowCore
{
    public class TeamspeakResponseParser
    {
        public static Task<ITeamspeakResponse> ParseResponse(Task<string> requestTask)
        {   
            var task = new Task<ITeamspeakResponse>(() =>
            {
                var result = requestTask.Result;
                Console.WriteLine("Parsing response to internal teamspeak response: " + result);
                return new TeamspeakResponse("", 0);
            });
            
            task.RunSynchronously();

            return task;
        }
    }
}