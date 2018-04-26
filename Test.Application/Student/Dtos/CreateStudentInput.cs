using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Student.Dtos
{
    public class CreateStudentInput
    {
        public string FullName { get; set; }

        public long CI { get; set; }

        public int Age { get; set; }

        public int? AssignedGroupId { get; set; }
    }
}
