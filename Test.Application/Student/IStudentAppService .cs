using Abp.Application.Services;
using System.Threading.Tasks;
using Test.Student.Dtos;

namespace Test.Student
{
    public interface IStudentAppService : IApplicationService
    {
        Task<GetStudentsOutput> GetAllStudents();
        GetStudentsOutput GetStudents(GeStudentsInput input);
        void UpdateStudent(UpdateStudentInput input);
        void CreateStudent(CreateStudentInput input);
        void DeleteStudent(int idStudent);
    }
}
