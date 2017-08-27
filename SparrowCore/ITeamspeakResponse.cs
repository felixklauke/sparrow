namespace SparrowCore
{
    public interface ITeamspeakResponse
    {
        int StatusId { get; }
        
        string Message { get; }
    }
}