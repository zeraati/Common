using Microsoft.AspNetCore.Mvc;

namespace Xunit;
public static class ApiResultExtension
{
    public static void AssertTrue(this ApiResult result) => Assert.True(result.Success);
}