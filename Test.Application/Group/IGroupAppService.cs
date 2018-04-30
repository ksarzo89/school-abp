using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using Test.Group.Dtos;

namespace Test.Group
{
    public interface IGroupAppService : IApplicationService
    {
        IListResult<GroupDto> GetAllGroup();

        Task CreateGroup(GroupDto input);

        void UpdateGroup(UpdateGroupInput input);

        Task DeleteGroup(int idGroup);
    }
}
