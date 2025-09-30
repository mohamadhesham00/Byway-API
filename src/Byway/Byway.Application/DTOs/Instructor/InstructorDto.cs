using Byway.Domain.Enums;

namespace Byway.Application.DTOs.Instructor
{
    public class InstructorDto
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public JobTitle JobTitle { get; set; }
        public decimal Rate { get; set; }
        public string Description { get; set; }
    }
}
