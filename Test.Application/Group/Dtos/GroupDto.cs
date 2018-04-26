using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Test.Group.Dtos
{
    [AutoMapFrom(typeof(Group))]
    public class GroupDto : EntityDto
    {
        public string Name { get; set; }
    }
}
