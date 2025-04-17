using System;
using System.Collections.Generic;

namespace AngularApp3.Server.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? ImagePath { get; set; }

    public int? ManagerId { get; set; }

    public virtual MyManager? Manager { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
