using ESGSurvey.Data.BusinessObject;
using ESGSurvey.Data.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ESGSurvey.API.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class AzureAISearchServicesController : ControllerBase
    {
        #region Global Variable(s)
        private readonly IConfigurationSettings _configuration;
        private readonly IAzureAISearchServicesCore _azureAISearchServicesCore;
        #endregion

        public AzureAISearchServicesController(IAzureAISearchServicesCore azureAISearchServicesCore, IConfigurationSettings configuration)
        {
            _azureAISearchServicesCore = azureAISearchServicesCore;
            _configuration = configuration;
        }
       
        #region API Method(s)
        [HttpPost]
        public async Task<IActionResult> Search(string SearchText)
        {
            try
            {
                var response = await _azureAISearchServicesCore.Search(SearchText);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion 
        
    }
}
