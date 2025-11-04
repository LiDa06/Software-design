using System.Collections.Concurrent;

namespace ConsoleApp.Repositories
{
    public class InMemoryRepository<T>(Func<T, Guid> idSelector) : IRepository<T> where T : class
    {
        protected ConcurrentDictionary<Guid, T> _store = new();

        private readonly Func<T, Guid> _idSelector = idSelector ?? throw new ArgumentNullException(nameof(idSelector));

        public void Add(T item)
        {
            Guid id = _idSelector(item);
            _store[id] = item;
        }

        public void Update(T item)
        {
            Guid id = _idSelector(item);
            if (!_store.ContainsKey(id))
            {
                return;
            }

            _store[id] = item;
        }

        public void Remove(Guid id)
        {
            _ = _store.TryRemove(id, out _);
        }

        public T Get(Guid id)
        {
            T v = _store[id];
            return v;
        }

        public IEnumerable<T> GetAll()
        {
            return [.. _store.Values];
        }
    }
}
