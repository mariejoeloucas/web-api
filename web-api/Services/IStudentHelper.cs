using web_api.Models;

namespace web_api.Services;

public interface IStudentHelper
{
    public  Task<List<Student>> GetAllStudent(List<Student> students);
    public Task<Student> GetStudentById(List<Student> students, int id);
    public Task<List<Student>> GetThatContains(List<Student> students, string seq);
    public Task<string> GetDate(string culture);
    public Task<List<Student>> Replace(List<Student> students, UpdateStudent request);
    public Task<List<Student>> AddStudent(List<Student> students, Student student);
    public Task<List<Student>> Delete(List<Student> students, int id);
    public Task<string> Upload(IWebHostEnvironment hostingEnvironment, UploadImageModel image);


}