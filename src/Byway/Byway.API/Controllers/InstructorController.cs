using Byway.Application.DTOs.Instructor;
using Byway.Application.Interfaces;
using Byway.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Byway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstructorController(IInstructorService instructorService) : APIControllerBase
    {
        private readonly IInstructorService _instructorService = instructorService;

        // POST: api/instructor
        [HttpPost]
        [Authorize(Roles = UserRole.Admin)]
        public async Task<IActionResult> AddInstructor([FromBody] CreateInstructorDto dto, CancellationToken cancellationToken)
        {
            var result = await _instructorService.AddInstructorAsync(dto, cancellationToken);
            return HandleResult(result);
        }

        // GET: api/instructor?pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetInstructors([FromQuery] int pageNumber, [FromQuery] int pageSize, [FromQuery] InstructorFilter? filter, CancellationToken cancellationToken)
        {
            var result = await _instructorService.GetInstructorsAsync(pageNumber, pageSize, filter, cancellationToken);
            return HandleResult(result);
        }

        // GET: api/instructor/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetInstructorById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _instructorService.GetInstructorByIdAsync(id, cancellationToken);
            return HandleResult(result);
        }

        // PUT: api/instructor/{id}
        [Authorize(Roles = UserRole.Admin)]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateInstructor(Guid id, [FromBody] UpdateInstructorDto dto, CancellationToken cancellationToken)
        {
            var result = await _instructorService.UpdateInstructorAsync(id, dto, cancellationToken);
            return HandleResult(result);
        }

        //DELETE: api/instructor/{id}
        [Authorize(Roles = UserRole.Admin)]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteInstructor(Guid id, CancellationToken cancellationToken)
        {
            var result = await _instructorService.DeleteInstructorAsync(id, cancellationToken);
            return HandleResult(result);
        }

        // GET: api/instructor/jobtitles
        [HttpGet("jobtitles")]
        public IActionResult GetJobTitles()
        {
            var result = _instructorService.GetJobTitles();
            return HandleResult(result);
        }
    }
}
