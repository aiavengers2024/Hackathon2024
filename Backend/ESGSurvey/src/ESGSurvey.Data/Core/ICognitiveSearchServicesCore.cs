using ESGSurvey.Data.SampleModel;

namespace ESGSurvey.Data.Core
{
    public interface ICognitiveSearchServicesCore
    {
        Task<List< CognitiveSearchModel>> Search(string search);
    }
}
