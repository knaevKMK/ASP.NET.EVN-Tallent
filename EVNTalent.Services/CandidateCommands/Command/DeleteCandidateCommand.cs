namespace EVNTalent.Services.CandidateCommands.Command
{
    using AutoMapper;
    using EVNTalent.Services.Common.Infrastructure;
    using EVNTalent.Services.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using Domain.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public class DeleteCandidateCommand : IRequest<int>
    {
        public string Id { get; set; }
      
    }
    public class DeleteCandidateCommandHandler : AppIRequestHandler<DeleteCandidateCommand, int>
    {
        public DeleteCandidateCommandHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }



        public override async Task<int> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            Candidate candidate = _data.Candidates.FirstOrDefault(c => c.Id.ToString().Equals(request.Id));
            if (candidate == null)
            {
                return 0;
            }
            candidate.IsDeleted = true;
            int result =await _data.SaveChangesAsync();
            return result;
        }
    }
}
