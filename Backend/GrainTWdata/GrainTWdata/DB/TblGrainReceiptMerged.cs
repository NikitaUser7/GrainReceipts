using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrainTWdata.DB;

public partial class TblGrainReceiptMerged
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SysId { get; set; }

    public string Id { get; set; }

    public string RecordDate { get; set; }

    public string? BranchId { get; set; }

    public string? CropYear { get; set; }

    public string? CounterpartyId { get; set; }

    public string? CounterpartyName { get; set; }

    public string? ContractId { get; set; }

    public string? Product { get; set; }

    public string? Price { get; set; }

    public string? Amount { get; set; }

    public string? Process { get; set; }

    public string? Wetness { get; set; }

    public string? Garbage { get; set; }


    public string? Infection { get; set; }
}
