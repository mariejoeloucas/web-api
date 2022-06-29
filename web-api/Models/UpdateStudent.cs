using System.ComponentModel.DataAnnotations;

namespace web_api.Models;


public class UpdateStudent
{
    [Required (ErrorMessage="Please enter an id")]
    public long Id { get; set; }
    [Required (ErrorMessage="Please enter an id")]
    public string Name { get; set; }
    [Required (ErrorMessage="Please enter an email address")] 
    [EmailAddress (ErrorMessage="Please enter a valid email address")]
    public string Email { get; set; }
}