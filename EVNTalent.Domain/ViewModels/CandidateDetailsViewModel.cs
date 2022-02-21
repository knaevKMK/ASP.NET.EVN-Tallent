namespace EVNTalent.Domain.ViewModels
{
using System;
 public   class CandidateDetailsViewModel
    {

        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DepartmentName { get; set; }
        public string Code { get; set; }
        public string Education { get; set; }
        public DateTime BirthDate { get; set; }
        public int Score { get; set; }
    }
}
