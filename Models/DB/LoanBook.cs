using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AnalisisProyecto.Models.DB;

public partial class LoanBook
{
    public int Id { get; set; }

    public int? IdLoan { get; set; }

    public int? IdCopy { get; set; }

    public int? IdLibraryUser { get; set; }

    public string? Title { get; set; }

    public decimal? PhotocopyCharge { get; set; }

    public string? SubLibrary { get; set; }

    public string? Observation { get; set; }

    public int? LimitFines { get; set; }
    public int? State { get; set; }

    public virtual Copy? IdCopyNavigation { get; set; }
    [JsonIgnore]
    public virtual LibraryUser? IdLibraryUserNavigation { get; set; }

    public virtual Loan? IdLoanNavigation { get; set; }
}
