using ESGSurvey.Data.BusinessObject;
using ESGSurvey.Data.Constants;
using ESGSurvey.Data.SampleModel;

namespace ESGSurvey.Data.Core
{
    public class CognitiveSearchServicesCore : ICognitiveSearchServicesCore
    {
        #region Global Variable(s)
        private readonly IConfigurationSettings _configuration;
        public readonly ICognitiveSearchServicesBO _cognitiveSearchServicesBO;
        #endregion

        public CognitiveSearchServicesCore(ICognitiveSearchServicesBO cognitiveSearchServicesBO, IConfigurationSettings configuration)
        {
            _cognitiveSearchServicesBO = cognitiveSearchServicesBO;
            _configuration = configuration;
        }
        
        #region Public Method(s)
        public Task<List<CognitiveSearchModel>> Search(string search)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                return _cognitiveSearchServicesBO.Search(search);
            }
            else
            {
                throw new Exception(CommonConstants.InputSearchFailed);
            }
          
        }
        #endregion  
    }
}
