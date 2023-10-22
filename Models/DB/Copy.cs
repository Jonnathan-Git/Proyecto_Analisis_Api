using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class Copy
{
    public int Id { get; set; }

    public int? IdTitles { get; set; }

    public int? Sequence { get; set; }

    public string? Barcode { get; set; }

    public string? SubLibrary { get; set; }

    public string? Description { get; set; }

    public string? Classification { get; set; }

    public string? Collection { get; set; }

    public string? ItemStatus { get; set; }

    public string? Notes { get; set; }

    public bool? Active { get; set; }

    public virtual Title? IdTitlesNavigation { get; set; }

    public virtual ICollection<LoanBook> LoanBooks { get; set; } = new List<LoanBook>();
}
