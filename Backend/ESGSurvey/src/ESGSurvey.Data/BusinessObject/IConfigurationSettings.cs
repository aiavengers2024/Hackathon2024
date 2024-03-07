namespace ESGSurvey.Data.BusinessObject
{
    public interface IConfigurationSettings
    {
        string AzureAIServiceName { get; }
        string AzureAIServiceIndexName { get; }
        string AzureAIServiceApiKey { get; }
        string AzureAIServiceUrl { get; }
        string AzureAISearchIndexerName { get; }

        string StorageConnectionString { get; }
        string StorageBlobContainerName { get; }

        string OpenAIApiBase { get; }
        string OpenAIKey { get; }
        string OpenAIDeploymentId { get; }

        

    }
}
