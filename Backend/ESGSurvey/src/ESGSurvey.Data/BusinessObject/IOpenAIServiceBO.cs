using Azure;
using Azure.AI.OpenAI;
using ESGSurvey.Data.SampleModel;

namespace ESGSurvey.Data.BusinessObject
{
    public interface IOpenAIServiceBO
    {
        //Task<Response<ChatCompletions>> GenerateChatTextAsync(string searchText);
        Task<OpenAIOutputResponseModel> GenerateChatTextAsync(string searchText);
    }
}
