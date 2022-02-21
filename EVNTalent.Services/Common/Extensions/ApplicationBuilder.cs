
namespace EVNTalent.Services.Common.Extensions
{
    using EVNTalent.Domain.Enums;
    using EVNTalent.Services.Common.Infrastructure;
    using EVNTalent.Services.DepartmentCommands.Commands;
    using MediatR;
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilder
    {
        public static IApplicationBuilder PrepareDatabse(this IApplicationBuilder app, IMediator mediatR)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var data = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            data.Database.EnsureCreated();
            data.Database.Migrate();

            SeedData(data, mediatR);

            return app;
        }

        private static void SeedData(ApplicationDbContext data, IMediator mediator)
        {
            if (data.Departments.Any())
            {
                return;
            }
            foreach (var departmentEnum in Enum.GetValues(typeof(DepartmentEnum)))
            {
                mediator.Send(new AddDepartmentsCommand()
                {
                    Name = departmentEnum.ToString(),
                    Code = (int)departmentEnum
                });
            }
        }
    }
}
