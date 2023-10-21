using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class LoanField
{
    public int Id { get; set; }

    public int? IdLoan { get; set; }

    public int? IdUser { get; set; }

    public string? Materials { get; set; }

    public bool? Lightning { get; set; }

    public virtual Loan? IdLoanNavigation { get; set; }

    public virtual Userr? IdUserNavigation { get; set; }
}
