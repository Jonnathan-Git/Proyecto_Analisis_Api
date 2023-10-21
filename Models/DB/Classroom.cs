using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class Classroom
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public string? Requirements { get; set; }

    public int? Quantity { get; set; }

    public string? Numeration { get; set; }

    public virtual ICollection<ClassroomSchedule> ClassroomSchedules { get; set; } = new List<ClassroomSchedule>();

    public virtual ICollection<LoanClassroom> LoanClassrooms { get; set; } = new List<LoanClassroom>();
}
