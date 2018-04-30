using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Abp.EntityFramework;

namespace Test.EntityFramework.Repositories
{
    public class StudentRepository : TestRepositoryBase<Student.Student>, Student.IStudentRepository
    {
        public StudentRepository(IDbContextProvider<TestDbContext> dbContextProvider)
               : base(dbContextProvider)
        {
        }

        public List<Student.Student> GetAllWithGroup(int? assignedGroupId)
        {
            var query = GetAll(); 

            if (assignedGroupId.HasValue)
            {
                query = query.
                    Where(student => student.AssignedGroup.Id == assignedGroupId.Value);
            }

            return query
                .Include(student => student.AssignedGroup)
                .OrderBy(student => student.Age)
                .ToList();
        }
    }
}
