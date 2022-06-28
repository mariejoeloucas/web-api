using System.Globalization;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using web_api.Exception;
using web_api.Models;



namespace web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    public static List<Student> Students = new List<Student>
    {
        new Student(){id=1, name = "yara", email="yara@gmail.com"},
        new Student(){id=2, name="ara", email="hello@hotmail"}
    };
    
    [HttpGet()]
    public async Task<List<Student>> GetStudents(){
        return Students;
    }
    
    [HttpGet("{id:int}")]
    public async Task<Student> GetStudent([FromRoute] int id)
    {
        Student? student = Students.Find((s) => s.id.Equals(id));
        if (student == null)
        {
            throw new StudentNotFoundException("Student not found!");
        }

        return student;
    }

    [HttpGet("GetStudentByName")]
    public async Task<List<Student>> GetThatContains([FromQuery] string seq)
    {
        List<Student> TheStudents = new List<Student>();
        //Student? student = Students.Find(s => s.name.Contains(seq));
        //Console.WriteLine(student);
        foreach (Student std in Students)
        {
            if (std.name.Contains(seq))
            {
                TheStudents.Add(std);
            }
        }
        // if (student != null)
        // {
        //    TheStudents.Add(student); 
        // }
        return TheStudents;
    
    }

    [HttpGet("GetDate")]
    public async Task<string> GetDate([FromHeader] string culture)
    {
        DateTime myDate = new DateTime();
        myDate=DateTime.Now;
        string date = myDate.ToString(new CultureInfo(culture));
        return date;
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
                return Students;
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


    // [HttpPost("UploadImage")]
    // public async Task<IActionResult> Upload([FromForm] IList<IFormFile> files) {
    //     string uploads = Path.Combine(wwwroot, "uploads");
    //     foreach (IFormFile file in files) {
    //         if (file.Length > 0) {
    //             string filePath = Path.Combine(uploads, file.FileName);
    //             using (Stream fileStream = new FileStream(filePath, FileMode.Create)) {
    //                 await file.CopyToAsync(fileStream);
    //             }
    //         }
    //     }
    //     return View();
    // }


    [HttpDelete]
    public async Task<List<Student>> Delete([FromQuery] int id)
    {
        List<Student> NewStudents = new List<Student>();
        foreach (Student std in Students)
        {
            if (std.id != id)
            {
                NewStudents.Add(std);
            }
            
        }

        Students = NewStudents;
        return Students;
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


