using System.Globalization;
using web_api.Exception;
using web_api.Models;

namespace web_api.Services;

public class StudentHelper : IStudentHelper
{
    public override async Task<List<Student>> GetAllStudent(List<Student> Students)
    {
        return Students;
    }

    public override async Task<Student> GetStudentById(List<Student> Students, int id)
    {
        Student? student = Students.Find((s) => s.id.Equals(id));
        if (student == null)
        {
            throw new StudentNotFoundException("Student not found!");
        }

        return student;
    }

    public override async Task<List<Student>> GetThatContains(List<Student> Students, string seq)
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

    public override async Task<string> GetDate(string culture)
    {
        DateTime myDate = new DateTime();
        myDate=DateTime.Now;
        string date = myDate.ToString("d" ,CultureInfo.GetCultureInfo(culture));
        return date; 
        
    }
    

    public override async Task<List<Student>> Replace(List<Student> Students, updateStudent request)
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

    public override async Task<List<Student>> AddStudent(List<Student> Students, Student student)
    {
        Students.Add(student);
        return Students;
        
    }

    public override async Task<List<Student>> Delete(List<Student> Students, int id)
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

    
}