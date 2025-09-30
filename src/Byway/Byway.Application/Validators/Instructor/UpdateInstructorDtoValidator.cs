using Byway.Application.DTOs.Instructor;
using FluentValidation;

namespace Byway.Application.Validators.Instructor
{
    public class UpdateInstructorDtoValidator : AbstractValidator<UpdateInstructorDto>
    {
        public UpdateInstructorDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(100)
                .When(x => x.Name != null);

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .When(x => x.Description != null);

            RuleFor(x => x.Rate)
                .GreaterThan(0)
                .When(x => x.Rate.HasValue);

            RuleFor(x => x.JobTitle)
                .IsInEnum()
                .When(x => x.JobTitle.HasValue);

            RuleFor(x => x.ImagePath)
                .Matches(@"^[\w,\s-]+\.(jpg|jpeg|png)$")
                .When(x => !string.IsNullOrEmpty(x.ImagePath));
        }
    }
}
