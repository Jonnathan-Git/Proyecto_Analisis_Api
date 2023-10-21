using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class ClassroomSchedule
{
    public int Id { get; set; }

    public string? Day { get; set; }

    public int? IdClassroom { get; set; }

    public TimeSpan? StartHour { get; set; }

    public TimeSpan? EndHour { get; set; }

    public virtual Classroom? IdClassroomNavigation { get; set; }
}
