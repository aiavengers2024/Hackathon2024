using ESGSurvey.Data.SampleModel;

namespace ESGSurvey.Data.BusinessObject
{
    public interface IAzureAISearchServicesBO
    {
        Task<List<AzureAISearchModel>> Search(string searchText);
        bool RunAndCheckIndexer();
    }
}
