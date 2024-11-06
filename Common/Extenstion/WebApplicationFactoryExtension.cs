using Common;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace Microsoft.AspNetCore.Mvc.Testing;
public static class WebApplicationFactoryExtension
{
    public static async Task<TResult> SendRequest<TProgram, TResult>(this WebApplicationFactory<TProgram> factory, TestClientRequest request)
        where TProgram : class
    {
        var httpRequest = request.Create();
        
        var response = await factory.CreateClient().SendAsync(httpRequest);
        if (response.StatusCode == HttpStatusCode.NotFound) throw new Exception("NotFound\n"+Json.AddDepthToJson(httpRequest.ToJson()!));

        var result = await response.Content.ReadFromJsonAsync<TResult>();
        return result!;
    }
}
