using System;
using System.Collections.Generic;

namespace AngularApp3.Server.Models;

public partial class MyManager
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
