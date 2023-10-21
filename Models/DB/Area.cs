using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class Area
{
    public int Id { get; set; }

    public int? InventoryId { get; set; }

    public string? Area1 { get; set; }

    public virtual Inventory? Inventory { get; set; }
}
