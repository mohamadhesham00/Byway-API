using Byway.Application.Common.Extensions;
using Byway.Application.Common.Interfaces;
using Byway.Application.Common.Models;
using Byway.Application.DTOs;
using Byway.Application.DTOs.Instructor;
using Byway.Application.Extensions;
using Byway.Application.Interfaces;
using Byway.Application.Mappings;
using Byway.Domain.Enums;
using Byway.Domain.Interfaces;

namespace Byway.Application.Services
{
    public class InstructorService(IInstructorRepo instructorRepo, ICurrentUserService currentUserService) : IInstructorService
    {
        private readonly IInstructorRepo _instructorRepo = instructorRepo;
        private readonly ICurrentUserService _currentUserService = currentUserService;
        public async Task<Result<InstructorDto>> AddInstructorAsync(CreateInstructorDto dto, CancellationToken cancellationToken = default)
        {
            var user = _currentUserService.GetCurrentUser();
            var instructor = dto.ToEntity(user.UserId ?? Guid.Empty);
            await _instructorRepo.AddAsync(instructor, cancellationToken);
            var instructorDto = instructor.ToDto();
            return Result<InstructorDto>.Success(instructorDto);

        }

        public async Task<Result<PagedResult<InstructorDto>>> GetInstructorsAsync(int pageNumber, int pageSize, InstructorFilter? filter, CancellationToken cancellationToken)
        {
            filter ??= new InstructorFilter();
            var query = await _instructorRepo
                .GetAll(cancellationToken)
                .FilterByJobTitle(filter.JobTitle)
                .FilterByName(filter.Name)
                .PaginateAsync(pageNumber, pageSize, cancellationToken);

            return Result<PagedResult<InstructorDto>>.Success(query.Map(i => i.ToDto()));
        }

        public async Task<Result<InstructorDto>> GetInstructorByIdAsync(Guid instructorId, CancellationToken cancellationToken = default)
        {
            var instructor = await _instructorRepo.GetByIdAsync(instructorId, cancellationToken);
            if (instructor == null)
                return Result<InstructorDto>.Failure("Could not find instructor with this id", 404);
            var instructorDto = instructor.ToDto();
            return Result<InstructorDto>.Success(instructorDto);
        }

        public async Task<Result<InstructorDto>> UpdateInstructorAsync(Guid instructorId, UpdateInstructorDto dto, CancellationToken cancellationToken = default)
        {
            var instructor = await _instructorRepo.GetByIdAsync(instructorId, cancellationToken);
            if (instructor == null)
                return Result<InstructorDto>.Failure("Instructor not found", 404);

            if (!string.IsNullOrEmpty(dto.Name)) instructor.Name = dto.Name;
            if (!string.IsNullOrEmpty(dto.ImagePath)) instructor.ImagePath = dto.ImagePath;
            if (dto.JobTitle.HasValue) instructor.JobTitle = dto.JobTitle.Value;
            if (dto.Rate.HasValue) instructor.Rate = dto.Rate.Value;
            if (!string.IsNullOrEmpty(dto.Description)) instructor.Description = dto.Description;

            await _instructorRepo.UpdateAsync(instructor, cancellationToken);

            return Result<InstructorDto>.Success(instructor.ToDto());
        }

        public async Task<Result> DeleteInstructorAsync(Guid instructorId, CancellationToken cancellationToken = default)
        {
            var instructor = await _instructorRepo.GetByIdAsync(instructorId, cancellationToken);
            if (instructor == null)
                return Result.Failure("Instructor not found", 404);

            bool hasCourses = await _instructorRepo.HasCoursesAsync(instructorId, cancellationToken);
            if (hasCourses)
                return Result.Failure("Cannot delete, instructor has courses", 400);

            await _instructorRepo.DeleteAsync(instructor, cancellationToken);
            return Result.Success();
        }

        public Result<IEnumerable<EnumDto>> GetJobTitles()
        {
            var jobTitles = Enum.GetValues(typeof(JobTitle))
            .Cast<JobTitle>()
            .Select(jt => new EnumDto
            {
                Value = (int)jt,
                Name = jt.ToString()
            })
            .ToList();
            return Result<IEnumerable<EnumDto>>.Success(jobTitles);
        }

    }
}
