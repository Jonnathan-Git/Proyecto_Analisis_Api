using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class ComputerEquipment
{
    public int Id { get; set; }

    public string? LicensePlate { get; set; }

    public string? Class { get; set; }

    public string? Name { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public string? State { get; set; }

    public string? Observations { get; set; }

    public string? Include { get; set; }

    public Boolean? Active { get; set; } 
    public DateTime? LastModifications { get; set; }

    public string? SerialNumber { get; set; }

    public DateTime? EntryDate { get; set; }

    public virtual ICollection<LoanComputerEquipment> LoanComputerEquipments { get; set; } = new List<LoanComputerEquipment>();

    public virtual ICollection<ReturnComputerEquipment> ReturnComputerEquipments { get; set; } = new List<ReturnComputerEquipment>();
}
