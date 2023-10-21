using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class SanctionsReport
{
    public int Id { get; set; }

    public int? IdLibraryUser { get; set; }

    public int? IdSanctionComputerEquipment { get; set; }

    public int? IdReturnComputerEquipment { get; set; }

    public virtual LibraryUser? IdLibraryUserNavigation { get; set; }

    public virtual ReturnComputerEquipment? IdReturnComputerEquipmentNavigation { get; set; }

    public virtual SanctionComputerEquipment? IdSanctionComputerEquipmentNavigation { get; set; }
}
