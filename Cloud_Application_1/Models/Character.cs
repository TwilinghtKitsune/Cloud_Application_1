using System;
using System.Collections.Generic;

namespace Cloud_Application_1.Models;

public partial class Character
{
    public string Name { get; set; } = null!;

    public string Race { get; set; } = null!;

    public int? Lvl { get; set; }

    public int? Master { get; set; }

    public string? Description { get; set; }

    public int Id { get; set; }

    public virtual Master? MasterNavigation { get; set; }
}
