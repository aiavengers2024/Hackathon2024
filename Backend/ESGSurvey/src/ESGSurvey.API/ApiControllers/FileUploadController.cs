using ESGSurvey.Data.BusinessObject;
using ESGSurvey.Data.Core;
using Microsoft.AspNetCore.Mvc;
namespace ESGSurvey.API.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        #region Global Variable(s)
        private readonly IConfigurationSettings _configuration;
        private readonly IBlobServiceCore _blobServiceCore;
        private readonly IAzureAISearchServicesCore _azureAISearchServicesCore;
        #endregion

        public FileUploadController(IBlobServiceCore blobServiceCore, IAzureAISearchServicesCore azureAISearchServicesCore, IConfigurationSettings configuration)
        {
            _blobServiceCore = blobServiceCore;
            _azureAISearchServicesCore = azureAISearchServicesCore;
            _configuration = configuration;
        }

        [HttpPost(""), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadBlobs(string FilePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FilePath))
                {
                    return BadRequest();
                }
                else
                {
                    string FileName = Path.GetFileName(FilePath);
                    using (var fileStream = System.IO.File.OpenRead(FilePath))
                    {
                        if (fileStream == null)
                        {
                            return BadRequest();
                        }
                        else
                        {
                            var output = await _blobServiceCore.UploadFileBlobAsync(fileStream, FileName);
                            if (output != null)
                            {
                                var isRunAndCheckIndexer = _azureAISearchServicesCore.RunAndCheckIndexer();
                            }
                            return Ok(output);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
