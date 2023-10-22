using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class Title
{
    public int Id { get; set; }

    public string? PublisherName { get; set; }

    public string? Header { get; set; }

    public string? TermSubject { get; set; }

    public DateTime? AssociatedDate { get; set; }

    public DateTime? PublicationDate { get; set; }

    public int? Number { get; set; }

    public string? RestTitle { get; set; }

    public string? PersonName { get; set; }

    public string? Isbn { get; set; }

    public string? Title1 { get; set; }

    public string? MentionResponsibility { get; set; }

    public string? Information { get; set; }

    public string? GeneralSubjectSubdivision { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<Copy> Copies { get; set; } = new List<Copy>();
}
