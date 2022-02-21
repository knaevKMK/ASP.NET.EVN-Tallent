namespace EVNTalent.Tests
{
    using EVNTalent.Services.CandidateCommands.Command;
    using EVNTalent.Services.CandidateCommands.Queriy.CandidateList;
    using EVNTalent.Services.CandidateCommands.Queriy.CanidateBy;
    using EVNTalent.Services.CandidateCommands.Queriy.FilterCandidate;
    using FluentAssertions;
    using MediatR;
    using Moq;
    using NUnit.Framework;
    using System.Threading.Tasks;

    public   class ServiceCandidateTest
    {
        private const string Id = "d3b9938e-87d2-4fbc-6b18-08d9a1338ea6";
        IMediator _mediator;
        [SetUp]
        public void Setup()
        {
            _mediator = new Mock<IMediator>().Object;
        }
        [Test]
        public void GetAllCandidates()
        {
            var result = _mediator.Send(new CandidateListQuery());
            result.Should().BeOfType<Task<CandidateListQueryResult>>();
        }
        [Test]
        public void GetByIdCandidate()
        {
            var result = _mediator.Send(new CandidateByIdQuery());
            result.Should().BeOfType<Task<CandidateByIdQueryResult>>();
        }
        [Test]
        public void GetFilteredCandidate()
        {
            var result = _mediator.Send(new FilterCandidateQeury());
            result.Should().BeOfType<Task<CandidateListQueryResult>>();
        }
        [Test]
        public void GetSortedCandidate()
        {
            var result = _mediator.Send(new SortByCandidateQuery());
            result.Should().BeOfType<Task<CandidateListQueryResult>>();
        }

        [Test]
        public void AddCandidate()
        {
            var result = _mediator.Send(new AddCandidateCommand());
            result.Should().BeOfType<Task<string>>();
        }
        [Test]
        public void EditCandidate()
        {
            var result = _mediator.Send(new EditCandidateCommand());
            result.Should().BeOfType<Task<string>>();
        }
        [Test]
        public void DeleteCandidate()
        {
            var result = _mediator.Send(new DeleteCandidateCommand());
            result.Should().BeOfType<Task<int>>();
        }


    }
}
