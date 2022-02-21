
namespace EVNTalent.Tests
{
    using EVNTalent.Services.DepartmentCommands.Commands;
    using EVNTalent.Services.DepartmentCommands.Query.DepartmentList;
    using FluentAssertions;
    using MediatR;
    using Moq;
    using NUnit.Framework;
    using System.Threading.Tasks;
 public   class ServiceDeaprtmentTest
    {
        IMediator _mediator;
        [SetUp]
        public void Setup()
        {
            _mediator = 
                new Mock<IMediator>().Object;
        }
        [Test]
        public void GetAllDepartment()
        {
            var result = _mediator.Send(new DepartmentListQuery());
            result.Should().BeOfType<Task<DepartmentListQueryResult>>();
        }
        [Test]
        public void AddDepartment()
        {
             var result =_mediator.Send(new AddDepartmentsCommand() { Name = "HI", Code = 2 });
            result.Should().BeOfType<Task<int>>();
        }
    }
}
