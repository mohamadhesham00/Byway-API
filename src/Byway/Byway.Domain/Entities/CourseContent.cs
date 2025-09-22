namespace Byway.Domain.Entities
{
    public class CourseContent : BaseEntity
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public int LecturesNumber { get; set; }
        public TimeSpan Time { get; set; }
        public Course Course { get; set; }

    }
}
