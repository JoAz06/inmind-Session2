using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using inmind_Session2.Models;
using Microsoft.AspNetCore.Identity;

namespace inmind_Session2.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsController : Controller
{
    public static List<Student> ListOfStudents = new()
    {
        new Student(1, "John Smith"),
        new Student(2, "John Baker"),
        new Student(3, "John Doh"),
        new Student(4, "John Naples"),
        new Student(5, "Jane Doh")
    };

    [HttpGet]
    public ActionResult<List<Student>> GetALlStudents()
    {
        return Ok(ListOfStudents);
    }

    [HttpGet("{Id:int}")]
    public ActionResult<Student> GetStudentById([FromRoute] int Id)
    {
        var student = ListOfStudents.FirstOrDefault(x => x.Id == Id);
        if (student != null)
        {
            return Ok(student);
        }
        return NotFound();
    }
    
    [HttpGet("search")]
    public ActionResult<List<Student>> SearchStudents([FromQuery] string name)
    {
        if(string.IsNullOrEmpty(name))
            return BadRequest("Name cant be  null or empty");
        List<Student> filteredStudents = ListOfStudents.Where(x => x.name.ToLower().Contains(name.ToLower())).ToList();
        if (filteredStudents.Count == 0)
            return NotFound();
        return Ok(filteredStudents);
    }

    [HttpGet("date")]
    public ActionResult<string> GetDate()
    {
        var acceptedLanguage =
            Request.Headers["Accept-Language"].ToString().Split(",")
                [0]; // split because if multiple languages are added to a browser all of the show.
        try
        {
            return Ok(DateTime.Today.ToString("D", new CultureInfo(acceptedLanguage)));
        }
        catch (Exception e)
        {
            return BadRequest("Unknown Language");
        }
    }
    
    
    
    [HttpGet("remove")]
    public ActionResult<Student> DeleteStudentById([FromQuery] int Id)
    {
        var student = ListOfStudents.FirstOrDefault(x => x.Id == Id);
        if (student != null)
        {
            ListOfStudents.Remove(student);
            return Ok();
        }
        return NoContent();
    }

}