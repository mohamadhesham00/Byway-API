using Byway.Domain.Entities;
using Byway.Domain.Interfaces;
using Byway.Infrastructure.Persistence;

namespace Byway.Infrastructure.Repositories
{
    public class CourseRepo(BywayDbContext db) : ICourseRepo
    {
        private readonly BywayDbContext _context = db;

        public async Task AddAsync(Course course, CancellationToken cancellationToken = default)
        {
            await _context.Courses.AddAsync(course, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Course course, CancellationToken cancellationToken = default)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<Course> GetAll(CancellationToken cancellationToken = default)
        {
            return _context.Courses.AsQueryable();
        }

        public async Task<Course?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Courses.FindAsync(id, cancellationToken);

        }

        public async Task UpdateAsync(Course course, CancellationToken cancellationToken = default)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }
    }
}
