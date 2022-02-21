namespace EVNTalent.Tests
{
using EVNTalent.Services.Common.ValidationHandler;
using EVNTalent.Services.DepartmentCommands.Commands;
using NUnit.Framework;
using FluentValidation.Results;
using FluentAssertions;
    public class ValidationDeparmetntTests
    {
        ValidationDeparmetntAdd _departmentDtoValidator;
        [SetUp]
        public void Setup()
        {
            _departmentDtoValidator = new ValidationDeparmetntAdd();
        }
        [Test]
        public void ValidateDepartmentWithNullParams()
        {
            ValidationResult validationResult =
                _departmentDtoValidator.Validate(new AddDepartmentsCommand());
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Should().NotBeEmpty();
        }
        [Test]
        public void ValidateDepartmentWithEmptyParams()
        {
            ValidationResult validationResult =
                _departmentDtoValidator.Validate(new AddDepartmentsCommand()
                    { Name=""});
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Should().NotBeEmpty();
        }
        [Test]
        public void ValidateDepartmentWithValidParams()
        {
            ValidationResult validationResult =
                _departmentDtoValidator.Validate(new AddDepartmentsCommand()
                { Name = "DI", Code=3 });
            validationResult.IsValid.Should().BeTrue();
            validationResult.Errors.Should().BeEmpty();
        }
    }
}