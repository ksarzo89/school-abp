using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using Test.Student.Dtos;

namespace Test.Student
{
    public interface IStudentAppService : IApplicationService
    {
        IListResult<StudentDto> GetAllStudents();
        IListResult<StudentDto> GetStudents(GeStudentsInput input);
        void UpdateStudent(UpdateStudentInput input);
        Task CreateStudent(CreateStudentInput input);
        Task DeleteStudent(int idStudent);
    }
}
