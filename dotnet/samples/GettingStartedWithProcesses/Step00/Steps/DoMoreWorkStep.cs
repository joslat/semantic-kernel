// Copyright (c) Microsoft. All rights reserved.

using Microsoft.SemanticKernel;

namespace Step00.Steps;

public class DoMoreWorkStep : BaseStep<DoMoreWorkStep>
{
    [KernelFunction(Functions.Execute)]
    public async ValueTask ExecuteAsync(KernelProcessStepContext context)
    {
        Console.WriteLine("Step 3 - Doing Yet More Work.../n");
        await context.EmitEventAsync(OutputEvents.Executed);
    }
}
