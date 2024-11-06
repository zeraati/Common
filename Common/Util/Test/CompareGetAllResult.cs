using NUnit.Framework;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Common;
public static partial class Test
{
    public static async Task CompareGetAllResult<TProgram,TQueryResult>(string baseUrl,BaseEntity entity,bool checkDelete=false, string[]? excludingProperty=null)
        where TProgram : class
    {
        if (!baseUrl.Contains("GetAll")) baseUrl += "/GetAll";
        if (excludingProperty == null) excludingProperty = ["Id"];
        else excludingProperty = excludingProperty.Concat(["Id"]).ToArray();

        var getAllResult = (await CommandQuery<TProgram, ApiResult<TQueryResult[]>>(baseUrl, HttpMethod.Get)).Data!;

        if (checkDelete)
        {
            var queryResult = getAllResult.SingleOrDefault(result => Util.GetLongProperty(result!) == entity.Id);
            Assert.That(queryResult, Is.Null);
        }
        else
        {
            var queryResult = getAllResult.Single(result => Util.GetLongProperty(result!) == entity.Id);
            entity.Should().BeEquivalentTo(queryResult, option => option.Excluding(info => excludingProperty.Contains(info.Name)));
        }
    }
}