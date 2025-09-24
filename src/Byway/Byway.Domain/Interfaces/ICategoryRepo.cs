using Byway.Domain.Entities;

namespace Byway.Domain.Interfaces
{
    public interface ICategoryRepo
    {
        public IQueryable<Category> GetAll();
    }
}
