namespace MDP.Handlers
{
    public interface ICrudHandler <K, I>
    {
        public Task<K> Create(I original);
        public Task<K?> Get(int id);
        public Task<K> Update(K updated);
        public Task<bool> Delete(int id);
        public Task<List<K>> GetPaginatedRange(int page, int amount);
        public Task<int> GetCount();
    }
}
