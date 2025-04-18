using System.ComponentModel.DataAnnotations;

namespace Manager.dto;

public class StudentDTO
{
    [Required]
    [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public string studentName { get; set; }
    
    [Required]
    public string studentCode { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime studentDoB { get; set; }
    
    public class UpdateStudentDTO : StudentDTO
    {
        [Required]
        public int Id { get; set; }
    }
}