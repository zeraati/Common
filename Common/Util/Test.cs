using MediatR;
using System.Text;
using NUnit.Framework;
using FluentAssertions;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Common;
public static partial class Test
{
    public static async Task<TResult> CommandQuery<TProgram, TResult>(string url, HttpMethod method, IBaseRequest? baseRequest = null)
            where TProgram : class
            where TResult : ApiResult
    {
        var factory = new WebApplicationFactory<TProgram>().WithWebHostBuilder(x => { });
        var request = new TestClientRequest(url, method, baseRequest);
        var result = await factory.SendRequest<TProgram, TResult>(request);
        Assert.That(result.Success, Is.EqualTo(true));
        return result;
    }

    public static async Task CompareGetAllResul<TProgram,TQueryResult>(string baseUrl, object? command, long crateId) where TProgram : class
    {
        var getAllResult = (await Test.CommandQuery<TProgram, ApiResult<TQueryResult[]>>
            (baseUrl + "/GetAll", HttpMethod.Get)).Data!;

        if (command != null)
        {
            var queryResult = getAllResult.Single(result => Util.GetLongProperty(result!) == crateId);
            command.Should().BeEquivalentTo(queryResult, option => option.Excluding(info => info.Name == nameof(BaseEntity.Id)));
        }
        else
        {
            var queryResult = getAllResult.SingleOrDefault(result => Util.GetLongProperty(result!) == crateId);
            Assert.That(queryResult, Is.Null);
        }
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