using Byway.Domain.Entities;

namespace Byway.Domain.Interfaces
{
    public interface ICourseRepo
    {
        Task<Course?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        IQueryable<Course> GetAll(CancellationToken cancellationToken = default);
        Task AddAsync(Course course, CancellationToken cancellationToken = default);
        Task UpdateAsync(Course course, CancellationToken cancellationToken = default);
        Task DeleteAsync(Course course, CancellationToken cancellationToken = default);
    }
}
