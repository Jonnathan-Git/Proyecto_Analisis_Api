using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class Inventory
{
    public int Id { get; set; }

    public int? Units { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public bool deleted { get; set; } = false;

    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();

    
}
