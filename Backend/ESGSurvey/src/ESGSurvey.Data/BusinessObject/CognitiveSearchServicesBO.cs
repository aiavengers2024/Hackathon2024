using ESGSurvey.Data.SampleModel;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;

namespace ESGSurvey.Data.BusinessObject
{
    public class CognitiveSearchServicesBO : ICognitiveSearchServicesBO
    {
        #region Global Variable(s)

        private readonly IConfigurationSettings _configuration;
        #endregion

        public CognitiveSearchServicesBO(IConfigurationSettings configuration)
        {
            _configuration = configuration;
        }
        #region Public Method(s)

        public async Task<List<CognitiveSearchModel>> Search(string search)
        {
            try
            {
                SearchServiceClient serviceClient = new SearchServiceClient(_configuration.CognitiveServiceName, new SearchCredentials(_configuration.CognitiveServiceApiKey));
                ISearchIndexClient indexClient = serviceClient.Indexes.GetClient(_configuration.CognitiveServiceIndexName);
                SearchParameters parameters = new SearchParameters();
                parameters.HighlightFields = new List<string> { "content" };
                parameters.HighlightPreTag = "<br/>";
                parameters.HighlightPostTag = "<br/>";
                var result = indexClient.Documents.SearchAsync(search, parameters).Result;
                List<CognitiveSearchModel> searchResult = new List<CognitiveSearchModel>();

                foreach (var item in result.Results)
                {

                    var path = item.Document["metadata_storage_path"].ToString();
                    path = path.Substring(0, path.Length - 1);
                    var bitData = WebEncoders.Base64UrlDecode(path);
                    var searchModel = new CognitiveSearchModel
                    {
                        FilePath = System.Text.ASCIIEncoding.ASCII.GetString(bitData),
                        SearchContent = item.Document["content"].ToString(),
                        People = string.Join(",", item.Document["people"]) ,
                        Keyphrases = string.Join(",", item.Document["keyphrases"])
                };
                    if (item.Highlights != null)
                    {
                        foreach (var data in item.Highlights["content"].ToList())
                        {
                            searchModel.HighlightedText += data;
                        }
                    }

                    searchResult.Add(searchModel);
                }

                return searchResult;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

    }
}
