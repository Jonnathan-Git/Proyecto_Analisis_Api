using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AnalisisProyecto.Models.DB;

public partial class LoanComputerEquipment
{
    public int Id { get; set; }

    public int? IdComputerEquipment { get; set; }

    public int? IdLoan { get; set; }

    public int? IdLibraryUser { get; set; }

    public string? Assets { get; set; }

    public string? AssetEvaluation { get; set; }

    public string? DestinationPlace { get; set; }

    public string? State { get; set; }

    public string? Dependence { get; set; }

    public string? RequestActivity { get; set; }

    [JsonIgnore]
    public virtual ComputerEquipment? IdComputerEquipmentNavigation { get; set; }

    public virtual LibraryUser? IdLibraryUserNavigation { get; set; }

    public virtual Loan? IdLoanNavigation { get; set; }
}
