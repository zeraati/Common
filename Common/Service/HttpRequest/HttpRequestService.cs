using Common;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;

namespace Csis.Common.Service;
public class HttpRequestService
{
    public IHttpRequestOption option;
    public IConfiguration configuration;
    private readonly HttpClient _httpClient;
    private readonly ILogger<HttpRequestService> _logger;

#pragma warning disable CS8618
    public HttpRequestService(
        HttpClient httpClient,
        IServiceProvider serviceProvider,
        ILogger<HttpRequestService> logger,
        IConfiguration configuration)
    {
        _logger = logger;
        _httpClient = httpClient;
        this.configuration = configuration;
    }

    public async Task<TResult> Send<TResult>(HttpRequest request, [CallerMemberName] string callMember = "")
    {
        var authorization = option.ApiKey.Split(' ');

        _httpClient.DefaultRequestHeaders.Authorization =
            authorization.Length == 1 ? new AuthenticationHeaderValue(authorization[0]) :
            new AuthenticationHeaderValue(authorization[0], authorization[1]);

        _logger.LogDebugCustom(option.ApiKey);
        _logger.LogDebugCustom(option.BaseUrl);

        _logger.LogDebug("Sending http request from {callMember}", callMember);
        _logger.LogDebugCustom(request);

        var response = await _httpClient.SendAsync(request.Create(option.BaseUrl));
        _logger.LogDebug("Finished sending http request from {callMember} (status: {status})", callMember, response.StatusCode);

        var resultContent = Util.AddDepthToJson(await response.Content.ReadAsStringAsync());
        _logger.LogDebugCustom(resultContent);
        var result = await response.Content.ReadFromJsonAsync<TResult>();
        return result!;
    }
}