using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Student
{
    [Table("AppStudent")]
    public class Student : CreationAuditedEntity
    {
        [Required]
        public virtual string FullName { get; set; }

        [Required]
        public virtual long CI { get; set; }

        [Required]
        public virtual int Age { get; set; }

        [ForeignKey("AssignedGroupId")]
        public virtual Test.Group.Group AssignedGroup { get; set; }

        public virtual int? AssignedGroupId { get; set; }
    }
}
