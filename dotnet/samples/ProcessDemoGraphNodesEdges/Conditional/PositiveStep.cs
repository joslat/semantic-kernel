// Copyright (c) Microsoft. All rights reserved.

using Microsoft.SemanticKernel;

namespace ProcessDemoGraphNodesEdges;

public class PositiveStep : SingleFunctionKernelProcessStep<PositiveStep>
{
    [KernelFunction(Functions.Execute)]
    public async ValueTask ExecuteAsync(KernelProcessStepContext context)
    {
        Console.WriteLine("Value is positive.");
        await context.EmitEventAsync(OutputEvents.Executed);
    }

    //public static class OutputEvents
    //{
    //    public static string Executed => $"{nameof(PositiveStep)}_Executed";
    //}
}

