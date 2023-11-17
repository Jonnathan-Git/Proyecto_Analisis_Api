using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnalisisProyecto.Models.DB;

public partial class ReportComputerEquipment
{
    public int Id { get; set; }

    public int? IdComputerEquipment { get; set; }

    public int? IdReturnEquipment { get; set; }

    public int? IdLoanEquipment { get; set; }

    public virtual ComputerEquipment? IdComputerEquipmentNavigation { get; set; }

    public virtual Loan? IdLoanEquipmentNavigation { get; set; }

    public virtual ComputerEquipment? IdReturnEquipmentNavigation { get; set; }
}
