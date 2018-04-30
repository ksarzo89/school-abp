using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Test.Group.Dtos
{
    [AutoMapFrom(typeof(Group))]
    public class GroupDto : FullAuditedEntityDto
    {
        public string Name { get; set; }

        public Collection<Student.Dtos.StudentDto> Students { get; set; }
    }
}
