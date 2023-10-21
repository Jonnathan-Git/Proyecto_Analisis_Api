using System;
using System.Collections.Generic;

namespace AnalisisProyecto.Models.DB;

public partial class RolePrivilege
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public int? PrivilegesId { get; set; }

    public virtual Privilege? Privileges { get; set; }

    public virtual Role? Role { get; set; }
}
