namespace EVNTalent.Services.CandidateCommands.Queriy.CandidateList
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using EVNTalent.Domain.ViewModels;
    using EVNTalent.Services.Common.Infrastructure;
    using EVNTalent.Services.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class CandidateListQuery:IRequest<CandidateListQueryResult>
    {
    }

    public class CandidateListQueryHandler : AppIRequestHandler<CandidateListQuery, CandidateListQueryResult>
    {
        public CandidateListQueryHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }

        public override async Task<CandidateListQueryResult> Handle(CandidateListQuery request, CancellationToken cancellationToken)
        {
            return  new CandidateListQueryResult { 
            Candidates= await _data.Candidates
            .Where(c=>!c.IsDeleted)
            .ProjectTo<CandidateViewModel>(_mapper)
            .ToListAsync()
            };
        }
    }
    public class CandidateListQueryResult
    {
        public List<CandidateViewModel> Candidates { get; set; }
    }
}
