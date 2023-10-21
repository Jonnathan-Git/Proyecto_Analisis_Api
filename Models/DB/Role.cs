using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<RolePrivilege> RolePrivileges { get; set; } = new List<RolePrivilege>();

    public virtual ICollection<Userr> Userrs { get; set; } = new List<Userr>();
}
