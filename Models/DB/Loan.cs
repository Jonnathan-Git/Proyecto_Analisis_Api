using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AnalisisProyecto.Models.DB;

public partial class Loan
{
    public int Id { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? RegisterDate { get; set; }

    public virtual ICollection<LoanBookLog> LoanBookLogs { get; set; } = new List<LoanBookLog>();
    [JsonIgnore]
    public virtual ICollection<LoanBook> LoanBooks { get; set; } = new List<LoanBook>();

    public virtual ICollection<LoanClassroom> LoanClassrooms { get; set; } = new List<LoanClassroom>();

    public virtual ICollection<LoanComputerEquipment> LoanComputerEquipments { get; set; } = new List<LoanComputerEquipment>();

    public virtual ICollection<LoanField> LoanFields { get; set; } = new List<LoanField>();

    public virtual ICollection<LoanSportsEquipment> LoanSportsEquipments { get; set; } = new List<LoanSportsEquipment>();

    public virtual ICollection<LoanStudyRoom> LoanStudyRooms { get; set; } = new List<LoanStudyRoom>();

    public virtual ICollection<LoanVehicle> LoanVehicles { get; set; } = new List<LoanVehicle>();
}
