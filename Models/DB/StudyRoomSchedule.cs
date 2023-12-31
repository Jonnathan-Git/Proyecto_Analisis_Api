﻿using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class StudyRoomSchedule
{
    public int Id { get; set; }

    public string? Day { get; set; }

    public int? IdStudyRoom { get; set; }

    public string? StartHour { get; set; }

    public string? EndHour { get; set; }

    public virtual StudyRoom? IdStudyRoomNavigation { get; set; }
    public bool Active { get; set; }
}