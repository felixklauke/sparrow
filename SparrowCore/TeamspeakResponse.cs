namespace SparrowCore
{
    public class TeamspeakResponse : ITeamspeakResponse
    {
        public int StatusId { get; }
        public string Message { get; }

        public TeamspeakResponse(string message, int statusId)
        {
            Message = message;
            StatusId = statusId;
        }
    }
}