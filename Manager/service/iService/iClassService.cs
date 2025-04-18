using Manager.dto;
using Manager.model;

namespace Manager.service.iService;

public interface iClassService
{
    List<Class> GetAllClasses();
    Class GetClassById(int id);
    Class AddClass(ClassDTO classDto);
    Class UpdateClass(ClassDTO.UpdateClassDTO classDto);
    bool DeleteClass(int id);
    bool AddStudentToClass(StudentClassDTO studentClassDto);
    bool AddStudentsToClass(StudentClassDTO.addStudent addStudentsDto);
    List<Student> GetStudentsInClass(int classId);
}