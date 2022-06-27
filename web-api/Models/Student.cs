using System.ComponentModel.DataAnnotations;

namespace web_api.Models;


public class Student
{
    [Required]
    public long id { get; set; }
    [Required]
    public string name { get; set; }
    [Required]
    public string email{ get; set; }
}