using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AnalisisProyecto.Models.DB;

public partial class LoanStudyRoom
{
    public int Id { get; set; }

    public int? NumberOfPeople { get; set; }

    public int? LoanId { get; set; }

    public string? ReturnHour { get; set; }

    public string? ExitHour { get; set; }

    public int? IdUserLibrary { get; set; }

    public int? StudyRoomId { get; set; }

    [JsonIgnore]
    public virtual LibraryUser? IdUserLibraryNavigation { get; set; }

    [JsonIgnore]
    public virtual Loan? Loan { get; set; }

    public bool Active { get; set; }
    [JsonIgnore]
    public virtual StudyRoom? StudyRoom { get; set; }
}