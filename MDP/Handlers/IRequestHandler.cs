namespace MDP.Handlers
{
    public interface IRequestHandler <K>
    {
        public abstract Task<K?> HandleRequest(int id);
    }
}
