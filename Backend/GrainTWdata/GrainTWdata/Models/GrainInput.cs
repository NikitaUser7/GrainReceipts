namespace GrainTWdata.Models
{
    public class GrainInput
    {
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
}
