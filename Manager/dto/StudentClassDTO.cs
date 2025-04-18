using System.ComponentModel.DataAnnotations;

namespace Manager.dto;

public class StudentClassDTO
{
    [Required]
    public int studentId { get; set; }
    
    [Required]
    public int classId { get; set; }
    
    public class addStudent 
    {
        [Required]
        public int ClassId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "List of student must have at least one student.")]
        public List<int> StudentIds { get; set; }
    }
}