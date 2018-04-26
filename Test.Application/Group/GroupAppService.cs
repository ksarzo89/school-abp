using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Castle.Core.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Group.Dtos;

namespace Test.Group
{
    public class GroupAppService : IGroupAppService
    {
        private readonly IRepository<Group> _groupRepository;

        //ABP provides that we can directly inject IRepository<Person> (without creating any repository class)
        public GroupAppService(IRepository<Group> groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public void CreateGroup(GroupDto input)
        {
            var group = new Group { Name = input.Name };

            _groupRepository.Insert(group);
        }

        public void DeleteGroup(int idGroup)
        {
            _groupRepository.Delete(idGroup);
        }

        public void UpdateGroup(UpdateGroupInput input)
        {
            var group = _groupRepository.Get(input.GroupId);

            if (input.Name != "")
                group.Name = input.Name;
        }

        public async Task<GetAllGroupOutput> GetAllGroup()
        {
            var groups = await _groupRepository.GetAllListAsync();
            return new GetAllGroupOutput
            {
                Groups = groups.MapTo<List<GroupDto>>()
            };
        }
    }
}
