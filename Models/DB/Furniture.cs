using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class Furniture
{
    public int Id { get; set; }

    public int? id_study_room { get; set; }

    public string? furniture { get; set; }
    public bool Active { get; set; }
    public int Capacity { get; set; }

    public virtual StudyRoom? IdStudyRoomNavigation { get; set; }
}