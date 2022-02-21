namespace EVNTalent.Services.Common.Infrastructure
{
    using AutoMapper;
    using EVNTalent.Domain.Entities;
    using EVNTalent.Domain.ViewModels;
    using EVNTalent.Services.CandidateCommands.Command;
    using EVNTalent.Services.DepartmentCommands.Commands;

    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            this.CreateMap<AddDepartmentsCommand,Department>();
            this.CreateMap<Department,DepartmentViewModel>();

            this.CreateMap<AddCandidateCommand,Candidate>();
            this.CreateMap<Candidate, CandidateViewModel>()
                .ForMember(c => c.FullName, opt => opt.MapFrom(c => c.FirstName + " " + c.MiddleName[0] + ". " + c.LastName))
                .ForMember(c => c.DepartmentName, opt => opt.MapFrom(c => c.Department.Name));
            this.CreateMap<Candidate, CandidateDetailsViewModel>()
                .ForMember(c => c.DepartmentName, opt => opt.MapFrom(c => c.Department.Name));
        }
    }
}
