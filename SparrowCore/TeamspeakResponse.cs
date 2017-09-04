namespace SparrowCore
{
    public class TeamspeakResponse : ITeamspeakResponse
    {
        public int ErrorId { get; }
        public string Message { get; }

        public TeamspeakResponse(string message, int errorId)
        {
            Message = message;
            ErrorId = errorId;
        }
    }
}