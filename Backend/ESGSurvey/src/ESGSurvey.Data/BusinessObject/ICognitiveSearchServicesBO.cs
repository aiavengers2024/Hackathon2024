using ESGSurvey.Data.SampleModel;

namespace ESGSurvey.Data.BusinessObject
{
    public interface ICognitiveSearchServicesBO
    {
        Task<List<CognitiveSearchModel>> Search(string search);
        bool RunAndCheckIndexer();
    }
}
