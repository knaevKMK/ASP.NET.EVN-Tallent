using EVNTalent.Services.DepartmentCommands.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVNTalent.Services.Common.ValidationHandler
{
   public class ValidationDeparmetntAdd : AbstractValidator<AddDepartmentsCommand>
    {
        public ValidationDeparmetntAdd()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .NotNull();
           
        }
    }
}
