using Manager.dto;
using Manager.model;
using Manager.service.iService;

namespace Manager.service;

public class StudentService : iStudentService
{
    private static List<Student> students = new List<Student>();
    private static List<StudentClass> studentClasses = new List<StudentClass>();
    private static int nextStudentId = 1;

    // Lấy danh sách tất cả sinh viên
    public List<Student> GetAllStudents()
    {
        return students;
    }

    // Lấy danh sách sinh viên theo mã sinh viên
    public Student GetStudentById(int id)
    {
        return students.FirstOrDefault(s => s.studentId == id);
    }

    // Thêm sinh viên
    public Student AddStudent(StudentDTO studentDto)
    {
        var student = new Student
        {
            studentId = nextStudentId++, // Tự động tăng ID
            studentName = studentDto.studentName,
            studenCode = studentDto.studentCode,
            studentDoB = studentDto.studentDoB
        };

        //Thêm sinh viên
        students.Add(student);
        return student;
    }

    // Sửa thông tin sinh viên
    public Student UpdateStudent(StudentDTO.UpdateStudentDTO studentDto)
    {
        var student = students.FirstOrDefault(s => s.studentId == studentDto.Id);
        if (student == null)
            return null;

        student.studentName = studentDto.studentName;
        student.studenCode = studentDto.studentCode;
        student.studentDoB = studentDto.studentDoB;

        return student;
    }

    // Xóa sinh viên theo ID
    public bool DeleteStudent(int id)
    {
        var student = students.FirstOrDefault(s => s.studentId == id);
        if (student == null)
            return false;

        // Xóa sinh viên khỏi các lớp học
        studentClasses.RemoveAll(sc => sc.studentId == id);

        // Xóa sinh viên khỏi danh sách sinh viên
        students.Remove(student);
        return true;
    }
    // Xóa sinh viên khỏi lớp học
    public void RemoveStudentClassesByClassId(int classId)
    {
        studentClasses.RemoveAll(sc => sc.classId == classId);
    }
}
