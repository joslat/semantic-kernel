// Copyright (c) Microsoft. All rights reserved.

using Microsoft.SemanticKernel;

namespace ProcessDemoGraphNodesEdges;

public class NegativeStep : SingleFunctionKernelProcessStep<NegativeStep>
{
    [KernelFunction(Functions.Execute)]
    public async ValueTask ExecuteAsync(KernelProcessStepContext context)
    {
        Console.WriteLine("Value is negative or zero.");
        await context.EmitEventAsync(OutputEvents.Executed);
    }

    //public static class OutputEvents
    //{
    //    public static string Executed => $"{nameof(NegativeStep)}_Executed";
    //}
}
