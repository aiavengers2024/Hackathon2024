using ESGSurvey.Data.BusinessObject;
using ESGSurvey.Data.Core;
using Microsoft.AspNetCore.Mvc;
namespace ESGSurvey.API.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllFileUploadFromDirectoryController : ControllerBase
    {
        #region Global Variable(s)
        private readonly IConfigurationSettings _configuration;
        private readonly IBlobServiceCore _blobServiceCore;
        private readonly IAzureAISearchServicesCore _azureAISearchServicesCore;
        private readonly ILogger _logger;
        #endregion

        public AllFileUploadFromDirectoryController(IBlobServiceCore blobServiceCore, IAzureAISearchServicesCore azureAISearchServicesCore, IConfigurationSettings configuration, ILogger<AllFileUploadFromDirectoryController> logger)
        {
            _blobServiceCore = blobServiceCore;
            _azureAISearchServicesCore = azureAISearchServicesCore;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost(""), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadBlobs(string DirectoryPath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(DirectoryPath))
                {
                    return BadRequest();
                }
                else
                {
                    if (Directory.Exists(DirectoryPath))
                    {
                        string[] fileEntries = Directory.GetFiles(DirectoryPath);
                        foreach (string fileName in fileEntries)
                        {
                            string FileName = Path.GetFileName(fileName);
                            var fileStream = System.IO.File.OpenRead(fileName);
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

                            }
                        }
                    }
                    else
                    {
                        return BadRequest();
                    }
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}
