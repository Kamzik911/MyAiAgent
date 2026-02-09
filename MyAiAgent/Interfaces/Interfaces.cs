using MyAiAgent.Models;

namespace MyAiAgent.Interfaces
{
    public interface ITestMethods
    {
        Task<GenerateTestsResponse> AskForEmailTests(FieldSpecification fieldSpec, string? prompt, CancellationToken cancToken = default);
    }

    public interface IQuestionsToAgent
    {
        Task<GenerateTestsResponse> EmailQuestionGenerateAsync(FieldSpecification fieldSpec, string? prompt, CancellationToken cancToken = default);     
    }

    public interface IGeneralChatAgent
    {
        Task<string> AskAsync(string userRequest, CancellationToken cancToken = default);
    }
}
