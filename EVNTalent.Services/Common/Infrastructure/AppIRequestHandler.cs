namespace EVNTalent.Services.Common.Infrastructure
{
    using AutoMapper;
    using EVNTalent.Services.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    public abstract class AppIRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected readonly IApplicaitonDbContext _data;
        protected readonly IConfigurationProvider _mapper;

        protected AppIRequestHandler(IApplicaitonDbContext data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper.ConfigurationProvider;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
