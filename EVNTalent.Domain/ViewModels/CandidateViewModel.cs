namespace EVNTalent.Domain.ViewModels
{
using System;
  public  class CandidateViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string DepartmentName { get; set; }
        public string Code { get; set; }
        public string Education { get; set; }
        public DateTime BirthDate { get; set; }
        public int Score { get; set; }
        public bool IsDeleted { get; set; }

    }
}
