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
        new Student() { id = 1, name = "yara", email = "yara@gmail.com" },
        new Student() { id = 2, name = "ara", email = "hello@hotmail" }
    };

    public static IStudentHelper _studentHelper;

    public StudentsController(IStudentHelper studentHelper)
    {
        _studentHelper = studentHelper;
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

    [HttpPost()]
    public async Task<List<Student>> Replace([FromBody] updateStudent request)
    {
        return await _studentHelper.Replace(Students, request);

    }

    [HttpPost("AddStudent")]
    public async Task<List<Student>> AddStudent([FromBody] Student student)
    {
        return await _studentHelper.AddStudent(Students, student);

    }






    public class ProfileController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;

        public ProfileController(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        //     [HttpPost("UploadImage")]
        //     public async Task<IActionResult> Upload(IList<IFormFile> files) {
        //         string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
        //         foreach (IFormFile file in files) {
        //             if (file.Length > 0) {
        //                 string filePath = Path.Combine(uploads, file.FileName);
        //                 using (Stream fileStream = new FileStream(filePath, FileMode.Create)) {
        //                     await file.CopyToAsync(fileStream);
        //                 }
        //             }
        //         }
        //         return View();
        //     }
        // }



        [HttpDelete]
        public async Task<List<Student>> Delete([FromQuery] int id)
        {
            return await _studentHelper.Delete(Students, id);
        }





        //
        // [HttpPost]
        // public async Task<IActionResult> AddProductAsync(ProductViewModel productvm, IFormFile file)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         //If you are using `<input id="file" type="file" name="file" />` to submit the image, you could get the image from the file.
        //         if (productvm.Image.Length > 0)
        //         { 
        //             using (var memoryStream = new MemoryStream())
        //             {
        //                 await productvm.Image.CopyToAsync(memoryStream);
        //
        //                 // Upload the file if less than 2 MB
        //                 if (memoryStream.Length < 2097152)
        //                 {
        //                     var product = new Product()
        //                     {
        //                         imageContent = memoryStream.ToArray()
        //                     };
        //
        //                     //_dbContext.Products.Add(product);
        //
        //                     //await _dbContext.SaveChangesAsync();
        //                 }
        //                 else
        //                 {
        //                     ModelState.AddModelError("File", "The file is too large.");
        //                 }
        //             }
        //         }
        //     }
        //     return View();
        // }






        // String message = comments.Where(obj => obj.Id == 3)
        //     .Select(x => x.Message)
        //     .First();


        // private readonly ILogger<StudentController> _logger;

        // public StudentsController(ILogger<StudentController> logger)
        //{
        //    _logger = logger;
        // }


    }
}


