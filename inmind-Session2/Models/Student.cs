using System.ComponentModel.DataAnnotations;
namespace inmind_Session2.Models;
public class Student
{
    public int Id  { get; set; }
    [Required]
    public string name { get; set; }
    //iform file?

    public Student(int Id, string name)
    {
        this.Id = Id;
        this.name = name;
    }
}