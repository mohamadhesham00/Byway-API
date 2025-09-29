using Microsoft.AspNetCore.Identity;

namespace Byway.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<UserCourse> PurchasedCourses { get; set; } = new List<UserCourse>();
        public AppUser(string firstName, string lastName, string userName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
        }


    }
}
