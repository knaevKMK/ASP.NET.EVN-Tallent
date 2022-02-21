namespace EVNTalent.Services.DepartmentCommands.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Services.Common.Infrastructure;
    using Domain.Entities;
    using EVNTalent.Services.Common.Interfaces;
    using AutoMapper;

    public class AddDepartmentsCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
    }
    public class AddDepartmentsCommandHandler : AppIRequestHandler<AddDepartmentsCommand, int>
    {
        public AddDepartmentsCommandHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }

        public override async Task<int> Handle(AddDepartmentsCommand request, CancellationToken cancellationToken)
        {
            EntityEntry<Department> entityEntry = await _data.Departments.AddAsync(_mapper.CreateMapper().Map<Department>(request));
            entityEntry.Entity.CreateOn = DateTime.Now;
            int value = await _data.SaveChangesAsync(); 
            return (value);
        }
    }
}
