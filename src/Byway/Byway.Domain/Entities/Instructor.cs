using Byway.Domain.Enums;

namespace Byway.Domain.Entities
{
    public class Instructor : BaseEntity
    {
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public JobTitle JobTitle { get; set; }
        public decimal Rate { get; set; }
        public string Description { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();


    }
}
