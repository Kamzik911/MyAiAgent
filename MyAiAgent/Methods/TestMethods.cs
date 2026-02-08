using MyAiAgent.Models;
using OpenAI.Chat;

namespace MyAiAgent.Methods
{
    public sealed class TestMethods : ITestMethods
    {
        private readonly ChatClient _chat;
        private readonly Prompts _systemPrompt;

        public TestMethods(string apiKey, string model, Prompts systemPrompt)
        {
            _chat = new ChatClient(
                model: model,
                apiKey: apiKey
            );
            _systemPrompt = systemPrompt;
        }        

        public async Task<GenerateTestsResponse> AskForEmailTests(GenerateTestsRequest request, CancellationToken cancToken = default)
        {
            string systemPrompt = _systemPrompt.systemPrompt;

            var userPrompt = $"""
                Pole/Funkcionalita:
                - fieldType: {request.FieldType}
                - validationProfile: {request.ValidationProfile}
                - required: {request.IsRequired}
                - minLength: {request.MinLength}
                - maxLength: {request.MaxLength}
                - riskLevel: {request.RiskLevel}
                - businessRules: {request.BusinessRules ?? "null"}
                - notes: {request.Notes ?? "null"}

                Navrhni testy.
                """;
            var messages = new List<ChatMessage>
            {
                new SystemChatMessage(systemPrompt),
                new UserChatMessage(userPrompt),
            };

            var response = await _chat.CompleteChatAsync(messages, options: null, cancellationToken: cancToken);

            var content = response.Value.Content[0].Text;

            return new GenerateTestsResponse
            {
                Markdown = content
            };
        }
    }
}
