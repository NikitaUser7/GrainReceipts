namespace GrainTWdata.Models
{
    public class GetGrainDataArgs
    {
        public string? OrderBy { get; set; }
        public bool? Desc { get; set; }
        public int? PageSize { get; set;}
        public int? PageCount { get; set;}
    }
}
