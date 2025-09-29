using Byway.Domain.Entities;

public class UserCourse
{
    public Guid UserId { get; set; }
    public AppUser User { get; set; }

    public Guid CourseId { get; set; }
    public Course Course { get; set; }

    public DateTime PurchasedAt { get; set; } = DateTime.UtcNow;
}
