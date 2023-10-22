using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AnalisisProyecto.Models.DB;

public partial class Userr {
    public int Id { get; set; }

    public string? UserId { get; set; }

    public string? Category { get; set; }

    public int? RoleId { get; set; }

    public string? Phone { get; set; }

    public string? Career { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public DateTime? CreationDate { get; set; }

    public bool? Deleted { get; set; }

    public virtual ICollection<LibraryUser> LibraryUsers { get; set; } = new List<LibraryUser>();

    public virtual ICollection<LoanBookLog> LoanBookLogs { get; set; } = new List<LoanBookLog>();

    public virtual ICollection<LoanField> LoanFields { get; set; } = new List<LoanField>();

    public virtual ICollection<LoanSportsEquipment> LoanSportsEquipments { get; set; } = new List<LoanSportsEquipment>();

    public virtual ICollection<LoanVehicle> LoanVehicles { get; set; } = new List<LoanVehicle>();

    public virtual ICollection<LoanClassroom> LoanClassrooms { get; set; } = new List<LoanClassroom>();

    //[JsonIgnore]
    public virtual Role? Role { get; set; }
}
