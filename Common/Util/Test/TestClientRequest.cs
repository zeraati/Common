using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Common;
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