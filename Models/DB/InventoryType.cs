using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class InventoryType
{
    public int Id { get; set; }

    public int? InventoryId { get; set; }

    public string? Type { get; set; }

    public virtual Inventory? Inventory { get; set; }
}
