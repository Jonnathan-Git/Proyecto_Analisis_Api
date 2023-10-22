using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class Furniture
{
    public int Id { get; set; }

    public int? IdStudyRoom { get; set; }

    public string? Furniture1 { get; set; }
    public bool Active { get; set; }
    public int Capacity { get; set; }

    public virtual StudyRoom? IdStudyRoomNavigation { get; set; }
}
