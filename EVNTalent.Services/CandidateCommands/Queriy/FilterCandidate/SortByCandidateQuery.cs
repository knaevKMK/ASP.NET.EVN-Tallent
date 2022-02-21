namespace EVNTalent.Services.CandidateCommands.Queriy.FilterCandidate
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using EVNTalent.Domain.ViewModels;
    using EVNTalent.Services.CandidateCommands.Queriy.CandidateList;
    using EVNTalent.Services.CandidateCommands.Queriy.Helpers;
    using EVNTalent.Services.Common.Infrastructure;
    using EVNTalent.Services.Common.Interfaces;
    using MediatR;
     public   class SortByCandidateQuery : IRequest<CandidateListQueryResult>{public string Query { get; set; }
      }

    public class SortByCandidateQueryHandler : AppIRequestHandler<SortByCandidateQuery, CandidateListQueryResult>
    {
        public SortByCandidateQueryHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }

        public override async Task<CandidateListQueryResult> Handle(SortByCandidateQuery request, CancellationToken cancellationToken)
        {
            string[] sort = request.Query.Split(" ");
            var query = SortQuery.Sort(_data.Candidates.AsQueryable(), sort[0], sort[1]);
            return new CandidateListQueryResult
            {
                Candidates = query.ProjectTo<CandidateViewModel>(_mapper).ToList()
            };
        }
    }
}
