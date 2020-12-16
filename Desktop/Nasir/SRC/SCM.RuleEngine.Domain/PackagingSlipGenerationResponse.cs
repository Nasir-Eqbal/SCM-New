namespace SCM.RuleEngine.Domain
{
    public class PackagingSlipGenerationResponse
    {
        public string PackagingId { get; set; }
        public bool IsSlipGenerated { get; set; }
        public PackingSlipType SlipType { get; set; }
    }
}