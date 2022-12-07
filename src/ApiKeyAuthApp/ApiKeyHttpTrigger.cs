using System.Net;
using System.Threading.Tasks;

using ApiKeyAuthApp.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace ApiKeyAuthApp
{
    public class ApiKeyHttpTrigger
    {
        private readonly ILogger<ApiKeyHttpTrigger> _logger;

        public ApiKeyHttpTrigger(ILogger<ApiKeyHttpTrigger> log)
        {
            this._logger = log;
        }

        [FunctionName(nameof(ApiKeyHttpTrigger.GetProfile))]
        [OpenApiOperation(operationId: "Profile", tags: new[] { "profile" })]
        // [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "x-functions-key", In = OpenApiSecurityLocationType.Header)]
        [OpenApiParameter(name: "name", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **Name** parameter")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ProfileResponse), Description = "The OK response")]
        public async Task<IActionResult> GetProfile(
            [HttpTrigger(AuthorizationLevel.Function, "GET", Route = "profile")] HttpRequest req)
        {
            this._logger.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            var message = name.IsNullOrWhiteSpace()
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            var response = new ProfileResponse()
            {
                Message = message,
            };

            var result = new OkObjectResult(response);

            return await Task.FromResult(result);
        }
    }
}