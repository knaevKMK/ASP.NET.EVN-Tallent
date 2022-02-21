namespace EVNTalent.Services.CandidateCommands.Queriy.Helpers
{
    using EVNTalent.Domain.Entities;
    using EVNTalent.Services.CandidateCommands.Queriy.FilterCandidate;
    using System.Linq;
    using System.Reflection;
 public static   class FilterQuery
    {
        public static IQueryable<Candidate> FilterByField(IQueryable<Candidate> query, FilterCandidateQeury request)
        {
            query = query.Where(c=>!c.IsDeleted);
            PropertyInfo[] properties = typeof(FilterCandidateQeury).GetProperties();
            foreach (var field in properties)
            {
                var _value = field.GetValue(request);
                if (_value == null)
                {
                    continue;
                }

                switch (field.Name)
                {
                    case "IsMine":
                    case "User": continue;

                    case "Name":
                        query = query.Where(u => u.FirstName.Contains(request.Name) || u.MiddleName.Contains(request.Name)
           || u.LastName.Contains(request.Name)); break;
                    case "Department": query = query.Where(u => u.Department.Name.Equals(request.Department)); break;
                    case "Education": query = query.Where(u => u.Education.Contains(request.Education)); break;
                    case "Score":
                        query =
                  request.ArrowScore == null
                  ? query.Where(u => u.Score == (int)_value)
                  : request.ArrowScore == "0"
                                      ? query.Where(u => u.Score < request.Score)
                                      : query.Where(u => u.Score > request.Score); break;
                    case "BirthYaer":
                        query =
           request.ArrowBirth == null
            ? query.Where(u => u.BirthDate.Year == (int)_value)
            : request.ArrowBirth == "0" ? query.Where(u => u.BirthDate.Year < request.BirthYaer)
                                    : query.Where(u => u.BirthDate.Year > request.BirthYaer); break;
                    default:
                        query = SortQuery.Sort(query, field.Name.Replace("Sort", ""), (string)_value == "0" ? "asc" : "desc");
                        break;
                }

            }
            return query;
        }
    }
}
