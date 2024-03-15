using ESGSurvey.Data.SampleModel;

namespace ESGSurvey.Data.Core
{
    public interface IOpenAIServiceCore
    {
        //Task<Response<ChatCompletions>> GenerateChatTextAsync(string searchText);
        Task<OpenAIOutputResponseModel> GenerateChatTextAsync(string searchText);
    }
}
