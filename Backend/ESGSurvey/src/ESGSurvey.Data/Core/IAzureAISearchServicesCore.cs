using ESGSurvey.Data.SampleModel;

namespace ESGSurvey.Data.Core
{
    public interface IAzureAISearchServicesCore
    {
        Task<List< AzureAISearchModel>> Search(string search);
        bool RunAndCheckIndexer();
    }
}
