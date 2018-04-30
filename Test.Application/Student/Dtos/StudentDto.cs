using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Test.Student.Dtos
{
    [AutoMapFrom(typeof(Student))]
    public class StudentDto : CreationAuditedEntityDto
    {
        public string FullName { get; set; }

        public long CI { get; set; }

        public int Age { get; set; }

        public string AssignedGroupName { get; set; }

        public int AssignedGroupId { get; set; }
    }
}
