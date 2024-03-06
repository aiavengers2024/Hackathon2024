using Azure;
using Azure.AI.OpenAI;
namespace ESGSurvey.Data.BusinessObject
{
    public interface IOpenAIServiceBO
    {
        Task<Response<ChatCompletions>> GenerateChatTextAsync(string chatInput);

    }
}
