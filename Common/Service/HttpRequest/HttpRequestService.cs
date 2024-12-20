﻿using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace Common.Service;
public class HttpRequestService
{
    public IHttpRequestOption option;
    public IConfiguration Configuration;
    private readonly HttpClient _httpClient;
    private readonly ILogger<HttpRequestService> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

#pragma warning disable CS8618
    public HttpRequestService(
        HttpClient httpClient,
        IServiceProvider serviceProvider,
        ILogger<HttpRequestService> logger,
        IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _httpClient = httpClient;
        Configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResult> Send<TResult>(HttpRequest request, [CallerMemberName] string callMember = "")
    {
        var traceId = _httpContextAccessor.GetTraceId();
        var authorization = option.ApiKey.Split(' ');
        var descriptor = nameof(HttpRequestService);
        var requestDate = DateTime.UtcNow;

        _httpClient.DefaultRequestHeaders.Authorization =
            authorization.Length == 1 ? new AuthenticationHeaderValue(authorization[0]) :
            new AuthenticationHeaderValue(authorization[0], authorization[1]);

        _logger.LogDebug("Sending http request from {callMember}", callMember);
        var body = request.Content != null ? request.Content.ToJson()! : "without body";
        var requestLog = new RequestLog(request.Method, request.Url, option.ApiKey, body);
        _logger.LogDebugCustom(traceId, "(Request)"+descriptor, requestLog);

        var response = await _httpClient.SendAsync(request.Create(option.BaseUrl));
        _logger.LogDebug("Finished sending http request from {callMember} (status: {status})", callMember, response.StatusCode);

        var responseBody = await response.Content.ReadAsStringAsync();
        var responseLog = new ResponseLog(response.StatusCode, responseBody,requestDate);
        _logger.LogDebugCustom(traceId, "(Response)" + descriptor, requestLog);

        if (!response.IsSuccessStatusCode) throw new RequestFailed("RequestFailed! traceId:" + traceId);

        var responseContent = await response.Content.ReadAsStringAsync();
        var result = Json.Deserialize<TResult>(responseContent);
        return result!;
    }
}