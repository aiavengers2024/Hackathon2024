namespace ESGSurvey.Data.BusinessObject
{
    public interface IConfigurationSettings
    {
        string CognitiveServiceName { get; }
        string CognitiveServiceIndexName { get; }
        string CognitiveServiceApiKey { get; }
        string AzureStorageConnectionString { get; }
        string AzureStorageBlobContainerName { get; }
        string CognitiveServiceUrl { get; }
        string SearchIndexerName { get; }

        string OpenAIApiBase { get; }
        string OpenAIKey { get; }
        string OpenAIDeploymentId { get; }



    }
}
