using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Group
{
    [Table("AppGroup")]
    public class Group : Entity
    {
        public string Name { get; set; }
    }
}
