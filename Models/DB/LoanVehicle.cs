using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class LoanVehicle
{
    public int Id { get; set; }

    public int? IdLoan { get; set; }

    public int? IdUser { get; set; }

    public int? ActivityType { get; set; }

    public string? Responsible { get; set; }

    public string? State { get; set; }

    public string? Destination { get; set; }

    public string? StartingPlace { get; set; }

    public string? ExitHour { get; set; }

    public string? ReturnHour { get; set; }

    public int? PersonQuantity { get; set; }

    public string? UnityOrCarrer { get; set; }

    public string? AssignedVehicle { get; set; }

    public bool Active { get; set; }
    public virtual Loan? IdLoanNavigation { get; set; }

    public virtual Userr? IdUserNavigation { get; set; }
}
