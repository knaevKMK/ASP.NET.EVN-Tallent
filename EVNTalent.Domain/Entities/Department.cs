namespace EVNTalent.Domain.Entities
{
using System.ComponentModel.DataAnnotations;
   public class Department : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Department Name Required")]
        public string Name { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
    }
}
