namespace EVNTalent.Services.Common.ValidationHandler
{
    using EVNTalent.Domain.Enums;
    using EVNTalent.Services.CandidateCommands.Command;
    using FluentValidation;
    using System;
  public  class ValidationCandidateCreate :AbstractValidator<AddCandidateCommand>
    {
        public ValidationCandidateCreate()
        {
            RuleFor(user => user.FirstName)
               .NotNull()
               .NotEmpty();
            RuleFor(user => user.MiddleName)
             .NotNull()
             .NotEmpty();
            RuleFor(user => user.LastName)
             .NotNull()
             .NotEmpty();

            RuleFor(user => user.DepartmentName)
                .NotNull()
                .NotEmpty()
                .IsEnumName(typeof(DepartmentEnum));

            RuleFor(user => user.Education)
                .NotNull()
                .NotEmpty();

            RuleFor(user => user.Score)
                .NotNull()
                .InclusiveBetween(1, 10);

            RuleFor(user => user.BirthDate)
                .NotNull()
                .InclusiveBetween(DateTime.Parse("1970/01/01"), DateTime.Parse("2003/01/01"));
        }
    }
}
