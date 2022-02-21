
namespace EVNTalent.Services.CandidateCommands.Queriy.Helpers
{
    using EVNTalent.Domain.Entities;
    using System.Linq;
   public static class SortQuery
    {
        public static  IQueryable<Candidate> Sort(IQueryable<Candidate> query, string SortBy, string Arrow)
        {
            query = query.Where(c => !c.IsDeleted);
            switch (SortBy.ToLower())
            {
                case "id":
                    query = checkArrow(Arrow.ToLower())
                        ? query.OrderByDescending(u => u.Id)
                        : query.OrderBy(u => u.Id); break;
                case "name":
                    query = checkArrow(Arrow.ToLower()) ? query.OrderByDescending(u => u.FirstName)
                      : query.OrderBy(u => u.FirstName); break;
                case "department":
                    query = checkArrow(Arrow.ToLower()) ? query.OrderByDescending(u => u.Department.Name)
                       : query.OrderBy(u => u.Department.Name); break;
                case "education":
                    query = checkArrow(Arrow.ToLower()) ? query.OrderByDescending(u => u.Education)
                        : query.OrderBy(u => u.Education); break;
                case "score":
                    query = checkArrow(Arrow.ToLower()) ? query.OrderByDescending(u => u.Score)
                        : query.OrderBy(u => u.Score); break;
                case "birthyear":
                    query = checkArrow(Arrow.ToLower()) ? query.OrderByDescending(u => u.BirthDate.Year)
                      : query.OrderBy(u => u.BirthDate.Year); break;
            }
            return query;
        }
        private static bool checkArrow(string sort)
        {
            return sort.Equals("desc");
        }
    }
}
