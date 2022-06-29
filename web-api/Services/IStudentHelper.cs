using web_api.Models;

namespace web_api.Services;

public abstract class IStudentHelper
{
    public abstract Task<List<Student>> GetAllStudent(List<Student> Students);
    public abstract Task<Student> GetStudentById(List<Student> Students, int id);
    public abstract Task<List<Student>> GetThatContains(List<Student> Students, string seq);
    public abstract Task<string> GetDate(string culture);
    public abstract Task<List<Student>> Replace(List<Student> Students, updateStudent request);
    public abstract Task<List<Student>> AddStudent(List<Student> Students, Student student);
    public abstract Task<List<Student>> Delete(List<Student> Students, int id);

    
}