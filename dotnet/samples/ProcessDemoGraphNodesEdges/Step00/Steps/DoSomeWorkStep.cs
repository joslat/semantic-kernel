// Copyright (c) Microsoft. All rights reserved.

using Microsoft.SemanticKernel;

namespace ProcessDemoGraphNodesEdges.Step00.Steps;
public class DoSomeWorkStep : BaseStep<DoSomeWorkStep>
{
    [KernelFunction(Functions.Execute)]
    public async ValueTask ExecuteAsync(KernelProcessStepContext context)
    {
        Console.WriteLine("Step 2 - Doing Some Work.../n");
        await context.EmitEventAsync(OutputEvents.Executed);
    }
}
