using MediatR;
using NUnit.Framework;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Common;
public static partial class Test
{
    public static async Task CompareGetAllResult<TProgram,TQueryResult>(string baseUrl,long id,object? command=null, string[]? excludingProperty=null)
        where TProgram : class
    {
        if (!baseUrl.Contains("GetAll")) baseUrl += "GetAll";
        if (excludingProperty == null) excludingProperty = ["Id"];
        else excludingProperty = excludingProperty.Concat(["Id"]).ToArray();

        var getAll = (await CommandQuery<TProgram, ApiResult<TQueryResult[]>>(baseUrl, HttpMethod.Get)).Data!;

        if (command==null)
        {
            var result = getAll.SingleOrDefault(item => Util.GetLongProperty(item!) == id);
            Assert.That(result, Is.Null);
        }
        else
        {
            var result = getAll.Single(item => Util.GetLongProperty(item!) == id);
            command.Should().BeEquivalentTo(result, option => option.Excluding(info => excludingProperty.Contains(info.Name)));
        }
    }
}