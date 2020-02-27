using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoTest.Models
{
  public class User
  {

    public int Id { get; set; }           // PK

    [Required]
    public string Email { get; set; }

#nullable enable
    public string? FirstName { get; set; }  // can be null

    public string? LastName { get; set; }   // can be null

    public string? Password { get; set; }
#nullable disable

    public ICollection<Task> Tasks { get; set; }  // Collection Navigation property

  }
}