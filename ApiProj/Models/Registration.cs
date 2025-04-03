using System;
using System.Collections.Generic;

namespace ApiProj.Models;

public partial class Registration
{
    public string? ParticipantId { get; set; }

    public string? EventId { get; set; }

    public DateTime? RegistrationDateTime { get; set; }
}
