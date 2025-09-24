using Byway.Domain.Entities;
using Byway.Domain.Interfaces;
using Byway.Infrastructure.Persistence;

namespace Byway.Infrastructure.Repositories
{
    internal class CategoryRepo(BywayDbContext db) : ICategoryRepo
    {
        private readonly BywayDbContext _context = db;

        public IQueryable<Category> GetAll()
        {
            return _context.Categories.AsQueryable();
        }
    }
}
