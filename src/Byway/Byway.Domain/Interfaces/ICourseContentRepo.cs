using Byway.Domain.Entities;

namespace Byway.Domain.Interfaces
{
    public interface ICourseContentRepo
    {
        IQueryable<CourseContent> GetByCourseId(Guid courseId, CancellationToken cancellationToken = default);
        Task AddAsync(CourseContent courseContent, CancellationToken cancellationToken = default);
        Task UpdateAsync(CourseContent courseContent, CancellationToken cancellationToken = default);
        Task DeleteAsync(CourseContent courseContent, CancellationToken cancellationToken = default);
    }
}
