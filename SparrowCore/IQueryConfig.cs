namespace SparrowCore
{
    public interface IQueryConfig
    {
        string QueryHost { get; }

        int QueryPort { get; } 

        int VirtualServerId { get; } 

        string QueryUsername { get; } 

        string QueryPassword { get; } 
    }
}