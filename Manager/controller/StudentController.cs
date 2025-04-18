using Manager.dto;
using Manager.model;
using Manager.service;
using Microsoft.AspNetCore.Mvc;

namespace Manager.controller;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly StudentService _studentService;

    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }

    //GET METHOD
    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetAll()
    {
        return Ok(_studentService.GetAllStudents());
    }

    [HttpGet("{id}")]
    public ActionResult<Student> GetById(int id)
    {
        var student = _studentService.GetStudentById(id);
        if (student == null)
            return NotFound();
        return Ok(student);
    }

    //POST METHOD
    [HttpPost]
    public ActionResult<Student> Create([FromBody] StudentDTO studentDto)
    {
        var student = _studentService.AddStudent(studentDto);
        return CreatedAtAction(nameof(GetById), new { id = student.studentId }, student);
    }

    //PUT METHOD
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<Student> UpdateStudent(int id, 
        [FromBody] StudentDTO.UpdateStudentDTO studentDto)
    {
        try
        {
            if (id != studentDto.Id)
                return BadRequest("ID mismatch");

            var updatedStudent = _studentService.UpdateStudent(studentDto);
            if (updatedStudent == null)
                return NotFound("Student not found");

            return Ok(updatedStudent);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    //DELETE METHOD
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult DeleteStudent(int id)
    {
        try
        {
            var result = _studentService.DeleteStudent(id);
            if (!result)
                return NotFound("Student not found");

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}