using System;
using System.Collections.Generic;

namespace ApiProj.Models;

public partial class Author
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public DateOnly? BirthDate { get; set; }
}
