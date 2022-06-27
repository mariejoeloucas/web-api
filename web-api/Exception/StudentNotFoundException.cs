using System.Net;

namespace web_api.Exception;

public class StudentNotFoundException: System.Exception
{
    public StudentNotFoundException(string message)
        : base($"Invalid Student Name: {message}")
    {
    }
}