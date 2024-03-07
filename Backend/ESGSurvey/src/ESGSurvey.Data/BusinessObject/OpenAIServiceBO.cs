using Azure;
using Azure.AI.OpenAI;

namespace ESGSurvey.Data.BusinessObject
{
    public class OpenAIServiceBO : IOpenAIServiceBO
    {
        #region Global Variable(s)
        private readonly IConfigurationSettings _configuration;
        private readonly OpenAIClient _client;
        private ChatCompletionsOptions _options;
        #endregion

        public OpenAIServiceBO(IConfigurationSettings configuration)
        {
            this._configuration = configuration;
            _client = new OpenAIClient(new Uri(_configuration.OpenAIApiBase), new AzureKeyCredential(_configuration.OpenAIKey));
            ConnectToAzureAISearch();
        }
      
        #region Public Method(s)
        public async Task<Response<ChatCompletions>> GenerateChatTextAsync(string searchText)
        {
            List<ChatMessage> messages = new List<ChatMessage>()
            {
                new ChatMessage(ChatRole.User, searchText)
            };

            InitializeChatMessages(messages);
            var result = await _client.GetChatCompletionsAsync(_configuration.OpenAIDeploymentId, _options);
            return result;
        }
        #endregion
       
        #region Private Method(s)
        private void ConnectToAzureAISearch()
        {
            _options = new ChatCompletionsOptions()
            {
                AzureExtensionsOptions = new AzureChatExtensionsOptions()
                {
                    Extensions =
                    {
                        new AzureCognitiveSearchChatExtensionConfiguration()
                        {
                            SearchEndpoint = new Uri(_configuration.AzureAIServiceUrl),
                            IndexName = _configuration.AzureAISearchIndexerName,
                            SearchKey = new AzureKeyCredential(_configuration.AzureAIServiceApiKey)
                        }
                    }
                }
            };
        }

        private void InitializeChatMessages(List<ChatMessage> chatMessages)
        {
            foreach (var chatMessage in chatMessages)
            {
                _options.Messages.Add(chatMessage);
            }
        }
        #endregion
    }
}
