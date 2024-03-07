using Azure;
using Azure.AI.OpenAI;
namespace ESGSurvey.Data.Core
{
    public interface IOpenAIServiceCore
    {
        Task<Response<ChatCompletions>> GenerateChatTextAsync(string searchText);
    }
}
