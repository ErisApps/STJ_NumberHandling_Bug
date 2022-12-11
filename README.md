# STJ_NumberHandling_bug
A proof-of-concept repo that demonstrates a bug that can occur when leveraging STJ sourcegenerated SerializerContext which are additionally configured at runtime using JsonSerializerOptions.

## Explanation of the bug
The asset file `accuracyTrackerDto.json` (found in the Assets folder) contains a JSON object that contains a property called `"gridAcc"`, which contains `"NaN"` string values.

The bug occurs whenever the following conditions are met:
1. A source generated SerializerContext is used
2. The SerializerContext is configured at runtime using JsonSerializerOptions, which has it's `NumberHandling` property set to `JsonNumberHandling.AllowNamedFloatingPointLiterals`

The bug doesn't occur when the property in the class/struct itself is annotated with the `JsonNumberHandling` attribute, or when not using a SerializerContext at all.

The bug can be reproduced across all versions of System.Text.Json that support source generated SerializerContexts and has the `JsonNumberHandling` attribute (5.0.0 and up) as far as my testing went.