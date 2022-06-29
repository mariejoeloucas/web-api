using System.Globalization;
using web_api.Exception;
using web_api.Models;
using Microsoft.AspNetCore.Hosting;

namespace web_api.Services;

public class StudentHelper : IStudentHelper
{
    public async Task<List<Student>> GetAllStudent(List<Student> students)
    {
        return students;
    }

    public async Task<Student> GetStudentById(List<Student> students, int id)
    {
        Student? student = students.Find((s) => s.Id.Equals(id));
        if (student == null)
        {
            throw new StudentNotFoundException("Student not found!");
        }

        return student;
    }

    public async Task<List<Student>> GetThatContains(List<Student> students, string seq)
    {
        return students.Where((s) => s.Name.Contains(seq)).ToList();
    }

    public async Task<string> GetDate(string culture)
    {
        List<CultureInfo> cultureInfos = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();
        CultureInfo? cultureInfo = cultureInfos.Find((c) => c.Name.Equals(culture));
        if (cultureInfo == null)
        {
            throw new System.Exception("Invalid culture!");
        }
        
        // return DateTime.Now.ToString("d", CultureInfo.GetCultureInfo(culture));

        return DateTime.Now.ToString("d", cultureInfo);
    }
    

    public async Task<List<Student>> Replace(List<Student> students, UpdateStudent request)
    {
        long id = request.Id;
        string name = request.Name;
        string email = request.Email;
        Student? temp = null;
        foreach (Student s in students)
        {
            if (s.Id == id)
            {
                temp = s;
            }
        }

        if (temp == null)
        {
            throw new StudentNotFoundException("Not found");
        }
        
        temp.Name = name;
        temp.Email = email;
        return students;
    }

    public async Task<List<Student>> AddStudent(List<Student> students, Student student)
    {
        students.Add(student);
        return students;
    }

    public async Task<List<Student>> Delete(List<Student> students, int id)
    {
        Student? student = students.Find((s) => s.Id.Equals(id));
        if (student == null)
        {
            throw new StudentNotFoundException("Student not found!");
        }

        students.Remove(student);
        return students;
    }
    public async Task<string> Upload(IWebHostEnvironment hostingEnvironment, UploadImageModel image)
    {
        string uploads = hostingEnvironment.WebRootPath;
        string filePath = Path.Combine(uploads.ToString(), image.Image.FileName);
        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
        {
            await image.Image.CopyToAsync(fileStream);
        }
    
        return "Image uploaded.";
    }

    
    // public override async Task<string> Upload(UploadImageModel image)
    // {
    //     string fileName = (image.Image.FileName).ToString();
    //     string filePath = $@"wwwroot/{fileName}";
    //     using (Stream fileStream = new FileStream(filePath, FileMode.Create))
    //     {
    //         await image.Image.CopyToAsync(fileStream);
    //     }
    //
    //     return "done";
    // }


    
}