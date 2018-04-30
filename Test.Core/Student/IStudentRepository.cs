using Abp.Domain.Repositories;
using System.Collections.Generic;

namespace Test.Student
{
    public interface IStudentRepository : IRepository<Student>
    {
        List<Student> GetAllWithGroup(int? assignedGroupId);
    }
}
