using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class SanctionComputerEquipment
{
    public int Id { get; set; }

    public int? IdReturnComputerEquipment { get; set; }

    public string? SanctionType { get; set; }

    public DateTime? Date { get; set; }

    public DateTime? SanctionExpiration { get; set; }

    public virtual ReturnComputerEquipment? IdReturnComputerEquipmentNavigation { get; set; }

    public virtual ICollection<SanctionsReport> SanctionsReports { get; set; } = new List<SanctionsReport>();
}
