using Abp.Application.Services;
using System.Threading.Tasks;
using Test.Group.Dtos;

namespace Test.Group
{
    public interface IGroupAppService : IApplicationService
    {
        Task<GetAllGroupOutput> GetAllGroup();

        void CreateGroup(GroupDto input);

        void UpdateGroup(UpdateGroupInput input);

        void DeleteGroup(int idGroup);
    }
}
