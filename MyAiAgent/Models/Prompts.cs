namespace MyAiAgent.Models
{
    public class Prompts
    {        
        public string systemPrompt = """
                "techniques": ["EP, "BVA", "Negative"],
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
    }
}
