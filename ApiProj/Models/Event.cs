using System;
using System.Collections.Generic;

namespace ApiProj.Models;

public partial class Event
{
    public string? Id { get; set; }

    public string? Title { get; set; }

    public DateTime? EventDateTime { get; set; }

    public DateTime? RegistrationDeadline { get; set; }

    public string? AuthorId { get; set; }
}
