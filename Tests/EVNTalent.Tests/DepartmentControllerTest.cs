namespace EVNTalent.Tests
{
    using EVNTalent.Web.Controllers;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Threading.Tasks;
    using EVNTalent.Services.DepartmentCommands.Commands;

    public class DepartmentControllerTest
    {
        DepartmentsController _controller;
        [SetUp]
        public void Setup()
        {
            _controller = new DepartmentsController(new Mock<IMediator>().Object);
        }

         [Test]
        public void GetAllTest()
        {
          var result=
                _controller.GetListController();
            result.Should().BeOfType<Task<IActionResult>>();
            result.Result.Should().BeOfType<OkObjectResult>();
        }
        [Test]
        public void AddDepartmentTest()
        {
            var result =
                  _controller.AddDepartment(new AddDepartmentsCommand());
            result.Should().BeOfType<Task<IActionResult>>();
        }
    }
}
