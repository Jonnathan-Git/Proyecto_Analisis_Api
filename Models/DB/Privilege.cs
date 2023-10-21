using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class Privilege
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<RolePrivilege> RolePrivileges { get; set; } = new List<RolePrivilege>();
}
