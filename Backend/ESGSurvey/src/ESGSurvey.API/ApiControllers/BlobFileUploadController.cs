using ESGSurvey.Data.BusinessObject;
using ESGSurvey.Data.Core;
using Microsoft.AspNetCore.Mvc;

namespace ESGSurvey.API.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobFileUploadController : ControllerBase
    {
        #region Global Variable(s)
        private readonly IConfigurationSettings _configuration;
        private readonly IBlobServiceCore _blobServiceCore;
        private readonly IAzureAISearchServicesCore _azureAISearchServicesCore;
        #endregion

        public BlobFileUploadController(IBlobServiceCore blobServiceCore, IAzureAISearchServicesCore azureAISearchServicesCore, IConfigurationSettings configuration)
        {
            _blobServiceCore = blobServiceCore;
            _azureAISearchServicesCore = azureAISearchServicesCore;
            _configuration = configuration;
        }

        [HttpPost(""), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadBlobs()
        {
            try
            {
                IFormFile file = Request.Form.Files[0];
                if (file == null)
                {
                    return BadRequest();
                }
                var output = await _blobServiceCore.UploadFileBlobAsync(file.OpenReadStream(), file.FileName);
                if (output!=null)
                {
                  var isRunAndCheckIndexer=  _azureAISearchServicesCore.RunAndCheckIndexer();
                }
                return Ok(output);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

    }
}
