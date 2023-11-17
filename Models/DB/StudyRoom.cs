using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class StudyRoom
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Capacity { get; set; }

    public bool? IsAvailable { get; set; }

    public virtual ICollection<Furniture> Furnitures { get; set; } = new List<Furniture>();

    public virtual ICollection<LoanStudyRoom> LoanStudyRooms { get; set; } = new List<LoanStudyRoom>();

    public virtual ICollection<StudyRoomSchedule> StudyRoomSchedules { get; set; } = new List<StudyRoomSchedule>();
}
