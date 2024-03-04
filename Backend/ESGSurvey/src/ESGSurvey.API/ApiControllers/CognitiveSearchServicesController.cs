using ESGSurvey.Data.BusinessObject;
using ESGSurvey.Data.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ESGSurvey.API.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class CognitiveSearchServicesController : ControllerBase
    {
        #region Global Variable(s)
        private readonly IConfigurationSettings _configuration;
        private readonly ICognitiveSearchServicesCore _cognitiveSearchServicesCore;
        #endregion

        public CognitiveSearchServicesController(ICognitiveSearchServicesCore cognitiveSearchServicesCore, IConfigurationSettings configuration)
        {
            _cognitiveSearchServicesCore = cognitiveSearchServicesCore;
            _configuration = configuration;
        }
       
        #region API Method(s)
        [HttpPost]
        public async Task<IActionResult> Search(string SearchText)
        {
            var response = await _cognitiveSearchServicesCore.Search(SearchText);
            return Ok(response);
        }
        #endregion 
        
    }
}
