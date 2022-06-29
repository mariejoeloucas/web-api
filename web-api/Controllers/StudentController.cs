using System.Globalization;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using web_api.Exception;
using web_api.Models;
using web_api.Services;


namespace web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    

    public static List<Student> Students = new List<Student>
        {
            new Student() { Id = 1, Name = "yara", Email = "yara@gmail.com" },
            new Student() { Id = 2, Name = "ara", Email = "hello@hotmail" }
        };

        public static IStudentHelper _studentHelper;


        public static IWebHostEnvironment _hostingEnvironment; 

        public StudentsController(IStudentHelper studentHelper, IWebHostEnvironment hostingEnvironment)
        {
            _studentHelper = studentHelper;
            _hostingEnvironment = hostingEnvironment;
        }
        

        [HttpGet()]
        public async Task<List<Student>> GetAllStudent()
        {
            return await _studentHelper.GetAllStudent(Students);
        }

        [HttpGet("{id:int}")]
        public async Task<Student> GetStudentById([FromRoute] int id)
        {
            return await _studentHelper.GetStudentById(Students, id);
        }

        [HttpGet("GetStudentByName")]
        public async Task<List<Student>> GetThatContains([FromQuery] string seq)
        {
            return await _studentHelper.GetThatContains(Students, seq);
        }

        [HttpGet("GetDate")]
        public async Task<string> GetDate([FromHeader] string culture)
        {
            return await _studentHelper.GetDate(culture);
        }

        [HttpPost("Replace")]
        public async Task<List<Student>> Replace([FromBody] UpdateStudent request)
        {
            return await _studentHelper.Replace(Students, request);

        }

        [HttpPost()]
        public async Task<List<Student>> AddStudent([FromBody] Student student)
        {
            return await _studentHelper.AddStudent(Students, student);

        }

        [HttpPost("UploadImage")]
        public async Task<string> Upload([FromForm] UploadImageModel image)
        {
            return await _studentHelper.Upload(_hostingEnvironment, image);
        }

        [HttpDelete]
        public async Task<List<Student>> Delete([FromQuery] int id)
        {
            return await _studentHelper.Delete(Students, id);
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




