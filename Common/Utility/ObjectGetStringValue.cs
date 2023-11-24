using Common.Extension;
using Newtonsoft.Json.Linq;

namespace Common;
public static partial class Utility
{
	//TODO پیچیدگی دارد
	public static string? ObjectGetStringValue(object obj, string propertyName)
	{
		if(obj==null) return null;

		if (obj.ToString().IsJson() == true)
		{
			var data = ((JToken)obj)[propertyName];
			if (data == null) return null;

			return data.ToString();
		}

		var property = obj.GetType().GetProperty(propertyName);
		if (property == null) throw new ArgumentNullException(nameof(propertyName));

		var value = property.GetValue(obj);

		if (value == null) return null;

		var result = value.ToString();
		return result;
	}
}