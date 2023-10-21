using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class Inventory
{
    public int Id { get; set; }

    public int? Units { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();

    public virtual ICollection<InventoryType> InventoryTypes { get; set; } = new List<InventoryType>();
}
