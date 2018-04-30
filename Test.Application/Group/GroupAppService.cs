using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Test.Group.Dtos;

namespace Test.Group
{
    public class GroupAppService : IGroupAppService
    {
        private readonly IRepository<Group> _groupRepository;

        public GroupAppService(IRepository<Group> groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task CreateGroup(GroupDto input)
        {
            var group = input.MapTo<Group>();
            await _groupRepository.InsertAsync(group);
        }

        public async Task DeleteGroup(int idGroup)
        {
            await _groupRepository.DeleteAsync(idGroup);
        }

        public void UpdateGroup(UpdateGroupInput input)
        {
            var group = _groupRepository.Get(input.GroupId);

            if (input.Name != "")
                group.Name = input.Name;
        }

        public IListResult<GroupDto> GetAllGroup()
        {
            var groups = _groupRepository
                .GetAll()
                .Include(g => g.Students)
                .OrderBy(g => g.Name)
                .ToList();
            return new ListResultDto<GroupDto>(groups.MapTo<List<GroupDto>>());
        }
    }
}
