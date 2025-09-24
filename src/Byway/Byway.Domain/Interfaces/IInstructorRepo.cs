using Byway.Domain.Entities;

namespace Byway.Domain.Interfaces
{
    public interface IInstructorRepo
    {
        Task<Instructor?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        IQueryable<Instructor> GetAll(CancellationToken cancellationToken = default);
        Task AddAsync(Instructor instructor, CancellationToken cancellationToken = default);
        Task UpdateAsync(Instructor instructor, CancellationToken cancellationToken = default);
        Task DeleteAsync(Instructor instructor, CancellationToken cancellationToken = default);
    }
}
