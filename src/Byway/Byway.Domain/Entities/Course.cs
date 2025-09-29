using Byway.Domain.Enums;

namespace Byway.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Level Level { get; set; }
        public Guid InstructorId { get; set; }
        public decimal Cost { get; set; }
        public int TotalHours { get; set; }
        public decimal Rate { get; set; }
        public string Description { get; set; }
        public string Certification { get; set; }
        public ICollection<CourseContent> Contents { get; set; } = new List<CourseContent>();
        // Navigation property: students who purchased this course
        public ICollection<UserCourse> Purchases { get; set; } = new List<UserCourse>();
        //For Navigation
        public Category Category { get; set; }
        public Instructor Instructor { get; set; }
    }
}
