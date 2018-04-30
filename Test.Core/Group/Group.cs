using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Group
{
    [Table("AppGroup")]
    public class Group : FullAuditedEntity
    {
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Student.Student> Students { get; set; }

    }
}
