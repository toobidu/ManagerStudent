using Manager.dto;
using Manager.model;

namespace Manager.service.iService;

public interface iStudentService
{
    List<Student> GetAllStudents();
    Student GetStudentById(int id);
    Student AddStudent(StudentDTO studentDto);
    Student UpdateStudent(StudentDTO.UpdateStudentDTO studentDto);
    bool DeleteStudent(int id);
}