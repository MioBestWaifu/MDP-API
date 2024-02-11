namespace MDP.Handlers
{
    public interface ISearchHandler<K>
    {
        public Task<K> HandleSearch(string query, int page = 0);
    }
}
