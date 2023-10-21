using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class LoanBookLog
{
    public int Id { get; set; }

    public int? IdUsers { get; set; }

    public int? IdLoan { get; set; }

    public string? Barcode { get; set; }

    public string? SubLibrary { get; set; }

    public decimal? Penalty { get; set; }

    public string? Status { get; set; }

    public TimeSpan? Hour { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public string? BibliographicInformation { get; set; }

    public virtual Loan? IdLoanNavigation { get; set; }

    public virtual Userr? IdUsersNavigation { get; set; }
}
