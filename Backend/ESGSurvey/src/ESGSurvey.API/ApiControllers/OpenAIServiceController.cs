using ESGSurvey.Data.BusinessObject;
using ESGSurvey.Data.Core;
using Microsoft.AspNetCore.Mvc;

namespace ESGSurvey.API.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIServiceController : ControllerBase
    {
        #region Global Variable(s)
        private readonly IConfigurationSettings _configuration;
        private readonly IOpenAIServiceCore _openAIServiceCore;
        #endregion

        public OpenAIServiceController(IOpenAIServiceCore openAIServiceCore, IConfigurationSettings configuration)
        {
            _openAIServiceCore = openAIServiceCore;
            _configuration = configuration;
        }

        [HttpPost(""), DisableRequestSizeLimit]
        public async Task<IActionResult> Search(string SearchText)
        {
            try
            {
                var output = await _openAIServiceCore.GenerateChatTextAsync(SearchText);
                return Ok(output);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("test")]
        public IActionResult Test(string SearchText)
        {
            return new JsonResult("testing");
        }

    }
}
