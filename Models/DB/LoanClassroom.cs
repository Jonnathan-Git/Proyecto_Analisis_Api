using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class LoanClassroom
{
    public int Id { get; set; }

    public int? IdLoan { get; set; }

    public int? IdClassroom { get; set; }

    public int? IdUser { get; set; }

    public int? PersonQuantity { get; set; }

    public string? Requirements { get; set; }

    public string? RequestState { get; set; }

    public virtual Classroom? IdClassroomNavigation { get; set; }

    public virtual Loan? IdLoanNavigation { get; set; }

    public virtual Userr? IdUserNavigation { get; set; }
}
