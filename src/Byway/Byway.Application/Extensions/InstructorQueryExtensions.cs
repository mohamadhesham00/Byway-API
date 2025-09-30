using Byway.Domain.Entities;
using Byway.Domain.Enums;

namespace Byway.Application.Extensions
{
    public static class InstructorQueryExtensions
    {
        public static IQueryable<Instructor> FilterByJobTitle(this IQueryable<Instructor> query, JobTitle? title)
        {
            if (title == null)
                return query;
            return query.Where(query => query.JobTitle == title);
        }
        public static IQueryable<Instructor> FilterByName(this IQueryable<Instructor> query, string? name)
        {
            if (string.IsNullOrEmpty(name))
                return query;
            return query.Where(query => query.Name.Contains(name.Trim().ToLower()));
        }
    }
}
