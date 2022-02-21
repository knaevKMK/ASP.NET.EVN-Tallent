namespace EVNTalent.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public   class Candidate : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First Name required")]
        [StringLength(20, ErrorMessage = "First Name max length 20 chars")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Middle Name required")]
        [StringLength(20, ErrorMessage = "Middle Name max length 20 chars")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name required")]
        [StringLength(20, ErrorMessage = "Last Name max length 20 chars")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Code required")]
        [StringLength(11, ErrorMessage = "Code max length is 11 chars")]
        public string Code { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }


        [Required(ErrorMessage = "Edication required")]
        [StringLength(20, ErrorMessage = "Education max length is 20 chars")]
        public string Education { get; set; }

        [Range(0, 10, ErrorMessage = "Score must be positive with max value 10")]
        public int Score { get; set; }


        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department required")]
        public Department Department { get; set; }
    }
}

