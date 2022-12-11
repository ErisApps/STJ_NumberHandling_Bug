using System.Text.Json.Serialization;

namespace STJ_NumberHandling_Bug.Models;

public readonly struct AccuracyTrackerDtoWithNumberHandlingAttribute
{
	[JsonPropertyName("gridAcc")]
	[JsonNumberHandling(JsonNumberHandling.AllowNamedFloatingPointLiterals)]
	public List<double>? GridAcc { get; }

	[JsonConstructor]
	public AccuracyTrackerDtoWithNumberHandlingAttribute(List<double>? gridAcc)
	{
		GridAcc = gridAcc;
	}
}