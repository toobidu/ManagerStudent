using Manager.dto;
using Manager.model;
using Manager.service;
using Microsoft.AspNetCore.Mvc;

namespace Manager.controller;

[ApiController]
[Route("api/[controller]")]
public class ClassController : ControllerBase
{
    private readonly ClassService _classService;

    public ClassController(ClassService classService)
    {
        _classService = classService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Class>> GetAllClasses()
    {
        try
        {
            var classes = _classService.GetAllClasses();
            return Ok(classes);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Class> GetClassById(int id)
    {
        try
        {
            var cls = _classService.GetClassById(id);
            if (cls == null)
                return NotFound("Class not found");

            return Ok(cls);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public ActionResult<Class> AddClass([FromBody] ClassDTO classDto)
    {
        try
        {
            var newClass = _classService.AddClass(classDto);
            return CreatedAtAction(nameof(GetClassById), new { id = newClass.classId }, newClass);
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

    [HttpPut("{id}")]
    public ActionResult<Class> UpdateClass(int id, [FromBody] ClassDTO.UpdateClassDTO classDto)
    {
        try
        {
            if (id != classDto.Id)
                return BadRequest("ID mismatch");

            var updatedClass = _classService.UpdateClass(classDto);
            if (updatedClass == null)
                return NotFound("Class not found");

            return Ok(updatedClass);
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

    [HttpDelete("{id}")]
    public ActionResult DeleteClass(int id)
    {
        try
        {
            var result = _classService.DeleteClass(id);
            if (!result)
                return NotFound("Class not found");

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("addStudent")]
    public ActionResult AddStudentToClass([FromBody] StudentClassDTO studentClassDto)
    {
        try
        {
            var result = _classService.AddStudentToClass(studentClassDto);
            if (!result)
                return BadRequest("Failed to add student to class");

            return Ok("Student added to class successfully");
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

    [HttpPost("addStudents")]
    public ActionResult AddMultipleStudentsToClass([FromBody] StudentClassDTO.addStudent addStudentsDto)
    {
        try
        {
            var result = _classService.AddStudentsToClass(addStudentsDto);
            if (!result)
                return BadRequest("Failed to add students to class");

            return Ok("Students added to class successfully");
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

    
    [HttpGet("{id}/students")]
    public ActionResult<IEnumerable<Student>> GetStudentsInClass(int id)
    {
        try
        {
            var students = _classService.GetStudentsInClass(id);
            return Ok(students);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
