using Microsoft.AspNetCore.Identity;

namespace Byway.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //Navigation Property
        public ICollection<Course> PurchasedCourses { get; set; } = new List<Course>();

        public AppUser(string firstName, string lastName, string userName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
        }


    }
}
