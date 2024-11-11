// Copyright (c) Microsoft. All rights reserved.

using Microsoft.SemanticKernel;

namespace ProcessDemoGraphNodesEdges.Step00.Steps;
public class EndStep : BaseStep<EndStep>
{
    [KernelFunction(Functions.Execute)]
    public async ValueTask ExecuteAsync(KernelProcessStepContext context)
    {
        Console.WriteLine("Step 4 - This is the Final Step.../n");
        await context.EmitEventAsync(OutputEvents.Executed);
    }
}
