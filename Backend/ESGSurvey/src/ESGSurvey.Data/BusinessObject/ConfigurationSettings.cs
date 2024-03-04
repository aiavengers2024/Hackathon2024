using Microsoft.Extensions.Configuration;

namespace ESGSurvey.Data.BusinessObject
{
    public class ConfigurationSettings : IConfigurationSettings
    {
        #region Global Variable(s)
        private readonly IConfiguration _configuration;
        #endregion

        public ConfigurationSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #region Public Prop(s)
        public string CognitiveServiceName => _configuration["CognitiveSearch:CognitiveServiceName"];

        public string CognitiveServiceIndexName => _configuration["CognitiveSearch:CognitiveServiceIndexName"];

        public string CognitiveServiceApiKey => _configuration["CognitiveSearch:CognitiveServiceApiKey"];
        public string AzureStorageConnectionString => _configuration["AzureStorage:AzureStorageConnectionString"];

        public string AzureStorageBlobContainerName => _configuration["AzureStorage:AzureStorageBlobContainerName"];

        #endregion

    }
}
