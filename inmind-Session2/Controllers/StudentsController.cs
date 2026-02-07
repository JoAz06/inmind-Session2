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
        new Student(1,"John Smith"),
        new Student(2,"Jane Doh")
    };

    [HttpGet]
    public ActionResult<List<Student>> GetALlStudents()
    {
        return Ok(ListOfStudents);
    }

}