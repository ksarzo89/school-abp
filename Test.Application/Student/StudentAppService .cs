using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using AutoMapper;
using System.Collections.Generic;
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

        public void CreateStudent(CreateStudentInput input)
        {
            Logger.Info("Creating a student for input: " + input);

            var student = new Student { FullName = input.FullName,  CI = input.CI, Age = input.Age, };

            if (input.AssignedGroupId.HasValue)
            {
                student.AssignedGroupId = input.AssignedGroupId.Value;
            }

            _studentRepository.Insert(student);
        }

        public void DeleteStudent(int idStudent)
        {
            _studentRepository.Delete(idStudent);
        }

        public async Task<GetStudentsOutput> GetAllStudents()
        {
            var students = await _studentRepository.GetAllListAsync();
            return new GetStudentsOutput
            {
                Students = students.MapTo<List<StudentDto>>()
            };
        }

        public GetStudentsOutput GetStudents(GeStudentsInput input)
        {
            var tasks = _studentRepository.GetAllWithGroup(input.AssignedGroupId);

            return new GetStudentsOutput
            {
                Students = Mapper.Map<List<StudentDto>>(tasks)
            };
        }

        public void UpdateStudent(UpdateStudentInput input)
        {
            Logger.Info("Updating a student for input: " + input);

            var student = _studentRepository.Get(input.StudentId);

            if (input.FullName != "")
                student.FullName = input.FullName;

            if (input.CI.HasValue)
                student.CI = input.CI.Value;

            if (input.Age.HasValue)
                student.Age = input.Age.Value;

            if(input.AssignedGroupId.HasValue)
                student.AssignedGroup = _groupRepository.Load(input.AssignedGroupId.Value);
        }
    }
}
