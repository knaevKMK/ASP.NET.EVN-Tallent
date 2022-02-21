using EVNTalent.Services.Common.ValidationHandler;
using EVNTalent.Web.Controllers;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using EVNTalent.Services.CandidateCommands.Command;
using System.Threading.Tasks;
using EVNTalent.Services.CandidateCommands.Queriy.FilterCandidate;

namespace EVNTalent.Tests
{
  public  class CandidateControllerTest
    {
        private const string id = "d3b9938e-87d2-4fbc-6b18-08d9a1338ea6";
        CandidateController _controller;
        AddCandidateCommand _creator;
        [SetUp]
        public void Setup()
        {
            _creator = new AddCandidateCommand();
            _controller = new CandidateController(new Mock<IMediator>().Object
                , new Mock<ValidationCandidateCreate>().Object);
        }

        [Test]
        public void GetAllTest()
        {
            var result =
                  _controller.GetAll();
            result.Should().BeOfType<Task<IActionResult>>();
            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void Create()
        {
            var result = _controller.Create(_creator);
           result.Should().BeOfType<Task<IActionResult>>();
        }
        [Test]
        public void Deatails()
        {
            var result = _controller.DetailsById(id);
            result.Should().BeOfType<Task<IActionResult>>();
        }
        [Test]
        public void Delete()
        {
            var result = _controller.Delete(id);
            result.Should().BeOfType<Task<IActionResult>>();
        }
        [Test]
        public void Update()
        {
            var result = _controller.Update(id, new EditCandidateCommand());
            result.Should().BeOfType<Task<IActionResult>>();
        }
        [Test]
        public void Filter()
        {
            var result = _controller.filter( new FilterCandidateQeury());
            result.Should().BeOfType<Task<IActionResult>>();
        }
        [Test]
        public void Sort()
        {
            var result = _controller.Sort("name asc");
            result.Should().BeOfType<Task<IActionResult>>();
        }
    }
}
