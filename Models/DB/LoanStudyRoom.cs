using System;
using System.Collections.Generic;

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

    public virtual LibraryUser? IdUserLibraryNavigation { get; set; }

    public virtual Loan? Loan { get; set; }

    public bool Active { get; set; }

    public virtual StudyRoom? StudyRoom { get; set; }
}
