using Byway.Application.DTOs.Instructor;
using Byway.Domain.Entities;

namespace Byway.Application.Mappings
{
    public static class InstructorMapping
    {
        public static InstructorDto ToDto(this Instructor instructor) =>
            new()
            {
                Id = instructor.Id,
                Name = instructor.Name,
                JobTitle = instructor.JobTitle,
                Rate = instructor.Rate,
                Description = instructor.Description,
                ImagePath = instructor.ImagePath
            };
        public static Instructor ToEntity(this CreateInstructorDto dto, Guid userId) =>
            new()
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                ImagePath = dto.ImagePath,
                JobTitle = dto.JobTitle,
                Rate = dto.Rate,
                Description = dto.Description,
                CreatedAt = DateTime.Now,
                CreatedBy = userId
            };
    }

}
