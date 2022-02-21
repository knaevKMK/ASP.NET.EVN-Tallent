
namespace EVNTalent.Domain.Entities
{
using System;
    public abstract class BaseEntity
    {
        

        public bool IsDeleted { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
