using Byway.Domain.Entities;
using Byway.Domain.Interfaces;
using Byway.Infrastructure.Persistence;

namespace Byway.Infrastructure.Repositories
{
    public class CourseContentRepo(BywayDbContext db) : ICourseContentRepo
    {
        private readonly BywayDbContext _context = db;

        public async Task AddAsync(CourseContent courseContent, CancellationToken cancellationToken = default)
        {

            await _context.CourseContents.AddAsync(courseContent, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(CourseContent courseContent, CancellationToken cancellationToken = default)
        {
            _context.CourseContents.Remove(courseContent);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<CourseContent> GetByCourseId(Guid courseId, CancellationToken cancellationToken = default)
        {
            return _context.CourseContents.Where(CourseContent => CourseContent.CourseId == courseId);
        }

        public async Task UpdateAsync(CourseContent courseContent, CancellationToken cancellationToken = default)
        {

            _context.CourseContents.Update(courseContent);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
