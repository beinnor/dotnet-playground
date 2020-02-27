using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TodoTest.Models
{
  public class Task
  {
    public int Id { get; set; }       // PK

    [Required]
    public string Description { get; set; }

    [Required]
    public bool IsComplete { get; set; }

    public int UserId { get; set; }     // FK

    public User User { get; set; }  // navigation property

  }
}