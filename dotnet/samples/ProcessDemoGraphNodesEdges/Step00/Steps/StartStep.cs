// Copyright (c) Microsoft. All rights reserved.

using Microsoft.SemanticKernel;

namespace ProcessDemoGraphNodesEdges.Step00.Steps;
public sealed class StartStep : BaseStep<StartStep>
{
    [KernelFunction]
    public async ValueTask ExecuteAsync(KernelProcessStepContext context)
    {
        Console.WriteLine("Step 1 - Start /n");
        await context.EmitEventAsync(OutputEvents.Executed);
    }
}
