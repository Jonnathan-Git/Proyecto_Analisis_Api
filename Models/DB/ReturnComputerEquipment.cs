using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AnalisisProyecto.Models.DB;

public partial class ReturnComputerEquipment
{
    public int Id { get; set; }

    public int? IdLibraryUser { get; set; }

    public int? IdComputerEquipment { get; set; }

    public int? Delay { get; set; }

    public DateTime? LoanDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public DateTime? LimitDate { get; set; }

    public virtual ComputerEquipment? IdComputerEquipmentNavigation { get; set; }

    public virtual LibraryUser? IdLibraryUserNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<SanctionComputerEquipment> SanctionComputerEquipments { get; set; } = new List<SanctionComputerEquipment>();

    [JsonIgnore]
    public virtual ICollection<SanctionsReport> SanctionsReports { get; set; } = new List<SanctionsReport>();
}
