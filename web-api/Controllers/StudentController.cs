using System.Net;
using Microsoft.AspNetCore.Mvc;
using web_api.Exception;
using web_api.Models;



namespace web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    public static readonly List<Student> Students = new List<Student>
    {
        new Student(){id=1, name = "yara", email="yara@gmail.com"},
        new Student(){id=2, name="lynn", email="hello@hotmail"}
    };
    
    [HttpGet]
    public async Task<List<Student>> GetStudents(){
        return Students;
    }
    
    [HttpGet("{id}")]
    public async Task<Student> GetStudent(int id)
    {
        Student? student = Students.Find((s) => s.id.Equals(id));
        if (student == null)
        {
            throw new StudentNotFoundException("Student not found!");
        }

        return student;
    }

    [HttpPost()]
    public async Task<List<Student>> Replace([FromBody] updateStudent request)
    {
        long id = request.id;
        string name = request.name;
        string email = request.email;
        Student? temp = null;
        try
        {
            foreach (Student st in Students)
            {
                if (st.id == id)
                {
                    temp = st;
                }
            }

            if (temp != null)
            {
                temp.name = name;
                temp.email = email;
            }
            else
            {
                throw new StudentNotFoundException("Not found");
            }
        }
            catch (System.Exception e)
            {
                Console.WriteLine($"error:" + e.Message);
                
            }

        return null;
    }






    // String message = comments.Where(obj => obj.Id == 3)
    //     .Select(x => x.Message)
    //     .First();
    
    
   // private readonly ILogger<StudentController> _logger;

   // public StudentsController(ILogger<StudentController> logger)
    //{
    //    _logger = logger;
   // }
    
    
}


