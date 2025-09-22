namespace Byway.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();


    }
}
