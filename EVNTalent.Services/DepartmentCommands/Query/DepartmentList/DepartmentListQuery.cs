namespace EVNTalent.Services.DepartmentCommands.Query.DepartmentList
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using EVNTalent.Domain.ViewModels;
    using EVNTalent.Services.Common.Infrastructure;
    using EVNTalent.Services.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class DepartmentListQuery : IRequest<DepartmentListQueryResult>
    {
    }
    public class DepartmentListQueryHandler : AppIRequestHandler<DepartmentListQuery, DepartmentListQueryResult>
    {
        public DepartmentListQueryHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }
        public override async Task<DepartmentListQueryResult> Handle(DepartmentListQuery request, CancellationToken cancellationToken)
        {
            return new DepartmentListQueryResult()
            {
                DepartmentList = await _data.Departments
                .Where(d=>!d.IsDeleted)
                .ProjectTo<DepartmentViewModel>(_mapper)
                .ToListAsync()
            };
        }
    }
    public class DepartmentListQueryResult
    {
        public List<DepartmentViewModel> DepartmentList { get; set; }
    }
}
