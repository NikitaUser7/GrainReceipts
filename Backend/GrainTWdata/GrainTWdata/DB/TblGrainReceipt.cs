using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrainTWdata.DB;

public partial class TblGrainReceipt
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SysId { get; set; }

    public int Id { get; set; }

    public DateTime RecordDate { get; set; }

    public int? BranchId { get; set; }

    public string? CropYear { get; set; }

    public int? CounterpartyId { get; set; }

    public string? CounterpartyName { get; set; }

    public int? ContractId { get; set; }

    public string? Product { get; set; }

    public float? Price { get; set; }

    public int? Amount { get; set; }

    public string? Process { get; set; }

    public float? Wetness { get; set; }

    public string? Garbage { get; set; }


    public string? Infection { get; set; }
}
