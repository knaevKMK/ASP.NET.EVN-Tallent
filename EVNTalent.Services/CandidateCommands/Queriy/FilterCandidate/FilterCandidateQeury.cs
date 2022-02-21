namespace EVNTalent.Services.CandidateCommands.Queriy.FilterCandidate
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using EVNTalent.Domain.ViewModels;
    using EVNTalent.Services.CandidateCommands.Queriy.CandidateList;
    using EVNTalent.Services.CandidateCommands.Queriy.Helpers;
    using EVNTalent.Services.Common.Infrastructure;
    using EVNTalent.Services.Common.Interfaces;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
   public class FilterCandidateQeury:IRequest<CandidateListQueryResult>
    {
        public string Name { get; set; }
        public string NameSort { get; set; }
        public string Department { get; set; }
        public string DepartmentSort { get; set; }
        public string Education { get; set; }
        public string EducationSort { get; set; }
        public int? Score { get; set; }
        public string ArrowScore { get; set; }
        public string ScoreSort { get; set; }

        public int? BirthYaer { get; set; }
        public string ArrowBirth { get; set; }
        public string BirthYearSort { get; set; }
    }
    public class FilterCandidateQeuryHandler : AppIRequestHandler<FilterCandidateQeury, CandidateListQueryResult>
    {
        public FilterCandidateQeuryHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }

        public override async Task<CandidateListQueryResult> Handle(FilterCandidateQeury request, CancellationToken cancellationToken)
        {
           var query = FilterQuery.FilterByField(_data.Candidates.AsQueryable(), request);
            return new CandidateListQueryResult
            {
                Candidates = query.ProjectTo<CandidateViewModel>(_mapper).ToList()
            };
        }
    }
}
