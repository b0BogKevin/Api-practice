using System;
using System.Collections.Generic;

namespace ApiProj.Models;

public partial class Story
{
    public string? Id { get; set; }

    public string? Title { get; set; }

    public DateTime? PublishStart { get; set; }

    public DateTime? PublishEnd { get; set; }

    public string? CategoryId { get; set; }

    public string? AuthorId { get; set; }
}
