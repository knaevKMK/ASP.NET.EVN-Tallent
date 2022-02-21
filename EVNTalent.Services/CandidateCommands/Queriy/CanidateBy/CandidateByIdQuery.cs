namespace EVNTalent.Services.CandidateCommands.Queriy.CanidateBy
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using EVNTalent.Domain.ViewModels;
    using EVNTalent.Services.Common.Infrastructure;
    using EVNTalent.Services.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;

    public   class CandidateByIdQuery : IRequest<CandidateByIdQueryResult>
    {
        public string Id { get; set; }
    }

    public class CandidateByIdQueryHandler : AppIRequestHandler<CandidateByIdQuery, CandidateByIdQueryResult>
    {
        public CandidateByIdQueryHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }

        public override async Task<CandidateByIdQueryResult> Handle(CandidateByIdQuery request, CancellationToken cancellationToken)
        {
            // Candidate candidate = await _data.Candidates.FindAsync( request.Id);
            return new CandidateByIdQueryResult
            {
                Candidate = _data.Candidates
                                .Where(c => c.Id.ToString().Equals(request.Id) && !c.IsDeleted)
                                .ProjectTo<CandidateDetailsViewModel>(_mapper)
                                .FirstOrDefault()
        };
        }
    }
    public class CandidateByIdQueryResult
    {
        public CandidateDetailsViewModel Candidate { get; set; }
    }
}
