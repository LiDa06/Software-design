using ConsoleApp.Models;
using ConsoleApp.Repositories;
using ConsoleApp.Domain;

namespace ConsoleApp.Facades
{
    public class CategoryFacade(IRepository<Category> categories, Factory factory)
    {
        private readonly IRepository<Category> _categories = categories;
        private readonly Factory _factory = factory;

        public Category CreateCategory(CategoryType type, string name)
        {
            Category c = _factory.CreateCategory(type, name);
            _categories.Add(c);
            return c;
        }

        public IEnumerable<Category> GetAll()
        {
            return _categories.GetAll();
        }

        public Category Get(Guid id)
        {
            return _categories.Get(id);
        }

        public void Delete(Guid id)
        {
            _categories.Remove(id);
        }
    }
}
