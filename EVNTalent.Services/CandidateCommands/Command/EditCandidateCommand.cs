namespace EVNTalent.Services.CandidateCommands.Command
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using EVNTalent.Services.Common.Extensions;
    using EVNTalent.Services.Common.Infrastructure;
    using EVNTalent.Services.Common.Interfaces;
 public   class EditCandidateCommand: AddCandidateCommand
    {
        public string Id { get; set; }
    }
    public class EditCandidateCommandHandler : AppIRequestHandler<EditCandidateCommand, string>
    {
        public EditCandidateCommandHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }

        public override async Task<string> Handle(EditCandidateCommand request, CancellationToken cancellationToken)
        {


            Domain.Entities.Candidate candidate
               = _data.Candidates.FirstOrDefault(c => c.Id.ToString().Equals(request.Id) && !c.IsDeleted);
            if (candidate == null)
            {
                throw new NullReferenceException("Candidate with this Id is unvaileble" );
            }
            candidate.FirstName = request.FirstName;
            candidate.MiddleName = request.MiddleName;
            candidate.LastName = request.LastName;
            candidate.Education = request.Education;
            candidate.BirthDate = request.BirthDate;
            candidate.Score = request.Score;
            candidate.Department = _data.Departments.FirstOrDefault(d => d.Name == request.DepartmentName);
            candidate.Code = CodeGenerator.GenerateCandidateCode(int.Parse(candidate.Code.Substring(0, 3)), candidate.Department.Code, request.BirthDate);


            int result = await _data.SaveChangesAsync();
            return candidate.Id.ToString();
        }
    }
}
