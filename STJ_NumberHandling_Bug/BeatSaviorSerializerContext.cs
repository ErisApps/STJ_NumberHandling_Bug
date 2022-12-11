using System.Text.Json.Serialization;
using STJ_NumberHandling_Bug.Models;

namespace STJ_NumberHandling_Bug;

[JsonSerializable(typeof(List<AccuracyTrackerDtoWithoutNumberHandlingAttribute>))]
[JsonSerializable(typeof(List<AccuracyTrackerDtoWithNumberHandlingAttribute>))]
[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Metadata)]
public partial class BeatSaviorSerializerContext : JsonSerializerContext
{
}