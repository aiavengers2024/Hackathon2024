using Azure;
using Azure.AI.OpenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESGSurvey.Data.Core
{
    public class OpenAIServiceCore : IOpenAIServiceCore
    {
        public Task<Response<ChatCompletions>> GenerateTextAsync(string chatInput)
        {
            throw new NotImplementedException();
        }
    }
}
