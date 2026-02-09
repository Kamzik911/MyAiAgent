namespace MyAiAgent.Models
{
    public class TestDesignPrompt
    {
        readonly FieldSpecification _fieldSpec;
        private readonly string? _extra;

        public TestDesignPrompt(FieldSpecification fieldSpec, string? extra = null)
        {
            _fieldSpec = fieldSpec ?? throw new ArgumentNullException(nameof(fieldSpec));
            _extra = extra;
        }

        public string systemPrompt = """
                "techniques": ["EP", "BVA", "Negative"],
                "testCases": [
                  {
                    "id": "TC-01",
                    "technique": "BVA",
                    "title": "Valid email - lower boundary",
                    "input": "a@b.cz",
                    "expected": "Email accepted",
                    "priority": "P1"
                  }
                ],
                "openQuestions": []
                """;

        public string userPrompt => $@"
                Pole/Funkcionalita:
                - fieldType: {_fieldSpec.FieldType}
                - validationProfile: {_fieldSpec.ValidationProfile}
                - required: {_fieldSpec.IsRequired}
                - minLength: {_fieldSpec.MinLength}
                - maxLength: {_fieldSpec.MaxLength}
                - riskLevel: {_fieldSpec.RiskLevel}
                - businessRules: {_fieldSpec.BusinessRules ?? "null"}
                - notes: {_fieldSpec.Notes ?? "null"}                
                - extra instuctions: {(_extra is not null ? $"\\nDalší instrukce: {_extra}" : "")}";                
    }
}
