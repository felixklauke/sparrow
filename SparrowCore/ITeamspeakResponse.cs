namespace SparrowCore
{
    public interface ITeamspeakResponse
    {
        int ErrorId { get; }
        
        string Message { get; }
    }
}