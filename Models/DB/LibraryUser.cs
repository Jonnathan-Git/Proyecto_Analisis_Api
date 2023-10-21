using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class LibraryUser
{
    public int Id { get; set; }

    public int? IdUser { get; set; }

    public string? Library { get; set; }

    public string? Privilege { get; set; }

    public string? TypeUser { get; set; }

    public virtual Userr? IdUserNavigation { get; set; }

    public virtual ICollection<LoanBook> LoanBooks { get; set; } = new List<LoanBook>();

    public virtual ICollection<LoanComputerEquipment> LoanComputerEquipments { get; set; } = new List<LoanComputerEquipment>();

    public virtual ICollection<LoanStudyRoom> LoanStudyRooms { get; set; } = new List<LoanStudyRoom>();

    public virtual ICollection<ReturnComputerEquipment> ReturnComputerEquipments { get; set; } = new List<ReturnComputerEquipment>();

    public virtual ICollection<SanctionsReport> SanctionsReports { get; set; } = new List<SanctionsReport>();
}
