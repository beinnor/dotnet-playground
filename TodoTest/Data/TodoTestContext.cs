using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using TodoTest.Models;

namespace TodoTest.Data
{
  public class TodoTestContext : DbContext
  {
    public TodoTestContext(DbContextOptions<TodoTestContext> options)
      : base(options)
    { }

    public DbSet<User> Users { get; set; }

    public DbSet<Task> Tasks { get; set; }

  }
}