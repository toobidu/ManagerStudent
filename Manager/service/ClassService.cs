using Manager.dto;
using Manager.model;
using Manager.service.iService;

namespace Manager.service;

public class ClassService : iClassService
{
    private static List<Class> classes = new List<Class>();
    private static List<StudentClass> studentClasses = new List<StudentClass>();
    private static int nextClassId = 1;
    private static int nextStudentClassId = 1;

    public List<Class> GetAllClasses()
    {
        return classes;
    }
    
    public Class GetClassById(int id)
    {
        return classes.FirstOrDefault(c => c.classId == id);
    }

    public Class AddClass(ClassDTO classDto)
    {
        var newClass = new Class
        {
            classId = nextClassId++,
            className = classDto.className,
            classCode = classDto.classCode,
            maxStudents = classDto.maxStudents
        };

        classes.Add(newClass);
        return newClass;
    }

    public Class UpdateClass(ClassDTO.UpdateClassDTO classDto)
    {
        var classToUpdate = classes.FirstOrDefault(c => c.classId == classDto.Id);
        if (classToUpdate == null)
            return null;

        classToUpdate.className = classDto.className;
        classToUpdate.classCode = classDto.classCode;
        classToUpdate.maxStudents = classDto.maxStudents;

        return classToUpdate;
    }

    public bool DeleteClass(int id)
    {
        var classToDelete = classes.FirstOrDefault(c => c.classId == id);
        if (classToDelete == null)
            return false;
        
        studentClasses.RemoveAll(sc => sc.classId == id);
        classes.Remove(classToDelete);
        return true;
    }

    public bool AddStudentToClass(StudentClassDTO studentClassDto)
    {
        var classObj = classes.FirstOrDefault(c => c.classId == studentClassDto.classId);
        if (classObj == null)
            return false;

        if (studentClasses.Any(sc => 
            sc.studentId == studentClassDto.studentId && 
            sc.classId == studentClassDto.classId))
            return false;

        var studentsInClass = studentClasses.Count(sc => sc.classId == studentClassDto.classId);
        if (studentsInClass >= classObj.maxStudents)
            return false;

        var studentClass = new StudentClass
        {
            id = nextStudentClassId++,
            studentId = studentClassDto.studentId,
            classId = studentClassDto.classId
        };

        studentClasses.Add(studentClass);
        return true;
    }

    public bool AddStudentsToClass(StudentClassDTO.addStudent addStudentsDto)
    {
        var classObj = classes.FirstOrDefault(c => c.classId == addStudentsDto.ClassId);
        if (classObj == null)
            return false;

        var currentStudentsCount = studentClasses.Count(sc => sc.classId == addStudentsDto.ClassId);
        
        if (currentStudentsCount + addStudentsDto.StudentIds.Count > classObj.maxStudents)
            return false;

        foreach (var studentId in addStudentsDto.StudentIds)
        {
            if (studentClasses.Any(sc => 
                sc.studentId == studentId && 
                sc.classId == addStudentsDto.ClassId))
                continue;

            var studentClass = new StudentClass
            {
                id = nextStudentClassId++,
                studentId = studentId,
                classId = addStudentsDto.ClassId
            };

            studentClasses.Add(studentClass);
        }

        return true;
    }

    public List<Student> GetStudentsInClass(int classId)
    {
        var studentService = new StudentService();
        var students = studentService.GetAllStudents();

        var studentsInClass = from sc in studentClasses
                             join s in students on sc.studentId equals s.studentId
                             where sc.classId == classId
                             select s;

        return studentsInClass.ToList();
    }
}