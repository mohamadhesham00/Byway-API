using Byway.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Byway.Application.DTOs.Instructor
{
    public class CreateInstructorDto
    {
        [Required(ErrorMessage = "Image path is required.")]
        [StringLength(255, ErrorMessage = "Image path cannot exceed 255 characters.")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Job title is required.")]
        [EnumDataType(typeof(JobTitle), ErrorMessage = "Invalid job title.")]
        public JobTitle JobTitle { get; set; }

        [Required(ErrorMessage = "Rate is required.")]
        [Range(0.0, 5.0, ErrorMessage = "Rate must be between 0.0 and 5.0.")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 1000 characters.")]
        public string Description { get; set; }
    }
}
