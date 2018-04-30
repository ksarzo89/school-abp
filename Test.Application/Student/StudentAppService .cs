using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Student.Dtos;

namespace Test.Student
{
    public class StudentAppService : ApplicationService, IStudentAppService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IRepository<Group.Group> _groupRepository;

        public StudentAppService(IStudentRepository studentRepository, IRepository<Group.Group> groupRepository)
        {
            _studentRepository = studentRepository;
            _groupRepository = groupRepository;
        }

        public async Task CreateStudent(CreateStudentInput input)
        {
            var group = _groupRepository.Get(input.AssignedGroupId);

            var student = input.MapTo<Student>();
            group.Students.Add(student);

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteStudent(int idStudent)
        {
            await _studentRepository.DeleteAsync(idStudent);
        }

        public IListResult<StudentDto> GetAllStudents()
        {
            var students = _studentRepository.GetAll().OrderBy(s => s.FullName).ToList();
            return new ListResultDto<StudentDto>(students.MapTo<List<StudentDto>>());
        }

        public IListResult<StudentDto> GetStudents(GeStudentsInput input)
        {
            var students = _studentRepository.GetAllWithGroup(input.AssignedGroupId).ToList();
            return new ListResultDto<StudentDto>(students.MapTo<List<StudentDto>>());
        }

        public void UpdateStudent(UpdateStudentInput input)
        {
            var student = _studentRepository.Get(input.StudentId);

            if (input.FullName != "")
                student.FullName = input.FullName;

            if (input.CI.HasValue)
                student.CI = input.CI.Value;

            if (input.Age.HasValue)
                student.Age = input.Age.Value;

            if (input.AssignedGroupId.HasValue)
                student.AssignedGroup = _groupRepository.Load(input.AssignedGroupId.Value);
            else
                student.AssignedGroup = null;
        }
    }
}
