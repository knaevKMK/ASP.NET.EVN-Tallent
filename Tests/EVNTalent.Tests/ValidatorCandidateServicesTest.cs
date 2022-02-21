
namespace EVNTalent.Tests
{
using EVNTalent.Services.CandidateCommands.Command;
using EVNTalent.Services.Common.ValidationHandler;
using NUnit.Framework;
using FluentValidation.Results;
using FluentAssertions;
using System;
    public class ValidatorCandidateServicesTest
    {

       
        ValidationCandidateCreate _candidateDtoValidator;
       


        [SetUp]
        public void Setup() {
            _candidateDtoValidator = new ValidationCandidateCreate();
           
        }

        [Test]
        public void ValidateCandidateWithNullParams()
        {
            ValidationResult validationResult =
                _candidateDtoValidator.Validate(new AddCandidateCommand());
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Should().NotBeEmpty();
        }
        [Test]
        public void ValidateCandidateWithEmptytParams()
        {
            var validationResult =
                  _candidateDtoValidator.Validate(new AddCandidateCommand()
                  {

                      FirstName = "",
                      MiddleName = "",
                      LastName = "",
                      Education = "",
                      DepartmentName = "",
                      Score = 0,
                    
                  }) ;
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Should().NotBeEmpty();
        }
        [Test]
        public void ValidateCandidateWithDeaprtmentNameNotValidParam()
        {
            var validationResult =
                  _candidateDtoValidator.Validate(new AddCandidateCommand()
                  {

                      FirstName = "Ivan",
                      MiddleName = "Ivanov",
                      LastName = "Ivanov",
                      Education = "Master",
                      DepartmentName = "Select...",
                      Score = 3,
                      BirthDate = DateTime.Parse("2000/01/01")

                  });
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Should().NotBeEmpty();
            validationResult.Errors.Should().HaveCount(1);
        }
        [Test]
        public void ValidateCandidateWithNegativeScoreParam()
        {
            var validationResult =
                  _candidateDtoValidator.Validate(new AddCandidateCommand()
                  {

                      FirstName = "Ivan",
                      MiddleName = "Ivanov",
                      LastName = "Ivanov",
                      Education = "Master",
                      DepartmentName = "CI",
                      Score = -3,
                      BirthDate = DateTime.Parse("2000/01/01")

                  });
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Should().NotBeEmpty();
            validationResult.Errors.Should().HaveCount(1);
        }
        [Test]
        public void ValidateCandidateWithValidParams()
        {
            var validationResult =
                  _candidateDtoValidator.Validate(new AddCandidateCommand()
                  {

                      FirstName = "Ivan",
                      MiddleName = "Ivanov",
                      LastName = "Ivanov",
                      Education = "Master",
                      DepartmentName = "CI",
                      Score = 3,
                      BirthDate=DateTime.Parse("2000/01/01")

                  });
            validationResult.IsValid.Should().BeTrue();
            validationResult.Errors.Should().BeEmpty();
        }

    }
}
