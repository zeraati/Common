using MediatR;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
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

}