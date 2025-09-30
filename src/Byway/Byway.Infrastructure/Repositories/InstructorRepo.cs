using Byway.Domain.Entities;
using Byway.Domain.Interfaces;
using Byway.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Byway.Infrastructure.Repositories
{
    internal class InstructorRepo(BywayDbContext db) : IInstructorRepo
    {
        private readonly BywayDbContext _context = db;

        public async Task AddAsync(Instructor instructor, CancellationToken cancellationToken = default)
        {
            await _context.Instructors.AddAsync(instructor, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Instructor instructor, CancellationToken cancellationToken = default)
        {
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<Instructor> GetAll(CancellationToken cancellationToken = default)
        {
            return _context.Instructors.AsQueryable();
        }

        public async Task<Instructor?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Instructors.FindAsync(id, cancellationToken);

        }

        public async Task<bool> HasCoursesAsync(Guid instructorId, CancellationToken cancellationToken = default)
        {
            return await _context.Courses.AnyAsync(course => course.InstructorId == instructorId, cancellationToken);
        }

        public async Task UpdateAsync(Instructor instructor, CancellationToken cancellationToken = default)
        {
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
