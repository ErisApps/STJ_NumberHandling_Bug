using System.Text.Json.Serialization;

namespace STJ_NumberHandling_Bug.Models;

public readonly struct AccuracyTrackerDtoWithoutNumberHandlingAttribute
{
	[JsonPropertyName("gridAcc")]
	public List<double>? GridAcc { get; }

	[JsonConstructor]
	public AccuracyTrackerDtoWithoutNumberHandlingAttribute(List<double>? gridAcc)
	{
		GridAcc = gridAcc;
	}
}