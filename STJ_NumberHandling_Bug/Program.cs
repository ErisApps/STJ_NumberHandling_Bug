// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using System.Text.Json.Serialization;
using STJ_NumberHandling_Bug;
using STJ_NumberHandling_Bug.Models;

Console.WriteLine("Hello, World!");
Console.WriteLine();

try
{
	Console.WriteLine("Running code to demonstrate the bug");
	await ProofOfIssue().ConfigureAwait(false);
}
catch (Exception e)
{
	Console.WriteLine(e);
}

Console.WriteLine();

Console.WriteLine("Run code to demonstrate the workaround");
await ProofOfIssueWorkaround().ConfigureAwait(false);

Console.WriteLine();

Console.WriteLine("Run code to demonstrate that code not relying on a source generator serializerContext is not affected by the bug");
await NotAffectedPath().ConfigureAwait(false);

static async Task ProofOfIssue()
{
	var jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web) { NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals };
	var beatSaviorSerializerContext = new BeatSaviorSerializerContext(jsonSerializerOptions);

	await using var gridAccFileStream = ReadTestAsset();
	var accuracyTrackerDto = await JsonSerializer.DeserializeAsync(gridAccFileStream, beatSaviorSerializerContext.AccuracyTrackerDtoWithoutNumberHandlingAttribute, cancellationToken: default);

	Console.WriteLine("Successfully deserialized the file");
}

static async Task ProofOfIssueWorkaround()
{
	var jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
	var beatSaviorSerializerContext = new BeatSaviorSerializerContext(jsonSerializerOptions);

	await using var gridAccFileStream = ReadTestAsset();
	var accuracyTrackerDto = await JsonSerializer.DeserializeAsync(gridAccFileStream, beatSaviorSerializerContext.AccuracyTrackerDtoWithNumberHandlingAttribute, cancellationToken: default);

	Console.WriteLine("Successfully deserialized the file");
}

static async Task NotAffectedPath()
{
	var jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web) { NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals };

	await using var gridAccFileStream = ReadTestAsset();
	var accuracyTrackerDto = await JsonSerializer.DeserializeAsync<AccuracyTrackerDtoWithoutNumberHandlingAttribute>(gridAccFileStream, jsonSerializerOptions, cancellationToken: default);

	Console.WriteLine("Successfully deserialized the file");
}

static FileStream ReadTestAsset()
{
	var assetsPath = Path.Combine(Environment.CurrentDirectory, "Assets");
	return File.OpenRead(Path.Combine(assetsPath, "accuracyTrackerDto.json"));
}