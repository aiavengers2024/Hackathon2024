namespace ESGSurvey.Data.BusinessObject
{
    public interface IConfigurationSettings
    {
        string CognitiveServiceName { get; }
        string CognitiveServiceIndexName { get; }
        string CognitiveServiceApiKey { get; }
        string AzureStorageConnectionString { get; }
        string AzureStorageBlobContainerName { get; }
    }
}
