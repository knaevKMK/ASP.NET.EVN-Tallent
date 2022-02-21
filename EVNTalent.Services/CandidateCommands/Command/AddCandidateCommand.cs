namespace EVNTalent.Services.CandidateCommands.Command
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using EVNTalent.Domain.Entities;
    using EVNTalent.Services.Common.Extensions;
    using EVNTalent.Services.Common.Infrastructure;
    using EVNTalent.Services.Common.Interfaces;
    using MediatR;
  public  class AddCandidateCommand : IRequest<string>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DepartmentName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Education { get; set; }
        public int Score { get; set; }
    }

    public class AddCandidateCommandHandler : AppIRequestHandler<AddCandidateCommand, string>
    {
        public AddCandidateCommandHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }

        public override async Task<string> Handle(AddCandidateCommand request, CancellationToken cancellationToken)
        {
            Candidate candidate = _mapper.CreateMapper().Map<Candidate>(request);
            candidate.CreateOn = DateTime.Now;
            candidate.Department = _data.Departments.FirstOrDefault(d => d.Name == request.DepartmentName);
            candidate.Code =
              CodeGenerator.GenerateCandidateCode(_data.Candidates.Count(), candidate.Department.Code, request.BirthDate);

            _data.Candidates.Add(candidate);
             await _data.SaveChangesAsync();
            return (candidate.Id.ToString());
        }
    }
}
