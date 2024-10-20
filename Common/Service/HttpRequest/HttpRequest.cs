using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Csis.Common.Service;
public class HttpRequest
{
    public HttpRequest(string url, HttpMethod method, object content)
    {
        Url = url;
        Method = method;
        Content = content;
    }

    public string Url { get;}
    public HttpMethod Method{ get;}
    public object Content{ get;}

    public HttpRequestMessage Create(string baseUrl)
    {
        var baseUri = new Uri(baseUrl);
        var url = new Uri(baseUri, Url);
        var httpRequest = new HttpRequestMessage(Method, url);
        httpRequest.Content = ToStringContent(Content);
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
