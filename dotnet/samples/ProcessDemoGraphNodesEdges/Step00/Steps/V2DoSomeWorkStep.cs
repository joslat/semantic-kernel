// Copyright (c) Microsoft. All rights reserved.

using Microsoft.SemanticKernel;

namespace ProcessDemoGraphNodesEdges.Step00.Steps;
public class V2DoSomeWorkStep : KernelProcessStep
{
    [KernelFunction]
    public async ValueTask ExecuteAsync(KernelProcessStepContext context)
    {
        Console.WriteLine("Step 2 - Doing Some Work...\n");
        // No need to emit custom events
    }
}
