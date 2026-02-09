namespace MyAiAgent.Models
{
    public sealed class FieldSpecification
    {
        public string FieldType { get; set; } = "email";
        public bool IsRequired { get; set; } = true;
        
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }

        public string ValidationProfile { get; set; } = "email";
        public string RiskLevel { get; set; } = "medium";

        public string? BusinessRules { get; set; }
        public string? Notes { get; set; }
    }
}
