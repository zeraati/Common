using MediatR;
using System.Text;
using NUnit.Framework;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Common;
public static partial class Test
{
    public static async Task<TResult> TestCommandQuery<TProgram, TResult>(string url, HttpMethod method, IBaseRequest? baseRequest = null)
            where TProgram : class
            where TResult : ApiResult
    {
        var factory = new WebApplicationFactory<TProgram>().WithWebHostBuilder(x => { });
        var request = new TestClientRequest(url, method, baseRequest);
        var result = await factory.SendRequest<TProgram,TResult>(request);
        Assert.Equals(result.Success,true);
        return result;
    }
}

public class TestClientRequest
{
    public TestClientRequest(string url, HttpMethod method, object? content = null)
    {
        Url = url;
        Method = method;
        Content = content;
    }

    public string Url { get; }
    public HttpMethod Method { get; }
    public object? Content { get; }

    public HttpRequestMessage Create()
    {
        var httpRequest = new HttpRequestMessage(Method, Url);
        if ((Method == HttpMethod.Post || Method == HttpMethod.Put) && Content != null) httpRequest.Content = ToStringContent(Content);
        return httpRequest;
    }

    private StringContent ToStringContent(object obj)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            MaxDepth = 16,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };
        return new StringContent(JsonSerializer.Serialize(obj, options), Encoding.UTF8, "application/json");
    }
}

