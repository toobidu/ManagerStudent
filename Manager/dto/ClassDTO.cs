using System.ComponentModel.DataAnnotations;

namespace Manager.dto;

public class ClassDTO
{
    [Required]
    [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public string className { get; set; }

    [Required]
    [MinLength(5, ErrorMessage = "Code must be at least 5 characters long.")]
    public string classCode { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Number of students must be greater than 0.")]
    public int maxStudents { get; set; }

    public class UpdateClassDTO : ClassDTO
    {
        [Required] public int Id { get; set; }
    }
}