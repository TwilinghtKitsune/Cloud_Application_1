using System;
using System.Collections.Generic;

namespace Cloud_Application_1.Models;

public partial class Master
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Character> Characters { get; } = new List<Character>();
}
