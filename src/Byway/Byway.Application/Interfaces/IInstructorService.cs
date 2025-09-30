using Byway.Application.Common.Models;
using Byway.Application.DTOs;
using Byway.Application.DTOs.Instructor;

namespace Byway.Application.Interfaces
{
    public interface IInstructorService
    {
        Task<Result<InstructorDto>> AddInstructorAsync(CreateInstructorDto dto, CancellationToken cancellationToken = default);
        public Task<Result<PagedResult<InstructorDto>>> GetInstructorsAsync(int pageNumber, int pageSize, InstructorFilter? filter, CancellationToken cancellationToken);
        Task<Result<InstructorDto>> GetInstructorByIdAsync(Guid instructorId, CancellationToken cancellationToken = default);
        Task<Result<InstructorDto>> UpdateInstructorAsync(Guid instructorId, UpdateInstructorDto dto, CancellationToken cancellationToken = default);
        Task<Result> DeleteInstructorAsync(Guid instructorId, CancellationToken cancellationToken = default);
        public Result<IEnumerable<EnumDto>> GetJobTitles();



    }
}
