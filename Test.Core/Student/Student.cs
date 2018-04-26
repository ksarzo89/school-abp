using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Student
{
    [Table("AppStudent")]
    public class Student : Entity
    {
        public virtual string FullName { get; set; }

        public virtual long CI { get; set; }

        public virtual int Age { get; set; }

        [ForeignKey("AssignedGroupId")]
        public virtual Test.Group.Group AssignedGroup { get; set; }

        public virtual int? AssignedGroupId { get; set; }
    }
}
